using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class ArcherTowerB : Tower
{
    [SerializeField] Transform archer;
    [SerializeField] Transform arrowPoint;
    [SerializeField] Transform archer2;
    [SerializeField] Transform arrowPoint2;
    [SerializeField] AudioSource arrowsound;

    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        range = data.towers[element].range;
        attackdelay = data.towers[element].delay - (PlayerPrefs.GetInt("ArcherTowerAttackDelay") * 0.1f);
    }

    private void OnEnable()
    {
        StartCoroutine(LookRoutine());
        StartCoroutine(AttackRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        float time1 = 10;
        float time2 = 10;
        while (true)
        {
            if (enemyList.Count > 0)
            {
                time1 += Time.deltaTime;
                if (time1 > attackdelay)
                {
                    Attack1(enemyList[0]);
                    time1 = 0;
                }
            }
            if (enemyList.Count > 1)
            {
                time2 += Time.deltaTime;
                if (time2 > attackdelay)
                {
                    Attack2(enemyList[1]);
                    time2 = 0;
                }
            }
            yield return null;
        }
    }

    public void Attack1(EnemyController enemy)
    {
        arrowsound.Play();
        Arrow arrow = GameManager.Pool.Get<Arrow>(GameManager.Resource.Load<Arrow>("Tower/Arrow"), arrowPoint.position, arrowPoint.rotation);
        arrow.SetTarget(enemy);
        arrow.SetDamage(data.towers[element].damage + PlayerPrefs.GetInt("ArcherTowerDamage"));
    }

    public void Attack2(EnemyController enemy)
    {
        arrowsound.Play();
        Arrow arrow = GameManager.Pool.Get<Arrow>(GameManager.Resource.Load<Arrow>("Tower/Arrow"), arrowPoint2.position, arrowPoint2.rotation);
        arrow.SetTarget(enemy);
        arrow.SetDamage(data.towers[element].damage + PlayerPrefs.GetInt("ArcherTowerDamage"));
    }

    IEnumerator LookRoutine()
    {
        while (true)
        {
            if(enemyList.Count > 0)
            {
                archer.LookAt(enemyList[0].transform.position);
                if(enemyList.Count > 1)
                {
                    archer2.LookAt(enemyList[1].transform.position);
                }
            }

            yield return null;  
        }
    }

    public override void Debuff()
    {
        base.Debuff();
    }
}