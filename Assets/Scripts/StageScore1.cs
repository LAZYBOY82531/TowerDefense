using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScore1 : MonoBehaviour
{
    [SerializeField] GameObject Gold;
    [SerializeField] GameObject Silver;
    [SerializeField] GameObject Bronze;
    [SerializeField] private int score;
    [SerializeField] string scoreName;
    private void Start()
    {
        if (PlayerPrefs.HasKey(scoreName))
        {
            switch (PlayerPrefs.GetInt(scoreName))
            {
                case 1:
                    Bronze.SetActive(true);
                    score = 1;
                    break;
                case 2:
                    Silver.SetActive(true);
                    score = 2;
                    break;
                case 3:
                    Gold.SetActive(true);
                    score = 3;
                    break;
                default:
                    break;
            }
        }
        else
            score = 44;
    }
}
