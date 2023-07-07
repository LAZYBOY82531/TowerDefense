using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    [SerializeField] int howlingCooltime;
    [SerializeField] LayerMask debuffMask;
    private Animator anim;
    private EnemyController enemyController;
    private EnemyMover enemyMover;
    private Coroutine howling;
    float timetime = 0;
    private GameObject Auror;
    public ArcherTower archertower;
    bool isDead;
    bool isAuror;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
        enemyMover = GetComponent<EnemyMover>();
        enemyController.OnDied.AddListener(() => { if (isAuror) { GameManager.Pool.Release(Auror); isDead = true; } });
    }

    private void Start()
    {
        StartCoroutine(HowlingRoutine());
    }

    IEnumerator HowlingRoutine()
    {
        while (true)
        {
            if (!isDead)
            {
                timetime += Time.deltaTime;
                if (timetime > howlingCooltime)
                {
                    if (!enemyController.isTarget)
                    {
                        anim.SetTrigger("Howl");
                        GameManager.Sound.Play("Sound/WolfHowl", SoundManager.Sound.Effect);
                        isAuror = true;
                        Auror = GameManager.Pool.Get<GameObject>(GameManager.Resource.Load<GameObject>("Prefab/Auror"), gameObject.transform.position, gameObject.transform.rotation);
                        Collider[] colliders = Physics.OverlapSphere(transform.position, 2000, debuffMask);
                        foreach (Collider collider in colliders)
                        {
                            Tower tower = collider.gameObject.GetComponent<Tower>();
                            tower?.Debuff();

                            UnitController unit = collider.gameObject.GetComponent<UnitController>();
                            unit?.Debuff();
                        }
                        enemyController.isTarget = true;
                        yield return new WaitForSeconds(3f);
                        if (!isDead)
                            GameManager.Pool.Release(Auror);
                        enemyController.isTarget = false;
                        isAuror = false;
                        timetime = 0;
                    }
                }
            }
            yield return null;
        }
    }
}
