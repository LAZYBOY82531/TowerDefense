using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private void Start()
    {
        StartCoroutine(BGMRoutine());
    }

    IEnumerator BGMRoutine()
    {
        yield return new WaitForSeconds(1);
        GameManager.Sound.Play("Sound/StageBGM", SoundManager.Sound.Bgm);
    }

    protected override IEnumerator LoadingRoutine()
    {
        Debug.Log("TitleScene Load");
        progress = 0.0f;
        GameManager.UI.StartScene();
        yield return null;
        progress = 1.0f;
        Debug.Log("TitleScene Loaded");
    }

    public void StopBGM()
    {
        GameManager.Sound.StopBGM();
    }

    public void GoStageSelect()
    {
        GameManager.Scene.LoadScene("StageSelect");
    }
}
