using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndWave : MonoBehaviour
{
    [SerializeField] SpawnPoint spawnPoint1;
    [SerializeField] SpawnPoint spawnPoint2;
    [SerializeField] SpawnPoint spawnPoint3;
    [SerializeField] SpawnPoint spawnPoint4;
    [SerializeField] UnityEvent clearWave;
    private Collider[] colliders;
    public bool point1End;
    public bool point2End;
    public bool point3End;
    public bool point4End;

    private bool isstartcorutine = true;
    public void Wave()
    {
        if (spawnPoint1 == true)
            point1End = spawnPoint1.isendWave;
        else
            point1End = true;
        if (spawnPoint2 == true)
            point2End = spawnPoint2.isendWave;
        else
        point2End= true;
        if (spawnPoint3 == true)
            point3End = spawnPoint3.isendWave;
        else
            point3End = true;
        if (spawnPoint4 == true)
           point4End = spawnPoint4.isendWave;
        else
            point4End = true;
        if(point1End == true && point2End == true && point3End == true && point4End == true)
        {
            if (isstartcorutine)
            {
                StartCoroutine(WaveEnd());
                isstartcorutine = false;
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator WaveEnd()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            colliders = Physics.OverlapSphere(transform.position, 1000, LayerMask.GetMask("Enemy"));
            if (colliders.Length == 0 )
            {
                isstartcorutine = true;
                clearWave?.Invoke();
                yield break;
            }
        }
    }
}
