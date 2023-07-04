using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WayGuide : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();
    public int wayPointIndex = 0;

    private void OnEnable()
    {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointIndex].position, 50 * Time.deltaTime);
            if (Vector3.Distance(transform.position, wayPoints[wayPointIndex].position) < 0.1f)
            {
                if (++wayPointIndex < wayPoints.Count)
                {
                    Debug.Log("nextwave");
                }
                else
                {
                    gameObject.SetActive(false);
                    yield break;
                }
            }
            yield return null;
        }
    }


    public void GetWayPoints(List<Transform> get)
    {
        this.wayPoints = get;
        if (wayPoints == null)
            return;
        gameObject.SetActive(true);
    }
}
