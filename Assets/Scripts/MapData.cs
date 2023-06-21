using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MapData : MonoBehaviour
{
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
