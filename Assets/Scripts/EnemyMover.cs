using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyMover : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] UnityEvent fullHP;
    public List<Transform> wayPoints = new List<Transform>();
    public int wayPointIndex = 0;
    public bool IsStart = false;
    public float attackRange;
    Coroutine moveRoutine;
    public EnemyController ec;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ec = GetComponent<EnemyController>();
    }

    private void Start()
    {
        StartMove();
    }

    private void OnEnable()
    {
        if (!agent.enabled)
        {
            agent.enabled = true;
        }
        if (IsStart) 
        {
            StartMove();
            IsStart = false;
        }
    }

    public void StartMove()
    {
        agent.destination = wayPoints[wayPointIndex].position;
        moveRoutine = StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, wayPoints[wayPointIndex].position) < 0.1f)
            {
                if (++wayPointIndex < wayPoints.Count)
                {
                    ToNextPoint();
                }
                else
                {
                    this.gameObject.SetActive(false);
                    ResetPosition();    
                    fullHP?.Invoke();
                    GameManager.Data.LoseHeart();
                    yield break;
                }
            }
            yield return null;
        }
    }

    public void ResetPosition()
    {
        transform.position = wayPoints[0].position;
        wayPointIndex = 0;
        IsStart = true;
    }

    private void ToNextPoint()
    {
        if (agent.enabled)
            agent.destination = wayPoints[wayPointIndex].position;
    }

    public void GetWayPoints (List<Transform> get)
    {
        this.wayPoints = get;
        if (wayPoints == null)
            return;
        gameObject.SetActive(true);
    }
    
    public void BattleStart()
    {
        StopCoroutine(moveRoutine);
        agent.enabled = false;
    }

    public void BackPosition()
    {
        agent.enabled = true;
        StartMove();
    }
}

