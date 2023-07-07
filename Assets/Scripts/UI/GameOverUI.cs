using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject player;
    public CameraController controller;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        controller = player?.GetComponent<CameraController>();
        Time.timeScale = 1;
        controller.enabled = false;
    }

    public void GoTitle()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.Scene.LoadScene("Title");
        GameManager.Data.Heart = 2000;
        gameObject.SetActive(false);
    }

    public void Retry()
    {
        GameManager.Sound.Play("Sound/ClickUI", SoundManager.Sound.UIS);
        GameManager.Scene.LoadScene(SceneManager.GetActiveScene());
        GameManager.Data.Heart = 2000;
        gameObject.SetActive(false);
    }
}
