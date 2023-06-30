using System.Collections;
using System.ComponentModel;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking.Types;
using UnityEngine.Rendering;

public class UnitController : MonoBehaviour
{
	[SerializeField] private GameObject unitMarker;
    [SerializeField] private int damage;
    [SerializeField] public int hp;
    [SerializeField] public float attackDelay;
    [SerializeField] public float attackRange;
    [SerializeField] Barrack barrack;
    public int fullhp;
    public	NavMeshAgent navMeshAgent;
	public Animator anim;
    public Vector3 resetPoision;
    public EnemyMover enemyMover;
    public EnemyController enemyController;
    public bool isChooseEnemy;
    public bool isMove;
    public bool isdie;
    public GameObject enemyObject;
    public GameObject uc;
    public RTSUnitController rts;
    public Vector3 idlePoint;
    Coroutine battleRoutine;
    Coroutine searchEnemyRoutine;
    public EnemyController targetenemyController;


    private void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		uc = GameObject.FindGameObjectWithTag("MainCamera");
        rts = uc.GetComponent<RTSUnitController>();
		rts.UnitList.Add(this);
        anim = GetComponent<Animator>();
        fullhp = hp;
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
            if (enemyController.HP <= 0)
            {
                RemoveEnemy(enemyObject);
                yield break;
            }
            if (enemyMover != null)
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
			yield return new WaitForSeconds(attackDelay);
			if (enemyController.HP <= 0)
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
            StopCoroutine(battleRoutine);
            enemyController.isTarget = false;
            Debug.Log("diiiiie");
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(1.5f);
            RemoveEnemy(enemyObject);
            hp = fullhp;
            gameObject.transform.position = resetPoision;
            gameObject.SetActive(false);
            barrack.ResponSoldier(gameObject);
            yield break;
        }
    }
}