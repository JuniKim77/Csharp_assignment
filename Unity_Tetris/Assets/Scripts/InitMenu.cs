using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitMenu : MonoBehaviour
{
    public GameObject OptionMenu;
    public GameObject[] GameType = new GameObject[2];
    public GameObject[] Difficulty = new GameObject[3];
    public GameObject generalValues;

    public int gameType { get; set; }
    public int difficulty { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1200, true);
        OptionMenu.SetActive(false);
        GameType[gameType].GetComponent<Image>().color = Color.gray;
        Difficulty[difficulty].GetComponent<Image>().color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        generalValues = GameObject.Find("GeneralValues");
        if (generalValues == null)
        {
            generalValues = new GameObject("GeneralValues");
            generalValues.AddComponent<GeneralValues>();
        }
        gameType = generalValues.GetComponent<GeneralValues>().gameType;
        difficulty = generalValues.GetComponent<GeneralValues>().difficulty;
    }

    public void SetGameType(int index)
    {
        GameType[gameType].GetComponent<Image>().color = GameType[(gameType + 1) % 2].GetComponent<Image>().color;
        gameType = index;
        GameType[gameType].GetComponent<Image>().color = Color.gray;
        generalValues.GetComponent<GeneralValues>().gameType = index;
    }
    public void SetDifficulty(int index)
    {
        Difficulty[difficulty].GetComponent<Image>().color = Difficulty[(difficulty + 1) % 3].GetComponent<Image>().color;
        difficulty = index;
        Difficulty[difficulty].GetComponent<Image>().color = Color.gray;
        generalValues.GetComponent<GeneralValues>().difficulty = index;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OpenOption()
    {
        OptionMenu.SetActive(true);
    }
    public void CloseOption()
    {
        OptionMenu.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
