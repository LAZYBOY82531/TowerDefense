using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvas : MonoBehaviour
{
    private Animator anim;
    private IEnumerator End;
    private GameObject gameObject;
    [SerializeField] MapData mapdata;
    private GameObject player;
    [SerializeField] CameraController controller;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        End = EndGame();
        gameObject = GameObject.FindGameObjectWithTag("MapData");
        mapdata = gameObject.GetComponent<MapData>();
        player = GameObject.FindGameObjectWithTag("CineMachine");
        controller = player?.GetComponent<CameraController>();
    }


    private void OnEnable()
    {
        StartCoroutine(End);
    }

    IEnumerator EndGame()
    {
        controller.enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (GameManager.Data.Heart == mapdata.heart)
        {
            PlayerPrefs.SetInt("Stage1Score", 3);
            anim.SetBool("Gold", true);
        }
        else if (GameManager.Data.Heart >= mapdata.heart/2 - 0.5f)
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
