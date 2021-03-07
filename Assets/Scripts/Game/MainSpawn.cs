using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSpawn : MonoBehaviour
{
    public Transform[] spwnpoint;
    public GameObject player;
    GameObject activePlayer;
    int playerLives = 6;
    static int lives = 6;
    private string Menu = "Menu"; //If the character dies he will be sent to the menu screen
    int jefe;
    Scene nivel;

    public Text livesText;
    public Text BossLife;
    public string Scene;

    void Start()
    {
        Cursor.visible = false;
        //location = LoadBoss.lvl;
        nivel = SceneManager.GetActiveScene();
        jefe = BossMovement.vidJ;
        BossStatus(jefe);
        Score();
    }

    void Update()
    {
        StartCoroutine(WaitSpawn());

        if (lives == 0)
        {
            lives = 6;
            SceneManager.LoadScene(Menu);
        }

        jefe = BossMovement.vidJ;
        BossStatus(jefe);
    }
    // Update is called once per frame
    public void SpawnPlayer()
    {
        playerLives--;
        Score();
        activePlayer = Instantiate(player, spwnpoint[0].position, spwnpoint[0].rotation);
    }

    public void Score()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void BossStatus(int vida)
    {
        if (nivel.name == "BossQuetzal" || nivel.name == "BossLv2")
            BossLife.text = "Boss Life: " + vida.ToString();
       // else 
           // BossLife.text = "";
    }

    public void RestartScene()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        lives--;
    }

    IEnumerator WaitSpawn() //Waits a couple seconds before it respawns the main Character
    {
        yield return new WaitForSeconds(2f);
        if (activePlayer == null && playerLives >= 0)
        {
            if (playerLives == 4)
            {
                RestartScene();
            }

            SpawnPlayer();
            playerLives--;
        }
    }
}
