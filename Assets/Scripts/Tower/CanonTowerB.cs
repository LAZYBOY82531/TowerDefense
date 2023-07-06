using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTowerB : Tower
{
    [SerializeField] Transform canonPoint;
    [SerializeField] Transform canonPoint2;
    [SerializeField] Transform canonPoint3;
    [SerializeField] string canonBallName;

    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        range = data.towers[element].range;
        attackdelay = data.towers[element].delay - (PlayerPrefs.GetInt("CanonTowerAttackDelay") * 0.1f);
    }

    private void OnEnable()
    {
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
        float time3 = 10;
        while (true)
        {
            if (enemyList.Count > 0)
            {
                time1 += Time.deltaTime;
                if (time1 > attackdelay)
                {
                    Attack(enemyList[0]);
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
            if (enemyList.Count > 2)
            {
                time3 += Time.deltaTime;
                if (time3 > attackdelay)
                {
                    Attack3(enemyList[2]);
                    time3 = 0;
                }
            }
            yield return null;
        }
    }

    public void Attack(EnemyController enemy)
    {
        CanonBall canon = GameManager.Pool.Get<CanonBall>(GameManager.Resource.Load<CanonBall>(canonBallName), canonPoint.position, canonPoint.rotation);
        canon.SetTarget(enemy);
        canon.SetDamage(data.towers[element].damage + PlayerPrefs.GetInt("CanonTowerDamage"));
    }
    public void Attack2(EnemyController enemy)
    {
        CanonBall canon1 = GameManager.Pool.Get<CanonBall>(GameManager.Resource.Load<CanonBall>(canonBallName), canonPoint2.position, canonPoint2.rotation);
        canon1.SetTarget(enemy);
        canon1.SetDamage(data.towers[element].damage + PlayerPrefs.GetInt("CanonTowerDamage"));
    }
    public void Attack3(EnemyController enemy)
    {
        CanonBall canon2 = GameManager.Pool.Get<CanonBall>(GameManager.Resource.Load<CanonBall>(canonBallName), canonPoint3.position, canonPoint3.rotation);
        canon2.SetTarget(enemy);
        canon2.SetDamage(data.towers[element].damage + PlayerPrefs.GetInt("CanonTowerDamage"));
    }
    public override void Debuff()
    {
        base.Debuff();
    }
}
