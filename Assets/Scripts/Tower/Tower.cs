using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData data;
    public float range;
    public int element;
    protected List<EnemyController> enemyList;
    protected float attackdelay;
    private GameObject Auror;
    float timetime = 0;

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

    public virtual void Debuff()
    {
        Auror = GameManager.Pool.Get<GameObject>(GameManager.Resource.Load<GameObject>("Prefab/Auror"), gameObject.transform.position, gameObject.transform.rotation);
        attackdelay *= 2;
        StartCoroutine(DebuffRoutine());
    }

    IEnumerator DebuffRoutine()
    {
        while (true)
        {
            timetime += Time.deltaTime;
            if (timetime > 15f)
            {
                timetime = 0;
                attackdelay /= 2;
                GameManager.Pool.Release(Auror);
                yield break;
            }
            yield return null;
        }
    }
}
