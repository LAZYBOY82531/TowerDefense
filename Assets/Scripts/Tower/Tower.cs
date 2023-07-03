using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData data;
    public float range;
    public int element;
    protected List<EnemyController> enemyList;

    protected virtual void Awake()
    {
        enemyList = new List<EnemyController>();
    }

    public void AddEnemy(EnemyController enemy)
    {
        enemyList.Add(enemy);
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        enemyList.Remove(enemy);
    }
}
