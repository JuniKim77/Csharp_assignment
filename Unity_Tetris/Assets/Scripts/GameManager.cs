using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverPanel;
    public float fallCycle { get; set; }
    public int addBlocsCycle { get; set; }
    public int level = 1;
    public Text levelText;
    public int score = 0;
    public Text scoreText;
    public int nextLevelUp = 10;
    public Text levelUpText;
    public AudioSource background;
    public GameObject pause;
    public GameObject play;
    public GameObject musicOff;
    public GameObject musicOn;
    public GameObject pausePanel;
    public GeneralValues generalValues { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        generalValues = GameObject.Find("GeneralValues").GetComponent<GeneralValues>();
        levelUpText.enabled = false;
        nextLevelUp = 100;
        score = 0;
        level = 1;
        Time.timeScale = 1.0f;
        gameoverPanel.SetActive(false);
        background = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        musicOn.SetActive(false);
        play.SetActive(false);
        pausePanel.SetActive(false);
        fallCycle = 1.0f;
        addBlocsCycle = 2000;
        if (generalValues.difficulty == 1)
        {
            addBlocsCycle = 30;
        }
        else if (generalValues.difficulty == 2)
        {
            addBlocsCycle = 24;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText()
    {
        levelText.text = $"{level}";
        scoreText.text = $"{score}";
    }
    public void LevelUp()
    {
        if (fallCycle > 0.2f)
        {
            fallCycle -= 0.2f;
        }
        
        nextLevelUp += 100;
        ++level;
        if (level % 3 == 0 && addBlocsCycle > 3)
        {
            addBlocsCycle -= 3;
        }
        levelUpText.enabled = true;
        levelUpText.GetComponent<Animator>().SetTrigger("Level Up");
    }
    public void IncreseScore(int num)
    {
        score += num * 10;
        if (score >= nextLevelUp)
        {
            LevelUp();
        }
        UpdateText();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverPanel.SetActive(true);
    }

    public void MusicOn()
    {
        background.Play();
        musicOn.SetActive(false);
        musicOff.SetActive(true);
    }
    public void MusicOff()
    {
        background.Stop();
        musicOn.SetActive(true);
        musicOff.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        play.SetActive(true);
        pause.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void Play()
    {
        Time.timeScale = 1;
        play.SetActive(false);
        pause.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void OpenHome()
    {
        SceneManager.LoadScene("InitScene");
    }
}
