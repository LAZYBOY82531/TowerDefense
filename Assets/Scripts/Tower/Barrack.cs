using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Tower
{
    [SerializeField] int unitHealth;
    [SerializeField] int unitResponDelay;
    [SerializeField] Transform unitSponPoint;
    [SerializeField] Transform unitPoision1;
    [SerializeField] Transform unitPoision2;
    [SerializeField] Transform unitPoision3;
    [SerializeField] UnitController unit1;
    [SerializeField] UnitController unit2;
    [SerializeField] UnitController unit3;
    private Animator anim;
    private TowerData towerData;

    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/Barrack");
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(SponSoldier());
    }

    IEnumerator SponSoldier()
    {
        anim.SetBool("IsOpen", true);

        yield return new WaitForSeconds(1f);


    }
}
