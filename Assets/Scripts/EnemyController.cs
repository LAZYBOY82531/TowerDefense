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
    public int HP { get { return hp; } private set { hp = value; OnChangedHP?.Invoke(hp); } }
    public UnityEvent<int> OnChangedHP;
    private Animator anim;
    private IEnumerator DieEnumerator;
    private bool isdie = false;

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
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
        FullHP();
        resetPosition?.Invoke();
        yield return null;
    }
}
