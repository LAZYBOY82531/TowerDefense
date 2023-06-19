using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Save"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
        buttons["Cancel"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
    }
}
