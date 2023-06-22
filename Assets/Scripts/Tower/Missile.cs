using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Missile : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float range;
    private Rigidbody rb;

    private int damage;
    private Vector3 targetPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetTarget(EnemyController enemy)
    {
        targetPoint = enemy.transform.position;
        StartCoroutine(CanonRoutine());
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    
    public void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Enemy"));
        foreach (Collider collider in colliders)
        {
            EnemyController enemy = collider.GetComponent<EnemyController>();
            enemy?.TakeHit(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator CanonRoutine()
    {
        float xSpeed = (targetPoint.x - transform.position.x) / time;
        float zSpeed = (targetPoint.z - transform.position.z) / time;
        float ySpeed = -1 * (0.5f * Physics.gravity.y * time * time + transform.position.y) / time;

        float curTime = 0;
        while (curTime < time)
        {
            curTime += Time.deltaTime;
            transform.right = rb.velocity;
            transform.position += new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;
            ySpeed += Physics.gravity.y * Time.deltaTime;

            yield return null;
        }

        transform.position = targetPoint;
        yield return null;

        Explosion();
        GameManager.Pool.Release(this);
    }
}
