using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : BaseScene
{

    protected override IEnumerator LoadingRoutine()
    {
        Debug.Log("TitleScene Load");
        progress = 0.0f;
        yield return null;
        progress = 1.0f;
        Debug.Log("TitleScene Loaded");
    }

    public void GoStage1()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.Scene.LoadScene("Stage1");
    }

    public void GoStage2()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.Scene.LoadScene("Stage2");
    }

    public void GoTitle()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.Scene.LoadScene("Title");
    }
}
