using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgardeArcherUI : InGameUI
{
    public ArcherTowerUpgrade tower;
    public int upgradeTowerLV;

    protected override void Awake()
    {
        base.Awake();

        buttons["Block"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<InGameUI>(this); });
        buttons["Upgrade"].onClick.AddListener(() => { UpgradeArcherTower(); });
        buttons["Sell"].onClick.AddListener(() => { SellTower(); });
    }

    public void UpgradeArcherTower()
    {
        TowerData archerTowerData = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        if (GameManager.Data.UseCoin(archerTowerData.towers[upgradeTowerLV].buildCost))
        {
           tower.UpgradeTower(archerTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildArcher");
        }
    }

    public void SellTower()
    {
        tower.SellTower();
        GameManager.UI.CloseInGameUI<InGameUI>(this);
    }
}
