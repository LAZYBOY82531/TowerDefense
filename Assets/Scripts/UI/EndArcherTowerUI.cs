using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndArcherTowerUI : InGameUI
{
    public ArcherTowerUpgradeEnd tower;
    public int upgradeTowerLV;

    protected override void Awake()
    {
        base.Awake();

        buttons["Block"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<InGameUI>(this); });
        buttons["Change"].onClick.AddListener(() => { ChangeArcherTower(); });
        buttons["Sell"].onClick.AddListener(() => { SellTower(); });
    }

    public void ChangeArcherTower()
    {
        tower.ChangeTower();
        GameManager.UI.CloseInGameUI<InGameUI>(this);
    }

    public void SellTower()
    {
        tower.SellTower();
        GameManager.UI.CloseInGameUI<InGameUI>(this);
    }
}
