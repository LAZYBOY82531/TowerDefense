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
            Coin -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LoseHeart()
    {
        heart--;
        if(heart <= 0)
        {
            GameManager.Scene.gameOverUI.gameObject.SetActive(true);
        }
    }

}
