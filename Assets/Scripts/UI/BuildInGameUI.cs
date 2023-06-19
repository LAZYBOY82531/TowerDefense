using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    public TowerPlace towerPlace;

    protected override void Awake()
    {
        base.Awake();

        buttons["Block"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI<InGameUI>(this); });
        buttons["Archer"].onClick.AddListener(() => { BuildArcherTower(); });
        buttons["Canon"].onClick.AddListener(() => { BuildCanonTower(); });
    }

    public void BuildArcherTower()
    {
        TowerData archerTowerData = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        if (GameManager.Data.UseCoin(archerTowerData.towers[0].buildCost))
        {
            towerPlace.BuildTower(archerTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildArcher");
        }
    }

    public void BuildCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        if (GameManager.Data.UseCoin(canonTowerData.towers[0].buildCost))
        {
            towerPlace.BuildTower(canonTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildCanon");
        }
    }
}
