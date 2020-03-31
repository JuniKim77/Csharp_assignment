using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class StartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1200, true);
        Advertisement.Initialize("3456158", false);
    }

    private void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ads Success");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ads Skip");
                break;
            case ShowResult.Failed:
                Debug.Log("Ads Fail");
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        ShowRewardedAd();
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
