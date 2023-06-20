using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : Tower
{
    [SerializeField] Transform magicPoint;
    [SerializeField] float magicRange;
    public List<EnemyController> enemys;
    private Vector3 targetPoint3;
    private Vector3 targetPoint2;
    private Vector3 targetPoint;


    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/MageTowerData");
        range = data.towers[towerLV].range;
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
                GameManager.Pool.Get<GameObject>(GameManager.Resource.Load<GameObject>("Tower/Thunder"), magicPoint.position, magicPoint.rotation);
                Attack(enemyList[0]);
                yield return new WaitForSeconds(data.towers[towerLV].delay);
                enemys.Clear();
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Attack(EnemyController enemy)
    {
        targetPoint = enemy.transform.position;
        enemys?.Add(enemy);
        Collider[] colliders1 = Physics.OverlapSphere(targetPoint, magicRange, LayerMask.GetMask("Enemy"));
        if (colliders1.Length >= 2)
        {
            foreach (Collider collider in colliders1)
            {
                EnemyController isenemy = collider?.GetComponent<EnemyController>();
                if (isenemy != enemy)
                {
                    enemys?.Add(isenemy);
                    targetPoint2 = isenemy.transform.position;
                    Collider[] colliders2 = Physics.OverlapSphere(targetPoint2, magicRange, LayerMask.GetMask("Enemy"));
                    if (colliders2.Length >= 2)
                    {
                        foreach (Collider collider2 in colliders2)
                        {
                            EnemyController isenemy1 = collider2?.GetComponent<EnemyController>();
                            if (isenemy1 != isenemy && isenemy1 != enemy)
                            {
                                enemys?.Add(isenemy1);
                                targetPoint3 = isenemy1.transform.position;
                                Collider[] colliders3 = Physics.OverlapSphere(targetPoint3, magicRange, LayerMask.GetMask("Enemy"));
                                if (colliders2.Length >= 2)
                                {
                                    foreach (Collider collider3 in colliders3)
                                    {
                                        EnemyController isenemy2 = collider3?.GetComponent<EnemyController>();
                                        if (isenemy2 != isenemy && isenemy2 != enemy && isenemy2 != isenemy1)
                                        {
                                            enemys?.Add(isenemy2);
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }
        if (enemys.Count > 0)
        {
            foreach(EnemyController e in enemys)
            {
                e?.TakeHit(data.towers[towerLV].damage);
                GameManager.Pool.Get<GameObject>(GameManager.Resource.Load<GameObject>("Tower/Thunder"), e.transform.position, e.transform.rotation);
            }
        }
    }
}
