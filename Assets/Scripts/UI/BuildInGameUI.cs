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
        buttons["Mage"].onClick.AddListener(() => { BuildMageTower(); });
        buttons["Archer"].onClick.AddListener(() => { BuildArcherTower(); });
        buttons["Canon"].onClick.AddListener(() => { BuildCanonTower(); });
        buttons["Barrack"].onClick.AddListener(() => { BuildBarrackTower(); });
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

    public void BuildMageTower()
    {
        TowerData mageTowerData = GameManager.Resource.Load<TowerData>("Data/MageTowerData");
        if (GameManager.Data.UseCoin(mageTowerData.towers[0].buildCost))
        {
            towerPlace.BuildTower(mageTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildMage");
        }
    }

    public void BuildBarrackTower()
    {
        TowerData barrackTowerData = GameManager.Resource.Load<TowerData>("Data/BarrackTowerData");
        if (GameManager.Data.UseCoin(barrackTowerData.towers[0].buildCost))
        {
            towerPlace.BuildTower(barrackTowerData);
            GameManager.UI.CloseInGameUI(this);
        }
        else
        {
            Debug.Log("DonotbuildBarrack");
        }
    }
}
