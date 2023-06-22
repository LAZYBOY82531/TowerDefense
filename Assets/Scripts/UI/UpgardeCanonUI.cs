using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgardeCanonUI : InGameUI
{
    public CanonTowerUpgrade tower;
    public int upgradeTowerLV;

    protected override void Awake()
    {
        base.Awake();

        buttons["Block"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<InGameUI>(this); });
        buttons["Upgrade"].onClick.AddListener(() => { UpgradeCanonTower(); });
        buttons["Sell"].onClick.AddListener(() => { SellTower(); });
    }

    public void UpgradeCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        if (GameManager.Data.UseCoin(canonTowerData.towers[upgradeTowerLV + 1].buildCost))
        {
            tower.UpgradeTower(canonTowerData);
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
