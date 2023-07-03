using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    [SerializeField] int howlingCooltime;
    private Animator anim;
    private EnemyController enemyController;
    private EnemyMover enemyMover;
    private Coroutine howling;
    float timetime = 0;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
        enemyMover = GetComponent<EnemyMover>();
    }

    private void Start()
    {
        StartCoroutine(HowlingRoutine());
    }

    IEnumerator HowlingRoutine()
    {
        while (true)
        {
            timetime += Time.unscaledDeltaTime;
            if(timetime > howlingCooltime)
            {
                if (!enemyController.isTarget)
                {
                    anim.SetTrigger("Howl");
                    Time.timeScale = 0.5f;
                    enemyController.isTarget = true;
                    yield return new WaitForSeconds(3f);
                    enemyController.isTarget = false;
                    StartCoroutine(DebuffRoutine());
                    timetime = 0;
                    yield break;
                }
            }
            yield return null;
        }
    }

    IEnumerator DebuffRoutine()
    {
        while(true)
        {

            float time2 = 0;
            time2 += Time.unscaledDeltaTime;
            if (time2 > 15f)
            {

            }
        }
    }
}
