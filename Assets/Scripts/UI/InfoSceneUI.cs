using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        texts["HeartText"].text = GameManager.Data.Heart.ToString();
        texts["CoinText"].text = GameManager.Data.Coin.ToString();
    }
}
