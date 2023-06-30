using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowerAndUnitUI : BaseUI
{
    private int stagesPoint;
    private int usedPoint;
    private int remindePoint;

    protected override void Awake()
    {
        base.Awake();
        stagesPoint = PlayerPrefs.GetInt("Stage1Score") + PlayerPrefs.GetInt("Stage2Score");
        usedPoint = PlayerPrefs.GetInt("ArcherTowerDamage") + PlayerPrefs.GetInt("ArcherTowerAttackDelay") + PlayerPrefs.GetInt("ArcherTowerRange") +
            PlayerPrefs.GetInt("CanonTowerDamage") + PlayerPrefs.GetInt("CanonTowerAttackDelay") + PlayerPrefs.GetInt("CanonTowerRange") +
            PlayerPrefs.GetInt("MageTowerDamage") + PlayerPrefs.GetInt("MageTowerAttackDelay") + PlayerPrefs.GetInt("MageTowerRange") +
            PlayerPrefs.GetInt("SoldierDamage") + PlayerPrefs.GetInt("SoldierHP") + PlayerPrefs.GetInt("SoldierAttackDelay");
        remindePoint = stagesPoint - usedPoint;
        texts["UpgradeCount"].text = remindePoint.ToString();
        texts["TotalCount"].text = stagesPoint.ToString();
        buttons["ArcherTowerDamage"].onClick.AddListener(() => { ArcherTowerDamage(); });
        buttons["ArcherTowerAttackDelay"].onClick.AddListener(() => { ArcherTowerAttackDelay(); });
        buttons["ArcherTowerRange"].onClick.AddListener(() => { ArcherTowerRange(); });
        buttons["CanonTowerDamage"].onClick.AddListener(() => { CanonTowerDamage(); });
        buttons["CanonTowerAttackDelay"].onClick.AddListener(() => { CanonTowerAttackDelay(); });
        buttons["CanonTowerRange"].onClick.AddListener(() => { CanonTowerRange(); });
        buttons["MageTowerDamage"].onClick.AddListener(() => { MageTowerDamage(); });
        buttons["MageTowerAttackDelay"].onClick.AddListener(() => { MageTowerAttackDelay(); });
        buttons["MageTowerRange"].onClick.AddListener(() => { MageTowerRange(); });
        buttons["SoldierDamage"].onClick.AddListener(() => { SoldierDamage(); });
        buttons["SoldierHP"].onClick.AddListener(() => { SoldierHP(); });
        buttons["SoldierAttackDelay"].onClick.AddListener(() => { SoldierAttackDelay(); });
    }

    private void Update()
    {
        usedPoint = PlayerPrefs.GetInt("ArcherTowerDamage") + PlayerPrefs.GetInt("ArcherTowerAttackDelay") + PlayerPrefs.GetInt("ArcherTowerRange") +
            PlayerPrefs.GetInt("CanonTowerDamage") + PlayerPrefs.GetInt("CanonTowerAttackDelay") + PlayerPrefs.GetInt("CanonTowerRange") +
            PlayerPrefs.GetInt("MageTowerDamage") + PlayerPrefs.GetInt("MageTowerAttackDelay") + PlayerPrefs.GetInt("MageTowerRange") +
            PlayerPrefs.GetInt("SoldierDamage") + PlayerPrefs.GetInt("SoldierHP") + PlayerPrefs.GetInt("SoldierAttackDelay");
        remindePoint = stagesPoint - usedPoint;
        texts["UpgradeCount"].text = remindePoint.ToString();
    }

    public void ResetUpgrade()
    {
        PlayerPrefs.SetInt("ArcherTowerDamage", 0);
        PlayerPrefs.SetInt("ArcherTowerAttackDelay", 0);
        PlayerPrefs.SetInt("ArcherTowerRange", 0);
        PlayerPrefs.SetInt("CanonTowerDamage", 0);
        PlayerPrefs.SetInt("CanonTowerAttackDelay", 0);
        PlayerPrefs.SetInt("CanonTowerRange", 0);
        PlayerPrefs.SetInt("MageTowerDamage", 0);
        PlayerPrefs.SetInt("MageTowerAttackDelay", 0);
        PlayerPrefs.SetInt("MageTowerRange", 0);
        PlayerPrefs.SetInt("SoldierDamage", 0);
        PlayerPrefs.SetInt("SoldierHP", 0);
        PlayerPrefs.SetInt("SoldierAttackDelay", 0);
    }
    private void ArcherTowerDamage()
    {
        if(PlayerPrefs.GetInt("ArcherTowerDamage") < 5)
            PlayerPrefs.SetInt("ArcherTowerDamage", PlayerPrefs.GetInt("ArcherTowerDamage") + 1);
    }
    private void ArcherTowerAttackDelay()
    {
        if (PlayerPrefs.GetInt("ArcherTowerAttackDelay") < 5)
            PlayerPrefs.SetInt("ArcherTowerAttackDelay", PlayerPrefs.GetInt("ArcherTowerAttackDelay") + 1);
    }

    private void ArcherTowerRange()
    {
        if (PlayerPrefs.GetInt("ArcherTowerRange") < 5)
            PlayerPrefs.SetInt("ArcherTowerRange", PlayerPrefs.GetInt("ArcherTowerRange") + 1);
    }
    private void CanonTowerDamage()
    {
        if (PlayerPrefs.GetInt("CanonTowerDamage") < 5)
            PlayerPrefs.SetInt("CanonTowerDamage", PlayerPrefs.GetInt("CanonTowerDamage") + 1);
    }
    private void CanonTowerAttackDelay()
    {
        if (PlayerPrefs.GetInt("CanonTowerAttackDelay") < 5)
            PlayerPrefs.SetInt("CanonTowerAttackDelay", PlayerPrefs.GetInt("CanonTowerAttackDelay") + 1);
    }
    private void CanonTowerRange()
    {
        if (PlayerPrefs.GetInt("CanonTowerRange") < 5)
            PlayerPrefs.SetInt("CanonTowerRange", PlayerPrefs.GetInt("CanonTowerRange") + 1);
    }
    private void MageTowerDamage()
    {
        if (PlayerPrefs.GetInt("MageTowerDamage") < 5)
            PlayerPrefs.SetInt("MageTowerDamage", PlayerPrefs.GetInt("MageTowerDamage") + 1);
    }
    private void MageTowerAttackDelay()
    {
        if (PlayerPrefs.GetInt("MageTowerAttackDelay") < 5)
            PlayerPrefs.SetInt("MageTowerAttackDelay", PlayerPrefs.GetInt("MageTowerAttackDelay") + 1);
    }
    private void MageTowerRange()
    {
        if (PlayerPrefs.GetInt("MageTowerRange") < 5)
            PlayerPrefs.SetInt("MageTowerRange", PlayerPrefs.GetInt("MageTowerRange") + 1);
    }
    private void SoldierDamage()
    {
        if (PlayerPrefs.GetInt("SoldierDamage") < 5)
            PlayerPrefs.SetInt("SoldierDamage", PlayerPrefs.GetInt("SoldierDamage") + 1);
    }
    private void SoldierHP()
    {
        if (PlayerPrefs.GetInt("SoldierHP") < 5)
            PlayerPrefs.SetInt("SoldierHP", PlayerPrefs.GetInt("SoldierHP") + 1);
    }
    private void SoldierAttackDelay()
    {
        if (PlayerPrefs.GetInt("SoldierAttackDelay") < 5)
            PlayerPrefs.SetInt("SoldierAttackDelay", PlayerPrefs.GetInt("SoldierAttackDelay") + 1);
    }
}
