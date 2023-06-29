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
            OnInRangeEnemy?.Invoke(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyMask) != 0)
        {
            OnOutRangeEnemy?.Invoke(other.gameObject);
        }
    }
}
