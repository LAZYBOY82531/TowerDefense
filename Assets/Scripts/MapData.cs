using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MapData : MonoBehaviour
{
    [SerializeField] int waitTime;
    public int heart;
    [SerializeField] int coin;
    [SerializeField] int endwave;
    [SerializeField] UnityEvent Wave1;
    [SerializeField] UnityEvent Wave2;
    [SerializeField] UnityEvent Wave3;
    [SerializeField] UnityEvent Wave4;
    [SerializeField] UnityEvent Wave5;
    [SerializeField] UnityEvent WaveEnd;



    private void Awake()
    {
        GameManager.Data.Heart = heart;
        GameManager.Data.Coin = coin;
        GameManager.Data.NowWave = 1;
    }

    private void Start()
    {
        StartCoroutine(Wave1Start());
    }

    

    public void NextWave()
    {
        GameManager.Data.NowWave += 1;

        if(GameManager.Data.NowWave == endwave)
        {
            StartCoroutine(ClearGame());

        }

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
            case 5:
                StartCoroutine(Wave5Start());
                break;
            default:
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
    IEnumerator Wave5Start()
    {
        yield return new WaitForSeconds(waitTime);
        Wave5?.Invoke();
    }

    IEnumerator ClearGame()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(2f);
        WaveEnd?.Invoke();
        yield return null;
    }
}
