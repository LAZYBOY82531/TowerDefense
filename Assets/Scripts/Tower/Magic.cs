using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] float range;
    private List<EnemyController> enemys;
    private EnemyController enemy;
    private int damage;
    private Vector3 targetPoint1;
    private Vector3 targetPoint2;
    private Vector3 targetPoint3;
    private Vector3 targetPoint4;


    public void SetTarget(EnemyController enemy)
    {
        enemys.Add(enemy);
        this.enemy = enemy;
        Target();
        DamageEnemy();
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void Target()
    {
        int repeat = 1;
        while (repeat < 4)
        {
            targetPoint1 = enemy.transform.position;
            Collider[] colliders1 = Physics.OverlapSphere(targetPoint1, range, LayerMask.GetMask("Enemy"));
            if (colliders1.Length >= 2)
            {
                foreach (Collider collider in colliders1)
                {
                    EnemyController isenemy = collider.GetComponent<EnemyController>();
                    if (isenemy != enemy)
                    {
                        enemys.Add(isenemy);
                        targetPoint2 = isenemy.transform.position;
                        repeat++;
                    }
                    else
                    {
                        GameManager.Pool.Release(gameObject);
                    }
                    if (repeat == 2)
                    {
                        Collider[] colliders2 = Physics.OverlapSphere(targetPoint1, range, LayerMask.GetMask("Enemy"));
                        if (colliders2.Length >= 2)
                        {
                            foreach (Collider collider2 in colliders2)
                            {
                                EnemyController isenemy2 = collider2.GetComponent<EnemyController>();
                                if (isenemy2 != enemy)
                                {
                                    enemys.Add(isenemy2);
                                    targetPoint3 = isenemy2.transform.position;
                                    repeat++;
                                }
                                else
                                {
                                    GameManager.Pool.Release(gameObject);
                                }
                                if (repeat == 3)
                                {
                                }
                            }
                        }
                        else
                        {
                            GameManager.Pool.Release(gameObject);
                        }
                    }
                }
            }
            else
            {
                GameManager.Pool.Release(gameObject);
            }
        }
    }

    public void DamageEnemy()
    {
        foreach(EnemyController enemy in enemys)
        {
            enemy.TakeHit(damage);
        }
    }
}
