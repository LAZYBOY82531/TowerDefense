using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Continue"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); GameManager.UI.ClosePopUpUI(); });
        buttons["Setting"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); GameManager.UI.OpenPopUpUI("UI/ConfigPopUpUI"); });
        buttons["Exit"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); GameManager.Scene.LoadScene("Title"); });
    }
}
