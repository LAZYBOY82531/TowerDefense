using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private IEnumerator end;
    int range = 10;

    private void Start()
    {
        end = End();
    }

    private void OnEnable()
    {
        end = End();
        StartCoroutine(end);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Pool.Release(this);
    }
}
