using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Continue"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["Setting"].onClick.AddListener(() => { GameManager.UI.OpenPopUpUI("UI/ConfigPopUpUI"); });
        buttons["Exit"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
    }
}
