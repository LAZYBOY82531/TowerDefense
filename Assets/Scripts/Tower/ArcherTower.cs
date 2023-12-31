using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField] Transform archer;
    [SerializeField] Transform arrowPoint;
    [SerializeField] AudioSource arrowsound;

    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        range = data.towers[element].range;
        attackdelay = data.towers[element].delay - (PlayerPrefs.GetInt("ArcherTowerAttackDelay") * 0.1f);
    }

    private void OnEnable()
    {
        StartCoroutine(LookRoutine());
        StartCoroutine(AttackRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (enemyList.Count > 0)
            {
                Attack(enemyList[0]);
                yield return new WaitForSeconds(attackdelay);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Attack(EnemyController enemy)
    {
        arrowsound.Play();
        Arrow arrow = GameManager.Pool.Get<Arrow>(GameManager.Resource.Load<Arrow>("Tower/Arrow"), arrowPoint.position, arrowPoint.rotation);
        arrow.SetTarget(enemy);
        arrow.SetDamage(data.towers[element].damage + PlayerPrefs.GetInt("ArcherTowerDamage"));
    }

    IEnumerator LookRoutine()
    {
        while (true)
        {
            if(enemyList.Count > 0)
            {
                archer.LookAt(enemyList[0].transform.position);
            }

            yield return null;  
        }
    }

    public override void Debuff()
    {
        base.Debuff();
    }
}
