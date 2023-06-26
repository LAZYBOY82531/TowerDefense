using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : BaseScene
{
    protected override IEnumerator LoadingRoutine()
    {
        GameManager.Pool.Awake();
        GameManager.UI.StartScene();
        progress = 0f;
        Debug.Log("·£´ý ¸Ê »ý¼º");
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.2f;
        Debug.Log("·£´ý ¸Ê »ý¼º");
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.4f;
        Debug.Log("ÇÃ·¹ÀÌ¾î ¹èÄ¡");
        yield return new WaitForSecondsRealtime(1f);
        progress = 0.7f;
        Debug.Log("·£´ý ¸Ê »ý¼º");

        yield return new WaitForSecondsRealtime(1f);
        progress = 1f;
    }

    public void GoStage1()
    {
        GameManager.Scene.LoadScene("Stage1");
    }

    public void GoStage2()
    {
        GameManager.Scene.LoadScene("Stage2");
    }

    public void GoTitle()
    {
        GameManager.Scene.LoadScene("Title");
    }
}
