using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["ResetAll"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); PlayerPrefs.DeleteAll(); });
        buttons["Sound"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); GameManager.UI.OpenPopUpUI("UI/AudioMixerUI"); });
        buttons["Close"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); GameManager.UI.ClosePopUpUI(); });
    }
}
