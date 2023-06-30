using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScrollViewUI : BaseUI
{
    private int usedPoint;

    protected override void Awake()
    {
        base.Awake();
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


        texts["ArcherTowerDamage"].text = PlayerPrefs.GetInt("ArcherTowerDamage").ToString();
        texts["ArcherTowerAttackDelay"].text = PlayerPrefs.GetInt("ArcherTowerAttackDelay").ToString();
        texts["ArcherTowerRange"].text = PlayerPrefs.GetInt("ArcherTowerRange").ToString();
        texts["CanonTowerDamage"].text = PlayerPrefs.GetInt("CanonTowerDamage").ToString();
        texts["CanonTowerAttackDelay"].text = PlayerPrefs.GetInt("CanonTowerAttackDelay").ToString();
        texts["CanonTowerRange"].text = PlayerPrefs.GetInt("CanonTowerRange").ToString();
        texts["MageTowerDamage"].text = PlayerPrefs.GetInt("MageTowerDamage").ToString();
        texts["MageTowerAttackDelay"].text = PlayerPrefs.GetInt("MageTowerAttackDelay").ToString();
        texts["MageTowerRange"].text = PlayerPrefs.GetInt("MageTowerRange").ToString();
        texts["SoldierDamage"].text = PlayerPrefs.GetInt("SoldierDamage").ToString();
        texts["SoldierHP"].text = PlayerPrefs.GetInt("SoldierHP").ToString();
        texts["SoldierAttackDelay"].text = PlayerPrefs.GetInt("SoldierAttackDelay").ToString();
    }

    private void Update()
    {
        usedPoint = PlayerPrefs.GetInt("ArcherTowerDamage") + PlayerPrefs.GetInt("ArcherTowerAttackDelay") + PlayerPrefs.GetInt("ArcherTowerRange") +
            PlayerPrefs.GetInt("CanonTowerDamage") + PlayerPrefs.GetInt("CanonTowerAttackDelay") + PlayerPrefs.GetInt("CanonTowerRange") +
            PlayerPrefs.GetInt("MageTowerDamage") + PlayerPrefs.GetInt("MageTowerAttackDelay") + PlayerPrefs.GetInt("MageTowerRange") +
            PlayerPrefs.GetInt("SoldierDamage") + PlayerPrefs.GetInt("SoldierHP") + PlayerPrefs.GetInt("SoldierAttackDelay");
    }


}
