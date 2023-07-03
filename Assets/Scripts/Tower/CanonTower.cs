using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTower : Tower
{
    [SerializeField] Transform canonPoint;
    [SerializeField] string canonBallName;

    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        range = data.towers[element].range;
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
        while (true)
        {
            if (enemyList.Count > 0)
            {
                Attack(enemyList[0]);
                yield return new WaitForSeconds(data.towers[element].delay - (PlayerPrefs.GetInt("CanonTowerAttackDelay") * 0.1f));
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Attack(EnemyController enemy)
    {
        CanonBall canon = GameManager.Pool.Get<CanonBall>(GameManager.Resource.Load<CanonBall>(canonBallName), canonPoint.position, canonPoint.rotation);
        canon.SetTarget(enemy);
        canon.SetDamage(data.towers[element].damage + PlayerPrefs.GetInt("CanonTowerDamage"));
    }
}
