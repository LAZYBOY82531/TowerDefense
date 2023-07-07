using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ConfigPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Upgrade"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); GameManager.UI.OpenPopUpUI("UI/UpgradeTowerAndUnitUI"); });
        buttons["Title"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); Time.timeScale = 1f; GameManager.UI.ClosePopUpUI(); GameManager.Scene.LoadScene("Title");});
        buttons["Cancel"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); GameManager.UI.ClosePopUpUI(); });
    }
}
