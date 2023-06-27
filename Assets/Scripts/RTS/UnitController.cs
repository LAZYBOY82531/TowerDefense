using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
	[SerializeField] private GameObject unitMarker;
	private	NavMeshAgent navMeshAgent;
	public GameObject uc;
	public RTSUnitController rts;
	public int damage;
	public float attackDelay;
	public float attackRange;
	

    private void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		uc = GameObject.FindGameObjectWithTag("UnitControlSystem");
        rts = uc.GetComponent<RTSUnitController>();
		rts.UnitList.Add(this);
    }

	public void SelectUnit()
	{
		unitMarker.SetActive(true);
	}

	public void DeselectUnit()
	{
		unitMarker.SetActive(false);
	}

	public void MoveTo(Vector3 end)
	{
		navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(end);
        StartCoroutine(MoveToCoroutine(end));
	}

	IEnumerator MoveToCoroutine(Vector3 end)
	{
		while (true)
		{
			if (Vector3.Distance(transform.position, end) < 0.5f)
            {
                navMeshAgent.enabled = false;
				yield break;
            }
			yield return null;
        }
	}
}

