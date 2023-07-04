using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPoint : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private List<EnemyMover> EnemyList = new List<EnemyMover>();
    private List<Transform> Waypoint = new List<Transform>();
    private Transform enemys;
    public bool isendWave = true;
    [SerializeField] float enemySpawnTime = 3;
    [SerializeField] int WaveEnemyCount = 30;
    [SerializeField] int enemyCount = 30;
    [SerializeField] UnityEvent endWave;
    [SerializeField] GameObject guide1;
    [SerializeField] GameObject guide2;
    [SerializeField] GameObject guide3;
    private IEnumerator WaveStart;
    bool isGuide;


    private void Awake()
    {
        var childs = transform.Find("WayList").GetComponentsInChildren<Transform>();
        foreach (var child in childs)
        {
            if (!child.name.Contains("Point")) continue;
            Waypoint.Add(child);
        }

        CreateEnemy(enemyCount);
    }

    private void Start()
    {
        WaveStart = StartWave();
    }

    public void ChangeSpawnTime(float time)
    {
        enemySpawnTime = time;
    }

    public void ChangeEnemyCount(int count)
    {
        WaveEnemyCount = count;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void CreateEnemy(int count)
    {
        if (enemys == null)
        {
            var obj = new GameObject();
            obj.name = "Enemys";
            obj.transform.parent = transform;
            enemys = obj.transform;
        }

        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(EnemyPrefab, Waypoint[0].position, Waypoint[0].rotation);
            if (obj == null) return;

            obj.name = "Enemy" + i;
            obj.transform.parent = enemys;
            obj.SetActive(false);
            EnemyList.Add(obj.GetComponent<EnemyMover>());
        }
    }

    public void StartWaveFunction()
    {
        WaveStart = StartWave();
        StartCoroutine(WaveStart);
    }

    IEnumerator StartWave()
    {
        if (!isGuide)
        {
            guide1.transform.position = Waypoint[0].position;
            guide2.transform.position = Waypoint[0].position;
            guide3.transform.position = Waypoint[0].position;
            WayGuide wayGuide1 = guide1.gameObject.GetComponent<WayGuide>();
            WayGuide wayGuide2 = guide2.gameObject.GetComponent<WayGuide>();
            WayGuide wayGuide3 = guide3.gameObject.GetComponent<WayGuide>();
            wayGuide1.GetWayPoints(Waypoint);
            yield return new WaitForSeconds(3);
            wayGuide2.GetWayPoints(Waypoint);
            yield return new WaitForSeconds(3);
            wayGuide3.GetWayPoints(Waypoint);
            yield return new WaitForSeconds(5);
            isGuide = true;
        }
        isendWave = false;
        float tTime = 0;
        int index = 0;
        while (WaveEnemyCount >= index)
        {
            tTime += Time.deltaTime;
            if (tTime > enemySpawnTime)
            {
                tTime = 0;
                ++index;
                MakeEnemy();
            }
            if (WaveEnemyCount == index)
            {
                isendWave = true;
                endWave?.Invoke();
                break;
            }
            yield return null;
        }
    }

    private void MakeEnemy()
    {
        var obj = FindNoUseEnemy();
        if (obj == null)
            return;

        obj.GetWayPoints(Waypoint);
        return;
    }

    private EnemyMover FindNoUseEnemy()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i].gameObject.activeSelf)
                continue;
            return EnemyList[i];
        }
        return null;
    }
}
