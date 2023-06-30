using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Tower
{
    [SerializeField] int unitHealth;
    [SerializeField] int unitResponDelay;
    [SerializeField] GameObject unit1;
    [SerializeField] GameObject unit2;
    [SerializeField] GameObject unit3;
    public Transform unitSponPoint;
    private UnitController unitC1;
    private UnitController unitC2;
    private UnitController unitC3;
    private Vector3 unit1IdlePoint;
    private Vector3 unit2IdlePoint;
    private Vector3 unit3IdlePoint;
    private Animator anim;
    private List<GameObject> groundLists;
    private Vector3 idlePosition;
    private float shortDis;

    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/BarrackTowerData");
        anim = GetComponent<Animator>();
        unitC1 = unit1.GetComponent<UnitController>();
        unitC2 = unit2.GetComponent<UnitController>();
        unitC3 = unit3.GetComponent<UnitController>();
    }

    private void Start()
    {
        groundLists = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ground"));
        shortDis = Vector3.Distance(gameObject.transform.position, groundLists[0].transform.position);
        foreach (GameObject go in groundLists)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, go.transform.position);
            if (Distance < shortDis)
            {
                idlePosition = go.transform.position;
                shortDis = Distance;
            }
        }
        unit1IdlePoint = new Vector3(idlePosition.x, idlePosition.y, idlePosition.z + 2);
        unit2IdlePoint = new Vector3(idlePosition.x - 2f, idlePosition.y, idlePosition.z - 1f);
        unit3IdlePoint = new Vector3(idlePosition.x + 2f, idlePosition.y, idlePosition.z - 1f);
        StartCoroutine(SponSoldier());
    }

    IEnumerator SponSoldier()
    {
        anim.SetBool("IsOpen", true);
        yield return new WaitForSeconds(0.5f);
        unitC1.damage = data.towers[element].damage;
        unitC1.attackDelay = data.towers[element].delay;
        unitC1.attackRange = data.towers[element].range;
        unitC1.resetPoision = unitSponPoint.position;
        unitC1.idlePoint = unit1IdlePoint;
        unit1.SetActive(true);
        unitC1.MoveTo(unit1IdlePoint);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(unitResponDelay);
        anim.SetBool("IsOpen", true);
        yield return new WaitForSeconds(0.5f);
        unitC2.damage = data.towers[element].damage;
        unitC2.attackDelay = data.towers[element].delay;
        unitC2.attackRange = data.towers[element].range;
        unitC2.resetPoision = unitSponPoint.position;
        unitC2.idlePoint = unit2IdlePoint;
        unit2.SetActive(true);
        unitC2.MoveTo(unit2IdlePoint);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(unitResponDelay);
        anim.SetBool("IsOpen", true);
        yield return new WaitForSeconds(0.5f);
        unitC3.damage = data.towers[element].damage;
        unitC3.attackDelay = data.towers[element].delay;
        unitC3.attackRange = data.towers[element].range;
        unitC3.resetPoision = unitSponPoint.position;
        unitC3.idlePoint = unit3IdlePoint;
        unit3.SetActive(true);
        unitC3.MoveTo(unit3IdlePoint);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsOpen", false);
        yield break;
    }

    public void ResponSoldier(GameObject solider)
    {
        StartCoroutine(ResponSoldierRoutine(solider));
    }

    IEnumerator ResponSoldierRoutine(GameObject soldier)
    {
        UnitController soldiercon = soldier.GetComponent<UnitController>();
        yield return new WaitForSeconds(unitResponDelay);
        soldier.SetActive(true);
        soldiercon.MoveTo(soldiercon.idlePoint);
    }
}
