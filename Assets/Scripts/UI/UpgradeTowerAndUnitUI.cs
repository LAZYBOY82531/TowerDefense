using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowerAndUnitUI : BaseUI
{
    private int stagesPoint;
    private int usedPoint;

    protected override void Awake()
    {
        base.Awake();
        stagesPoint = PlayerPrefs.GetInt("Stage1Score") + PlayerPrefs.GetInt("Stage2Score");
        usedPoint = PlayerPrefs.GetInt("ArcherTowerDamage") + PlayerPrefs.GetInt("ArcherTowerAttackDelay") + PlayerPrefs.GetInt("ArcherTowerRange") +
            PlayerPrefs.GetInt("CanonTowerDamage") + PlayerPrefs.GetInt("CanonTowerAttackDelay") + PlayerPrefs.GetInt("CanonTowerRange") +
            PlayerPrefs.GetInt("MageTowerDamage") + PlayerPrefs.GetInt("MageTowerAttackDelay") + PlayerPrefs.GetInt("MageTowerRange") +
            PlayerPrefs.GetInt("SoldierDamage") + PlayerPrefs.GetInt("SoldierHP") + PlayerPrefs.GetInt("SoldierAttackDelay");
        buttons["ArcherTowerDamageButton"].onClick.AddListener(() => { ArcherTowerDamage(); });
        buttons["ArcherTowerAttackDelayButton"].onClick.AddListener(() => { ArcherTowerAttackDelay(); });
        buttons["ArcherTowerRangeButton"].onClick.AddListener(() => { ArcherTowerRange(); });
        buttons["CanonTowerDamageButton"].onClick.AddListener(() => { CanonTowerDamage(); });
        buttons["CanonTowerAttackDelayButton"].onClick.AddListener(() => { CanonTowerAttackDelay(); });
        buttons["CanonTowerRangeButton"].onClick.AddListener(() => { CanonTowerRange(); });
        buttons["MageTowerDamageButton"].onClick.AddListener(() => { MageTowerDamage(); });
        buttons["MageTowerAttackDelayButton"].onClick.AddListener(() => { MageTowerAttackDelay(); });
        buttons["MageTowerRangeButton"].onClick.AddListener(() => { MageTowerRange(); });
        buttons["SoldierDamageButton"].onClick.AddListener(() => { SoldierDamage(); });
        buttons["SoldierHPButton"].onClick.AddListener(() => { SoldierHP(); });
        buttons["SoldierAttackDelayButton"].onClick.AddListener(() => { SoldierAttackDelay(); });
    }

    private void Update()
    {
        usedPoint = PlayerPrefs.GetInt("ArcherTowerDamage") + PlayerPrefs.GetInt("ArcherTowerAttackDelay") + PlayerPrefs.GetInt("ArcherTowerRange") +
            PlayerPrefs.GetInt("CanonTowerDamage") + PlayerPrefs.GetInt("CanonTowerAttackDelay") + PlayerPrefs.GetInt("CanonTowerRange") +
            PlayerPrefs.GetInt("MageTowerDamage") + PlayerPrefs.GetInt("MageTowerAttackDelay") + PlayerPrefs.GetInt("MageTowerRange") +
            PlayerPrefs.GetInt("SoldierDamage") + PlayerPrefs.GetInt("SoldierHP") + PlayerPrefs.GetInt("SoldierAttackDelay");

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

    private void ArcherTowerDamage()
    {
        if(stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("ArcherTowerDamage") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("ArcherTowerDamage", PlayerPrefs.GetInt("ArcherTowerDamage") + 1);
            }
            texts["ArcherTowerDamage"].text = PlayerPrefs.GetInt("ArcherTowerDamage").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void ArcherTowerAttackDelay()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("ArcherTowerAttackDelay") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("ArcherTowerAttackDelay", PlayerPrefs.GetInt("ArcherTowerAttackDelay") + 1);
            }
            texts["ArcherTowerAttackDelay"].text = PlayerPrefs.GetInt("ArcherTowerAttackDelay").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }

    private void ArcherTowerRange()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("ArcherTowerRange") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("ArcherTowerRange", PlayerPrefs.GetInt("ArcherTowerRange") + 1);
            }
            texts["ArcherTowerRange"].text = PlayerPrefs.GetInt("ArcherTowerRange").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void CanonTowerDamage()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("CanonTowerDamage") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("CanonTowerDamage", PlayerPrefs.GetInt("CanonTowerDamage") + 1);
            }
            texts["CanonTowerDamage"].text = PlayerPrefs.GetInt("CanonTowerDamage").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void CanonTowerAttackDelay()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("CanonTowerAttackDelay") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("CanonTowerAttackDelay", PlayerPrefs.GetInt("CanonTowerAttackDelay") + 1);
            }
            texts["CanonTowerAttackDelay"].text = PlayerPrefs.GetInt("CanonTowerAttackDelay").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void CanonTowerRange()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("CanonTowerRange") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("CanonTowerRange", PlayerPrefs.GetInt("CanonTowerRange") + 1);
            }
            texts["CanonTowerRange"].text = PlayerPrefs.GetInt("CanonTowerRange").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void MageTowerDamage()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("MageTowerDamage") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("MageTowerDamage", PlayerPrefs.GetInt("MageTowerDamage") + 1);
            }
            texts["MageTowerDamage"].text = PlayerPrefs.GetInt("MageTowerDamage").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void MageTowerAttackDelay()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("MageTowerAttackDelay") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("MageTowerAttackDelay", PlayerPrefs.GetInt("MageTowerAttackDelay") + 1);
            }
            texts["MageTowerAttackDelay"].text = PlayerPrefs.GetInt("MageTowerAttackDelay").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void MageTowerRange()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("MageTowerRange") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("MageTowerRange", PlayerPrefs.GetInt("MageTowerRange") + 1);
            }
            texts["MageTowerRange"].text = PlayerPrefs.GetInt("MageTowerRange").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void SoldierDamage()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("SoldierDamage") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("SoldierDamage", PlayerPrefs.GetInt("SoldierDamage") + 1);
            }
            texts["SoldierDamage"].text = PlayerPrefs.GetInt("SoldierDamage").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void SoldierHP()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("SoldierHP") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("SoldierHP", PlayerPrefs.GetInt("SoldierHP") + 1);
            }
            texts["SoldierHP"].text = PlayerPrefs.GetInt("SoldierHP").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
    private void SoldierAttackDelay()
    {
        if (stagesPoint - usedPoint - 1 >= 0)
        {
            if (PlayerPrefs.GetInt("SoldierAttackDelay") < 5)
            {
                GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
                PlayerPrefs.SetInt("SoldierAttackDelay", PlayerPrefs.GetInt("SoldierAttackDelay") + 1);
            }
            texts["SoldierAttackDelay"].text = PlayerPrefs.GetInt("SoldierAttackDelay").ToString();
        }
        else
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
    }
}
