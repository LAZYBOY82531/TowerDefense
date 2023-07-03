using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    [SerializeField] Tower tower;

    public LayerMask enemyMask;
    private CapsuleCollider collider;
    public UnityEvent<EnemyController> OnInRangeEnemy;
    public UnityEvent<EnemyController> OnOutRangeEnemy;

    private void Awake()
    {
        collider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        if (tower.data == GameManager.Resource.Load<TowerData>("Data/ArcherTowerData"))
            collider.radius = tower.range + PlayerPrefs.GetInt("ArcherTowerRange");
        else if (tower.data == GameManager.Resource.Load<TowerData>("Data/CanonTowerData"))
            collider.radius = tower.range + PlayerPrefs.GetInt("CanonTowerRange");
        else if (tower.data == GameManager.Resource.Load<TowerData>("Data/MageTowerData"))
            collider.radius = tower.range + PlayerPrefs.GetInt("MageTowerRange");
    }

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
