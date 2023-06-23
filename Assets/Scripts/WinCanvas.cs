using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvas : MonoBehaviour
{
    private Animator anim;
    private IEnumerator End;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        End = EndGame();
    }


    private void OnEnable()
    {
        StartCoroutine(End);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        if (GameManager.Data.Heart == 20)
        {
            PlayerPrefs.SetInt("Stage1Score", 3);
            anim.SetBool("Gold", true);
        }
        else if (GameManager.Data.Heart > 10)
        {
            if (PlayerPrefs.HasKey("Stage1Score"))
            {
                if(PlayerPrefs.GetInt("Stage1Score") < 2)
                {
                    PlayerPrefs.SetInt("Stage1Score", 2);
                }
            }
            else
            {
                PlayerPrefs.SetInt("Stage1Score", 2);
            }
            anim.SetBool("Silver", true);
        }
        else
        {
            if (PlayerPrefs.HasKey("Stage1Score"))
            {
                PlayerPrefs.SetInt("Stage1Score", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Stage1Score", 1);
            }
            anim.SetBool("Bronze", true);
        }
    }

    public void GoTitle()
    {
        GameManager.Scene.LoadScene("Title");
    }

    public void Continue()
    {
        GameManager.Scene.LoadScene("Stage1");
    }

    public void NextScene()
    {

    }
}
