using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public GameObject playerPrefab;
    public Transform playerPosition;

    protected override IEnumerator LoadingRoutine()
    {
        progress = 0f;
        Debug.Log("���� �� ����");
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.2f;
        Debug.Log("���� �� ����");
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.4f;
        Debug.Log("�÷��̾� ��ġ");
        GameObject player = Instantiate(playerPrefab, playerPosition.position, playerPosition.rotation);
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.7f;
        Debug.Log("���� �� ����");

        yield return new WaitForSecondsRealtime(1f);
        progress = 1f;
    }
}
