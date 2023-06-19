using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    public Collider[] colliders1;
    public EnemyController enemy1;
    private EnemyController enemy;
    private int damage;
    private Vector3 targetPoint;


    public void SetTarget(EnemyController enemy)
    {
        this.enemy = enemy;
        targetPoint = enemy.transform.position;
        StartCoroutine(MagicRoutine());
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    IEnumerator MagicRoutine()
    {
        while (true)
        {
            if (enemy != null)
                targetPoint = enemy.transform.position;
            transform.LookAt(targetPoint);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

            if (Vector3.Distance(targetPoint, transform.position) < 0.1f)
            {
                if (enemy != null)
                    enemy?.TakeHit(damage);
                colliders1 = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));
                if (colliders1.Length > 1)
                {
                    enemy1 = colliders1[1].GetComponent<EnemyController>();
                    if (enemy1 != null)
                        targetPoint = enemy1.transform.position;
                    transform.LookAt(targetPoint);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
                    if (Vector3.Distance(targetPoint, transform.position) < 0.1f)
                    {
                        if (enemy1 != null)
                            enemy1?.TakeHit(damage);
                    }
                }
                GameManager.Pool.Release(this);
                yield break;
            }

            yield return null;
        }
    }

    private void Gggggggg()
    {
        colliders1 = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));
        if (colliders1.Length > 1)
        {
            enemy1 = colliders1[1].GetComponent<EnemyController>();
            if (enemy1 != null)
                targetPoint = enemy1.transform.position;
            transform.LookAt(targetPoint);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            if (Vector3.Distance(targetPoint, transform.position) < 0.1f)
            {
                if (enemy1 != null)
                    enemy1?.TakeHit(damage);
            }
        }
    }
    IEnumerator MagicRoutine22()
    {
        while (true)
        {
            if (enemy != null)
                targetPoint = enemy.transform.position;
            transform.LookAt(targetPoint);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            if (Vector3.Distance(targetPoint, transform.position) < 0.1f)
            {
                if (enemy != null)
                    enemy?.TakeHit(damage);
                yield return new WaitForSeconds(0.01f);
                Collider[] colliders1 = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));
                if (colliders1.Length != 0)
                {
                    EnemyController enemy1 = colliders1[0].GetComponent<EnemyController>();
                    if (enemy1 != null)
                        targetPoint = enemy1.transform.position;
                    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
                    if (Vector3.Distance(targetPoint, transform.position) < 0.1f)
                    {
                        if (enemy1 != null)
                            enemy1?.TakeHit(damage);
                        yield return new WaitForSeconds(0.01f);
                        Collider[] colliders2 = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));
                        if (colliders2.Length != 0)
                        {
                            EnemyController enemy2 = colliders2[0].GetComponent<EnemyController>();
                            if (enemy2 != null)
                                targetPoint = enemy2.transform.position;
                            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
                            if (Vector3.Distance(targetPoint, transform.position) < 0.1f)
                            {
                                if (enemy2 != null)
                                    enemy2?.TakeHit(damage);
                                yield return new WaitForSeconds(0.01f);
                                Collider[] colliders3 = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));
                                if (colliders3.Length != 0)
                                {
                                    EnemyController enemy3 = colliders3[0].GetComponent<EnemyController>();
                                    if (enemy3 != null)
                                        targetPoint = enemy3.transform.position;
                                    transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
                                    if (Vector3.Distance(targetPoint, transform.position) < 0.1f)
                                    {
                                        if (enemy3 != null)
                                            enemy3?.TakeHit(damage);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            GameManager.Pool.Release(this);
            yield break;
        }
    }
}
