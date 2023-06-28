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
    private GameObject ggggg;

    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/Barrack");
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
        unit1.SetActive(true);
        unitC1.resetPoision = unitSponPoint.position;
        unitC1.idlePoint = unit1IdlePoint;
        unitC1.MoveTo(unit1IdlePoint);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(unitResponDelay);
        anim.SetBool("IsOpen", true);
        yield return new WaitForSeconds(0.5f);
        unit2.SetActive(true);
        unitC2.resetPoision = unitSponPoint.position;
        unitC2.idlePoint = unit2IdlePoint;
        unitC2.MoveTo(unit2IdlePoint);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(unitResponDelay);
        anim.SetBool("IsOpen", true);
        yield return new WaitForSeconds(0.5f);
        unit3.SetActive(true);
        unitC3.resetPoision = unitSponPoint.position;
        unitC3.idlePoint = unit3IdlePoint;
        unitC3.MoveTo(unit3IdlePoint);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsOpen", false);
    }
}
