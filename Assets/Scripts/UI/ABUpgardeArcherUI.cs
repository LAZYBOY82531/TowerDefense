using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABUpgardeArcherUI : InGameUI
{
    public ArcherTower3Upgrade tower;
    public int upgradeTowerLV;

    protected override void Awake()
    {
        base.Awake();

        buttons["Block"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<InGameUI>(this); });
        buttons["Aupgrade"].onClick.AddListener(() => { AUpgradeArcherTower(); });
        buttons["Bupgrade"].onClick.AddListener(() => { BUpgradeArcherTower(); });
        buttons["Sell"].onClick.AddListener(() => { SellTower(); });
    }

    public void AUpgradeArcherTower()
    {
        TowerData archerTowerData = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        if (GameManager.Data.UseCoin(archerTowerData.towers[upgradeTowerLV + 1].buildCost))
        {
            tower.UpgradeTowerA(archerTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildArcher");
        }
    }

    public void BUpgradeArcherTower()
    {
        TowerData archerTowerData = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        if (GameManager.Data.UseCoin(archerTowerData.towers[upgradeTowerLV + 3].buildCost))
        {
            tower.UpgradeTowerB(archerTowerData);
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
