using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject[] respawnSpot = new GameObject[4];

    public GameObject monster1Prefab;
    public GameObject monster2Prefab;

    private GameObject monsterPrefab;
    // Start is called before the first frame update
    private float lastSpawnTime;
    private int spawnCount = 0;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        monsterPrefab = monster1Prefab;
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.round <= gameManager.totalRound)
        {
            float timeGap = Time.time - lastSpawnTime;
            if (((spawnCount == 0 && timeGap > gameManager.roundReadyTime)
                || timeGap > gameManager.spawnTime) 
                && spawnCount < gameManager.spawnNumber)
            {
                lastSpawnTime = Time.time;
                int respawnSpotNumber = Random.Range(0, 4);
                Instantiate(monsterPrefab, respawnSpot[respawnSpotNumber].transform.position, Quaternion.identity);
                ++spawnCount;
            }
            if (spawnCount == gameManager.spawnNumber &&
                GameObject.FindGameObjectWithTag("Monster") == null)
            {
                if (gameManager.totalRound == gameManager.round)
                {
                    gameManager.gameClear();
                    gameManager.round++;
                    return;
                }
                gameManager.clearRound();
                spawnCount = 0;
                lastSpawnTime = Time.time;

                if (gameManager.round == 4)
                {
                    monsterPrefab = monster2Prefab;
                }
            }
        }
    }
}
