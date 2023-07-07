using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMixerPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Close"].onClick.AddListener(() => { GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS); GameManager.UI.ClosePopUpUI(); });
    }
}
