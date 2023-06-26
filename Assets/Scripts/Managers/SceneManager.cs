using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    private BaseScene curScene;
    private LoadingUI loadingUI;
    public GameOverUI gameOverUI;

    public BaseScene CurScene
    {
        get
        {
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();

            return curScene;
        }
    }
    private void Awake()
    {
        LoadingUI ui = Resources.Load<LoadingUI>("UI/LoadingUI");
        loadingUI = Instantiate(ui);
        loadingUI.transform.SetParent(transform, false);

        GameOverUI GGui = Resources.Load<GameOverUI>("UI/GameOverUI");
        gameOverUI = Instantiate(GGui);
        gameOverUI.transform.SetParent(transform, false);
    }

    public static string GetActiveScene()
    {
        return UnitySceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        loadingUI.FadeOut();
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;

        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);

        while(!oper.isDone)
        {
            loadingUI.SetProgress(oper.progress);
            yield return null;
        }
        CurScene.LoadAsync();
        Time.timeScale = 1f;
        loadingUI.FadeIn();
        yield return new WaitForSeconds(1f);
    }
}