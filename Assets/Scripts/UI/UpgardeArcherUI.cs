using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgardeArcherUI : InGameUI
{
    public ArcherTowerUpgrade tower;

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
        if (GameManager.Data.UseCoin(archerTowerData.towers[0].buildCost))
        {
            //towerPlace.BuildTower(archerTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildArcher");
        }
    }

    public void SellTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        if (GameManager.Data.UseCoin(canonTowerData.towers[0].buildCost))
        {
            //towerPlace.BuildTower(canonTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildCanon");
        }
    }
}
