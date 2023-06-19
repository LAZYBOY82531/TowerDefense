using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int hp = 5;
    [SerializeField] int fullhp;
    [SerializeField] UnityEvent resetPosition;
    public int HP { get { return hp; } private set { hp = value; OnChangedHP?.Invoke(hp); } }
    public UnityEvent<int> OnChangedHP;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        fullhp = hp;
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
            OnDied?.Invoke();
            GameManager.Data.Coin += 5;
            anim.SetTrigger("Die");
            this.gameObject.SetActive(false);
            FullHP();
            resetPosition?.Invoke();
        }
    }
}
