using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MapData : MonoBehaviour
{
    [SerializeField] SpawnPoint spawnPoint1;
    [SerializeField] SpawnPoint spawnPoint2;
    [SerializeField] SpawnPoint spawnPoint3;
    [SerializeField] SpawnPoint spawnPoint4;
    [SerializeField] int waitTime;
    [SerializeField] int heart;
    [SerializeField] int coin;
    [SerializeField] int endwave;
    [SerializeField] UnityEvent Wave1;
    [SerializeField] UnityEvent Wave2;
    [SerializeField] UnityEvent Wave3;
    [SerializeField] UnityEvent Wave4;


    private void Awake()
    {
        GameManager.Data.Heart = heart;
        GameManager.Data.Coin = coin;
        GameManager.Data.EndWave = endwave;
    }

    private void Start()
    {
        StartCoroutine(Wave1Start());
    }

    public void NextWave()
    {
        bool spawnPoint1end;
        bool spawnPoint2end;
        bool spawnPoint3end;
        bool spawnPoint4end;
        if (spawnPoint1 == true)
            spawnPoint1end = spawnPoint1.isendWave;
        else
            spawnPoint1end = true;
        if (spawnPoint2 == true)
            spawnPoint2end = spawnPoint2.isendWave;
        else
            spawnPoint2end = true;
        if (spawnPoint3 == true)
            spawnPoint3end = spawnPoint3.isendWave;
        else
            spawnPoint3end = true;
        if (spawnPoint4 == true)
            spawnPoint4end = spawnPoint4.isendWave;
        else
            spawnPoint4end = true;
        if (spawnPoint1end == true && spawnPoint2end == true && spawnPoint3end == true && spawnPoint4end == true)
        {
            GameManager.Data.NowWave += 1;

            switch (GameManager.Data.NowWave)
            {
                case 2:
                    StartCoroutine(Wave2Start());
                    break;
                case 3:
                    StartCoroutine(Wave3Start());
                    break;
                case 4:
                    StartCoroutine(Wave4Start());
                    break;

            }
        }
    }

    IEnumerator Wave1Start()
    {
        yield return new WaitForSeconds(5);
        Wave1?.Invoke();
    }

    IEnumerator Wave2Start()
    {
        yield return new WaitForSeconds(waitTime);
        Wave2?.Invoke();
    }

    IEnumerator Wave3Start()
    {
        yield return new WaitForSeconds(waitTime);
        Wave3?.Invoke();
    }

    IEnumerator Wave4Start()
    {
        yield return new WaitForSeconds(waitTime);
        Wave4?.Invoke();
    }
}
