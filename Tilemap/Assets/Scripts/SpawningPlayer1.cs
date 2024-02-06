//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawningPlayer1 : MonoBehaviour
{
    public GameObject Panel;
    public Text win;
    public Text score;
    int sc = -1;
    public bool playerIsDead = true;
    public GameObject[] spawnPoints;
    public GameObject[] Characters;

    public static SpawningPlayer1 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sc == 10)
        {
            Panel.SetActive(true);
            Time.timeScale = 0.0f;
            win.text = "Player 2 Wins";
        }
        if (playerIsDead)
        {
            sc++;
            score.text = "Player2 Score: " + sc;
            int randomSpawn = Random.Range(0, 4);
            int randomChar = Random.Range(0, 4);
            Instantiate(Characters[randomChar], spawnPoints[randomSpawn].transform.position, Quaternion.identity);
            playerIsDead = false;
        }
    }
    public void OnMainMenu()
    {
        
        SceneManager.LoadScene(0);
        
    }

}
