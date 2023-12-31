using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTowerCons : Tower
{
    private void Awake()
    {
        data = GameManager.Resource.Load<TowerData>("Data/MageTowerData");
    }

    private void Start()
    {
        StartCoroutine(BuildMageTower());
    }

    IEnumerator BuildMageTower()
    {
        yield return new WaitForSeconds(data.towers[element+1].buildTime);
        GameManager.Resource.Destroy(gameObject);
        GameManager.Resource.Instantiate(data.towers[element+1].tower, transform.position, transform.rotation);
    }
}
