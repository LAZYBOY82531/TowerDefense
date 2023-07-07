using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvas : MonoBehaviour
{
    private Animator anim;
    private IEnumerator End;
    private GameObject mapDataObject;
    [SerializeField] int thisStage;
    [SerializeField] MapData mapdata;
    private GameObject player;
    [SerializeField] CameraController controller;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        End = EndGame();
        mapDataObject = GameObject.FindGameObjectWithTag("MapData");
        mapdata = mapDataObject.GetComponent<MapData>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
        controller = player?.GetComponent<CameraController>();
    }


    private void OnEnable()
    {
        StartCoroutine(End);
    }

    IEnumerator EndGame()
    {
        GameManager.Sound.Play("Sound/WinUI");
        controller.enabled = false;
        yield return new WaitForSeconds(1f);
        if (GameManager.Data.Heart == mapdata.heart)
        {
            PlayerPrefs.SetInt("Stage" + thisStage + "Score", 3);
            anim.SetBool("Gold", true);
        }
        else if (GameManager.Data.Heart >= mapdata.heart/2 - 0.5f)
        {
            if (PlayerPrefs.HasKey("Stage" + thisStage + "Score"))
            {
                if(PlayerPrefs.GetInt("Stage" + thisStage + "Score") < 2)
                {
                    PlayerPrefs.SetInt("Stage" + thisStage + "Score", 2);
                }
            }
            else
            {
                PlayerPrefs.SetInt("Stage" + thisStage + "Score", 2);
            }
            anim.SetBool("Silver", true);
        }
        else
        {
            if (PlayerPrefs.HasKey("Stage" + thisStage + "Score"))
            {
                PlayerPrefs.SetInt("Stage" + thisStage + "Score", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Stage" + thisStage + "Score", 1);
            }
            anim.SetBool("Bronze", true);
        }
        yield return new WaitForSeconds(1f);
        GameManager.Sound.Play("Sound/EndMedal");
        yield break;
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
        GameManager.Scene.LoadScene("Stage2");
    }
}
