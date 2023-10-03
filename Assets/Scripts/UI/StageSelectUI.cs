using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(BGMRoutine());
    }

    IEnumerator BGMRoutine()
    {
        yield return new WaitForSeconds(1);
        GameManager.Sound.Play("Sound/TitleBGM", SoundManager.Sound.Bgm);
    }

    public void OpenUpgradePopUpUI()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.UI.OpenPopUpUI("UI/UpgradeTowerAndUnitUI");
    }
}
