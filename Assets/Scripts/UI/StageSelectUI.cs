using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    public void OpenUpgradePopUpUI()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.UI.OpenPopUpUI("UI/UpgradeTowerAndUnitUI");
    }
}
