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
	private	NavMeshAgent navMeshAgent;
	private Animator anim;
	public GameObject uc;
	public RTSUnitController rts;
	public int damage;
    public int fullhp;
    public int hp;
    public float attackDelay;
	public float attackRange;
	public Vector3 idlePoint;
	public Vector3 resetPoision;
    public StateBase[] states;
	public EnemyMover enemyMover = null;
	public EnemyController enemyController = null;
	public bool isChooseEnemy = false;
    public bool isMove = false;
    public bool isdie = false;


    private void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		uc = GameObject.FindGameObjectWithTag("UnitControlSystem");
        rts = uc.GetComponent<RTSUnitController>();
		rts.UnitList.Add(this);
        anim = GetComponent<Animator>();
        fullhp = hp;
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
                yield break;
            }
			yield return null;
        }
	}

    public void AddEnemy(GameObject enemy)
    {
		isChooseEnemy = true;
		if (isChooseEnemy == false && isMove == false)
        {
            navMeshAgent.enabled = true;
            anim?.SetBool("IsTarget", true);
			enemyController = enemy.GetComponent<EnemyController>();
			enemyMover = enemy.GetComponent<EnemyMover>();
            StartCoroutine(GoBattleEnemyCoroutine(enemyMover, enemyController));
        }
    }

    public void RemoveEnemyMover(EnemyMover enemy)
    {
		isChooseEnemy = false;
		enemyMover = null;
        enemyController = null;
    }

	IEnumerator GoBattleEnemyCoroutine(EnemyMover enemyMover, EnemyController enemyController)
	{
		while (true)
        {
            if(enemyMover != null)
                navMeshAgent.SetDestination(enemyMover.transform.position);
            if (Vector3.Distance(enemyMover.transform.position, transform.position) < attackRange)
            {
                navMeshAgent.enabled = false;
                enemyMover.BattleStart();
				enemyController.AttackSolider(this);
                StartCoroutine(BattleEnemyCoroutine(enemyMover, enemyController));
                yield break;
            }
        }
    }

	IEnumerator BattleEnemyCoroutine(EnemyMover enemyMover, EnemyController enemyController)
	{
		while(true)
		{
			anim.SetTrigger("Attack");
            if(enemyMover != null)
			    enemyController.TakeHit(damage);
			yield return new WaitForSeconds(attackDelay);
			if (enemyController.HP <= 0)
            {

            }
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
                StartCoroutine(Die());
                isdie = true;
            }
        }
    }

    IEnumerator Die()
    {
        while (true)
        {
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(1.2f);
            this.gameObject.SetActive(false);
            hp = fullhp;
            gameObject.transform.position = resetPoision;
            yield break;
        }
    }
}