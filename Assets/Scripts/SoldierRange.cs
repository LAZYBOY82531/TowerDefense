using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoldierRange : MonoBehaviour
{
    public LayerMask enemyMask;
    public UnityEvent<GameObject> OnInRangeEnemy;
    public UnityEvent<GameObject> OnOutRangeEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyMask) != 0)
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            GameObject enemyObject = other.GetComponent<GameObject>();
            OnInRangeEnemy?.Invoke(enemyObject);
            enemy.OnDied.AddListener(() => { OnOutRangeEnemy?.Invoke(enemyObject); });
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyMask) != 0)
        {
            GameObject enemyObject = other.GetComponent<GameObject>();
            OnOutRangeEnemy?.Invoke(enemyObject);
        }
    }
}
