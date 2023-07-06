using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private int heart = 2000;
    private int coin = 2000;
    public int nowWave = 1;
    public int Heart { get { return heart; } set { heart = value; } }
    public int Coin { get { return coin; } set { coin = value; } }
    public int NowWave { get { return nowWave; } set { nowWave = value; } }

    public bool UseCoin(int cost)
    {
        if(Coin - cost >= 0)
        {
            GameManager.Sound.Play("Sound/UseCoin", SoundManager.Sound.Effect, 1f);
            Coin -= cost;
            return true;
        }
        else
        {
            GameManager.Sound.Play("Sound/DontDoThat", SoundManager.Sound.Effect, 1f);
            return false;
        }
    }

    public void LoseHeart()
    {
        heart--;
        if(heart <= 0)
        {
            GameManager.Sound.Play("Sound/LoseHP", SoundManager.Sound.Effect, 1f);
            GameManager.Scene.gameOverUI.gameObject.SetActive(true);
        }
    }

}
