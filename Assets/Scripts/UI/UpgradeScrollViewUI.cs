using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScrollViewUI : PopUpUI
{
    private int stagesPoint;
    private int remindePoint;
    private int usedPoint;
    private int stagescore1;
    private int stagescore2;

    protected override void Awake()
    {
        base.Awake();
        buttons["Close"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("ArcherTowerDamage"))
            PlayerPrefs.SetInt("ArcherTowerDamage", 0);
        if (!PlayerPrefs.HasKey("ArcherTowerAttackDelay"))
            PlayerPrefs.SetInt("ArcherTowerAttackDelay", 0);
        if (!PlayerPrefs.HasKey("ArcherTowerRange"))
            PlayerPrefs.SetInt("ArcherTowerRange", 0);
        if (!PlayerPrefs.HasKey("CanonTowerDamage"))
            PlayerPrefs.SetInt("CanonTowerDamage", 0);
        if (!PlayerPrefs.HasKey("CanonTowerAttackDelay"))
            PlayerPrefs.SetInt("CanonTowerAttackDelay", 0);
        if (!PlayerPrefs.HasKey("CanonTowerRange"))
            PlayerPrefs.SetInt("CanonTowerRange", 0);
        if (!PlayerPrefs.HasKey("MageTowerDamage"))
            PlayerPrefs.SetInt("MageTowerDamage", 0);
        if (!PlayerPrefs.HasKey("MageTowerAttackDelay"))
            PlayerPrefs.SetInt("MageTowerAttackDelay", 0);
        if (!PlayerPrefs.HasKey("MageTowerRange"))
            PlayerPrefs.SetInt("MageTowerRange", 0);
        if (!PlayerPrefs.HasKey("SoldierDamage"))
            PlayerPrefs.SetInt("SoldierDamage", 0);
        if (!PlayerPrefs.HasKey("SoldierHP"))
            PlayerPrefs.SetInt("SoldierHP", 0);
        if (!PlayerPrefs.HasKey("SoldierAttackDelay"))
            PlayerPrefs.SetInt("SoldierAttackDelay", 0);
        if (PlayerPrefs.HasKey("Stage1Score"))
            stagescore1 = PlayerPrefs.GetInt("Stage1Score");
        else 
            stagescore1 = 0;
        if (PlayerPrefs.HasKey("Stage2Score"))
            stagescore2 = PlayerPrefs.GetInt("Stage2Score");
        else 
            stagescore2 = 0;
    }

    private void Update()
    {
        usedPoint = PlayerPrefs.GetInt("ArcherTowerDamage") + PlayerPrefs.GetInt("ArcherTowerAttackDelay") + PlayerPrefs.GetInt("ArcherTowerRange") +
            PlayerPrefs.GetInt("CanonTowerDamage") + PlayerPrefs.GetInt("CanonTowerAttackDelay") + PlayerPrefs.GetInt("CanonTowerRange") +
            PlayerPrefs.GetInt("MageTowerDamage") + PlayerPrefs.GetInt("MageTowerAttackDelay") + PlayerPrefs.GetInt("MageTowerRange") +
            PlayerPrefs.GetInt("SoldierDamage") + PlayerPrefs.GetInt("SoldierHP") + PlayerPrefs.GetInt("SoldierAttackDelay");
        stagesPoint = stagescore1 + stagescore2;
        remindePoint = stagesPoint - usedPoint;
        texts["TotalCount"].text = stagesPoint.ToString();
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
}
