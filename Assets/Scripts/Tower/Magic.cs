using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int jumpCount = 0;
    [SerializeField] List<EnemyController> allEnemies = new List<EnemyController>();
    [SerializeField] EnemyController closestEnemy = null;
    private EnemyController enemy;
    private int damage;
    private Vector3 targetPoint;
    private int truejumpCount;

    private void Start()
    {
        truejumpCount = jumpCount;
    }
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

    private void OnDisable()
    {
        allEnemies.Clear();
        closestEnemy = null;
        jumpCount = truejumpCount;
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
                {
                    Attack(enemy);
                    jumpCount--;

                }
            }
            yield return null;
        }
    }

    public void Attack(EnemyController enemy)
    {
        enemy?.TakeHit(damage);
    }

    IEnumerator ReleaseRoutine()
    {
        yield return new WaitForSeconds(0);
        GameManager.Pool.Release(this);
    }
}
