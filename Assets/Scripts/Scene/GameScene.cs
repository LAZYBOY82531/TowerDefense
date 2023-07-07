using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{

    protected override IEnumerator LoadingRoutine()
    {
        Debug.Log("TitleScene Load");
        progress = 0.0f;
        GameManager.UI.StartScene();
        yield return null;
        progress = 1.0f;
        Debug.Log("TitleScene Loaded");
    }

    public void GoStageSelect()
    {
        GameManager.Scene.LoadScene("StageSelect");
    }
}
