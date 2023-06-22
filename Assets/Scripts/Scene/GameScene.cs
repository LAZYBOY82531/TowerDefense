using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override IEnumerator LoadingRoutine()
    {
        GameManager.Pool.Awake();
        GameManager.UI.StartScene();
        progress = 0f;
        Debug.Log("���� �� ����");
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.2f;
        Debug.Log("���� �� ����");
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.4f;
        Debug.Log("�÷��̾� ��ġ");
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.7f;
        Debug.Log("���� �� ����");

        yield return new WaitForSecondsRealtime(1f);
        progress = 1f;
    }

    public void GoStageSelect()
    {
        GameManager.Scene.LoadScene("StageSelect");
    }
}
