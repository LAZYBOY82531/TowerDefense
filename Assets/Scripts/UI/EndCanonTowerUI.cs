using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EndCanonTowerUI : InGameUI
{
    public CanonTowerUpgradeEnd tower;
    public int upgradeTowerLV;

    protected override void Awake()
    {
        base.Awake();

        buttons["Block"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<InGameUI>(this); });
        buttons["Change"].onClick.AddListener(() => { ChangeCanonTower(); });
        buttons["Sell"].onClick.AddListener(() => { SellTower(); });
    }

    public void ChangeCanonTower()
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
