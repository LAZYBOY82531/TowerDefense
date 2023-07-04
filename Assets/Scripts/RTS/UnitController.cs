using System.Collections;
using System.ComponentModel;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Networking.Types;
using UnityEngine.Rendering;

public class UnitController : MonoBehaviour
{
	[SerializeField] private GameObject unitMarker;
    [SerializeField] int hp;
    [SerializeField] Barrack barrack;
    public int damage;
    public float attackDelay;
    public float attackRange;
    public Vector3 idlePoint;
    public Vector3 resetPoision;
    public int fullHP;
    private	NavMeshAgent navMeshAgent;
	private Animator anim;
    private EnemyMover enemyMover;
    private EnemyController enemyController;
    private bool isChooseEnemy;
    private bool isMove;
    private bool isdie;
    private GameObject enemyObject;
    private GameObject uc;
    private RTSUnitController rts;
    Coroutine battleRoutine;
    Coroutine searchEnemyRoutine;
    private EnemyController targetenemyController;
    public int HP { get { return hp; } private set { hp = value; OnChangedHP?.Invoke(hp); } }
    public UnityEvent<int> OnChangedHP;
    private GameObject Auror;
    float timetime = 0;
    bool ispool;


    private void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		uc = GameObject.FindGameObjectWithTag("MainCamera");
        rts = uc.GetComponent<RTSUnitController>();
		rts.UnitList.Add(this);
        anim = GetComponent<Animator>();
        fullHP = hp;
    }

    private void OnEnable()
    {
        isdie = false;
    }

    public void SelectUnit()
	{
		unitMarker.SetActive(true);
	}

	public void DeselectUnit()
	{
		unitMarker.SetActive(false);
	}

    public void MoveTo(Vector3 end)
    {
		if (!isChooseEnemy)
        {
            navMeshAgent.enabled = true;
			isMove = true;
            navMeshAgent.SetDestination(end);
            StartCoroutine(MoveToCoroutine(end));
        }
	}

	IEnumerator MoveToCoroutine(Vector3 end)
	{
		while (true)
		{
			if (Vector3.Distance(transform.position, end) < 0.5f)
            {
                navMeshAgent.enabled = false;
                isMove = false;
                searchEnemyRoutine = StartCoroutine(SearchEnemyRoutine());
                yield break;
            }
			yield return null;
        }
	}


    IEnumerator SearchEnemyRoutine()
    {
        while (true)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, LayerMask.GetMask("Enemy"));
            foreach (Collider collider in colliders)
            {
                GameObject enemy = collider.gameObject;
                AddEnemy(enemy);
                if(isChooseEnemy == true)
                {
                    yield break;
                }
            }
            yield return null;
        }
    }


    public void AddEnemy(GameObject enemy)
    {
        targetenemyController = enemy.GetComponent<EnemyController>();
        if (!targetenemyController.isTarget)
        {
            targetenemyController.isTarget = true;
            if (isChooseEnemy == false && isMove == false)
            {
                isChooseEnemy = true;
                enemyObject = enemy;
                enemyController = enemy.GetComponent<EnemyController>();
                enemyMover = enemy.GetComponent<EnemyMover>();
                navMeshAgent.enabled = true;
                anim?.SetBool("IsTarget", true);
                StartCoroutine(GoBattleEnemyCoroutine());
            }
            else
                targetenemyController.isTarget = false;
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if(enemyObject == enemy)
        {
            isChooseEnemy = false;
            enemyObject = null;
            enemyMover = null;
            enemyController = null;
        }
    }
    
	IEnumerator GoBattleEnemyCoroutine()
	{
		while (true)
        {
            navMeshAgent.enabled = true;
            if (enemyMover != null)
            {
                if (enemyController.HP <= 0)
                {
                    RemoveEnemy(enemyObject);
                    StartCoroutine(BattleEnemyCoroutine());
                    yield break;
                }
            }
            else
            {
                RemoveEnemy(enemyObject);
                yield break;
            }
            if (enemyMover != null)
            {
                navMeshAgent.SetDestination(enemyMover.transform.position);
                if (Vector3.Distance(enemyMover.transform.position, transform.position) < attackRange)
                {
                    isChooseEnemy = true;
                    navMeshAgent.enabled = false;
                    enemyMover.BattleStart();
                    enemyController.AttackSolider(this);
                    battleRoutine = StartCoroutine(BattleEnemyCoroutine());
                    yield break;
                }
            }
            else
            {
                RemoveEnemy(enemyObject);
                yield break;
            }
            yield return null;
        }
    }

	IEnumerator BattleEnemyCoroutine()
	{
		while(true)
        {
            anim.SetTrigger("Attack");
            if(enemyMover != null)
			    enemyController.TakeHit(damage);
            else
            {
                RemoveEnemy(enemyObject);
                yield break;
            }
            yield return new WaitForSeconds(attackDelay);
            if (enemyMover != null)
            {
                if (enemyController.HP <= 0)
                {
                    RemoveEnemy(enemyObject);
                    StartCoroutine(SearchEnemyRoutine());
                    yield break;
                }
            }
            else
            {
                RemoveEnemy(enemyObject);
                yield break;
            }
            yield return null;
		}
	}

    public void SoldierTakeHit(int damage)
    {
        hp -= damage;
        OnChangedHP?.Invoke(hp);

        if (hp <= 0)
        {
            if (!isdie)
            {
                enemyMover.BackPosition();
                enemyController.EndBattle(this);
                StartCoroutine(Die());
                isdie = true;
            }
        }
    }

    IEnumerator Die()
    {
        while (true)
        {
            DeselectUnit();
            rts.DeselectUnit(this);
            StopCoroutine(battleRoutine);
            enemyController.isTarget = false;
            Debug.Log("diiiiie");
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(1.5f);
            RemoveEnemy(enemyObject);
            HP = fullHP;
            gameObject.transform.position = resetPoision;
            gameObject.SetActive(false);
            barrack.ResponSoldier(gameObject);
            yield break;
        }
    }

    public virtual void Debuff()
    {
        Auror = GameManager.Pool.Get<GameObject>(GameManager.Resource.Load<GameObject>("Prefab/Auror"), gameObject.transform.position, gameObject.transform.rotation);
        attackDelay *= 2;
        ispool = false;
        StartCoroutine(DebuffRoutine());
    }

    IEnumerator DebuffRoutine()
    {
        while (true)
        {
            timetime += Time.deltaTime;
            if (timetime > 1f)
            {
                if (!ispool)
                {
                    GameManager.Pool.Release(Auror);
                    ispool = true;
                }
            }
            if (timetime > 15f)
            {
                timetime = 0;
                attackDelay /= 2;
                yield break;
            }
            yield return null;
        }
    }
}