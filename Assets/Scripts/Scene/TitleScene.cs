using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    public void GoStageSelect()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.Scene.LoadScene("StageSelect");
    }

    public void Setting()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.UI.OpenPopUpUI("UI/TitlePopUpUI");
    }

    protected override IEnumerator LoadingRoutine()
    {
        progress = 0.0f;
        yield return null;
        progress = 1.0f;
    }
}
