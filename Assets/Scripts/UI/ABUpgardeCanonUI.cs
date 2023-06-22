using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABUpgardeCanonUI : InGameUI
{
    public CanonTower3Upgrade tower;
    public int upgradeTowerLV;

    protected override void Awake()
    {
        base.Awake();

        buttons["Block"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<InGameUI>(this); });
        buttons["Aupgrade"].onClick.AddListener(() => { AUpgradeCanonTower(); });
        buttons["Bupgrade"].onClick.AddListener(() => { BUpgradeCanonTower(); });
        buttons["Sell"].onClick.AddListener(() => { SellTower(); });
    }

    public void AUpgradeCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        if (GameManager.Data.UseCoin(canonTowerData.towers[upgradeTowerLV + 1].buildCost))
        {
            tower.UpgradeTowerA(canonTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildCanon");
        }
    }

    public void BUpgradeCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        if (GameManager.Data.UseCoin(canonTowerData.towers[upgradeTowerLV + 3].buildCost))
        {
            tower.UpgradeTowerB(canonTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildCanon");
        }
    }

    public void SellTower()
    {
        tower.SellTower();
        GameManager.UI.CloseInGameUI<InGameUI>(this);
    }
}
