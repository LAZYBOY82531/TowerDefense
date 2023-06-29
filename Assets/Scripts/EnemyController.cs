using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int hp = 5;
    [SerializeField] int fullhp;
    [SerializeField] int GiveCoin;
    [SerializeField] UnityEvent resetPosition;
    public int damage;
    public float attackDelay;
    public int HP { get { return hp; } private set { hp = value; OnChangedHP?.Invoke(hp); } }
    public UnityEvent<int> OnChangedHP;
    private Animator anim;
    private IEnumerator DieEnumerator;
    private bool isdie = false;
    public UnitController soldiers;
    public bool isTarget;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        fullhp = hp;
        anim.SetBool("Walk Forward", true);
    }

    private void OnEnable()
    {
        DieEnumerator = Die();
        isdie = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void FullHP()
    {
        HP = fullhp;
    }

    public UnityEvent OnDied;

    public void TakeHit(int damage)
    {
        hp -= damage;
        OnChangedHP?.Invoke(hp);

        if(hp <= 0)
        {
            if(!isdie)
            {
                OnDied?.Invoke();
                GameManager.Data.Coin += GiveCoin;
                StartCoroutine(DieEnumerator);
                isdie = true;
            }
        }
    }

    IEnumerator Die()
    {
        if(routine != null)
            StopCoroutine(routine);
        isTarget = false;
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
        FullHP();
        resetPosition?.Invoke();
        yield return null;
    }
    
    public void AttackSolider(UnitController Soldier)
    {
        soldiers = Soldier;
        transform.LookAt(soldiers.transform);
        Debug.Log("startbattle");
        routine = StartCoroutine(AttackSoldierRoutine());
    }

    Coroutine routine;
    IEnumerator AttackSoldierRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackDelay);
            Debug.Log("attack");
            anim.SetTrigger("Bite Attack");
            if (soldiers != null)
                soldiers.SoldierTakeHit(damage);
        }
    }

    public void EndBattle(UnitController soldier)
    {
        Debug.Log("endbattle");
        StopCoroutine(routine);
    }
}
