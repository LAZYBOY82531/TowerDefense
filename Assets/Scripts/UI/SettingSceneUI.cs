using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingSceneUI : SceneUI
{
    public UnityEvent Onbuttoncolor;
    public UnityEvent Offbuttoncolor;
    public Button button;

    protected override void Awake()
    {
        base.Awake();

        Time.timeScale = 1f;
        buttons["FasterButton"].onClick.AddListener(() => { Faster(); });
        buttons["VolumeButton"].onClick.AddListener(() => { Debug.Log("Volume"); });
        buttons["SettingButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
    }

    public void OpenPausePopUpUI()
    {
        GameManager.UI.OpenPopUpUI("UI/SettingPopUpUI");
    }

    public void Faster()
    {
        ColorBlock colorBlock = buttons["FasterButton"].colors;
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 2f;
            colorBlock.normalColor = Color.gray;
            colorBlock.selectedColor = Color.gray;
            button.colors = colorBlock;
        }
        else if (Time.timeScale == 2f)
        {
            Time.timeScale = 1f;
            colorBlock.normalColor = Color.white;
            colorBlock.selectedColor = Color.white;
            button.colors = colorBlock;
        }
    }
}
