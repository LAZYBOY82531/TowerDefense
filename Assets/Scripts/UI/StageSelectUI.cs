using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    public void OpenUpgradePopUpUI()
    {
        GameManager.UI.OpenPopUpUI("UI/UpgradeTowerAndUnitUI");
    }
}
