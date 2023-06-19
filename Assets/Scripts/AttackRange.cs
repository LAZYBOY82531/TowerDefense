using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public Tower tower;
    public LayerMask enemyMask;

    public UnityEvent<EnemyController> OnInRangeEnemy;
    public UnityEvent<EnemyController> OnOutRangeEnemy;


    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyMask) != 0)
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            OnInRangeEnemy?.Invoke(enemy);
            enemy.OnDied.AddListener(() => { OnOutRangeEnemy?.Invoke(enemy); });
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyMask) != 0)
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            OnOutRangeEnemy?.Invoke(enemy);
        }
    }
}
