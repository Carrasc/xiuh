//Luis Fernando Carrasco A01021172
//Daniel Pelagio Vazquez A0122
//Alexandro Francisco Marcelo A01021383

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    private Transform mainCharacter; //The main character to follows
    private int Bosslife = 10;
    public static int vidJ = 10;
    public float speed = 15f; //Boss speed 
    private Vector3 positionCharacter;//Get the position of the minion
    public string scene; //The scene to load if the character kills the boss

    // Use this for initialization
    void Start()
    {
        StartCoroutine(WaitSearch());
    }

    void Update()
    {
        if (Bosslife <= 5)
            speed = 30f;

        if (mainCharacter != null)
        {
            Vector3 angle = transform.rotation.eulerAngles;
            vidJ = Bosslife;

            positionCharacter = mainCharacter.transform.position - transform.position;//To get the direction of the minion
            positionCharacter = positionCharacter.normalized;//To make the movement of the minion smooth
            transform.Translate(positionCharacter * speed * Time.deltaTime, Space.World);//Move the minion toward the main character

            if (angle.y == 0 && mainCharacter.transform.position.x < transform.position.x)
            {
                transform.Rotate(0, 180, 0);
            }
            else if (angle.y == 180 && mainCharacter.transform.position.x > transform.position.x)
                transform.Rotate(0, -180, 0);
        }
    }

    void OnCollisionStay(Collision collision) //Function to make sure the character is on the ground
    {

        if (collision.gameObject.tag == ("PlatformBoss"))
        { //
          //ban = false;
            transform.Translate(Vector3.up * 2, Space.World);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        //If the enemy is the boss
        if (col.gameObject.tag == "sword")
        {
            Bosslife = Bosslife - 1;            
            if (Bosslife == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(scene);
            }
        }
    }

    IEnumerator WaitSearch() //The minions wait to search for the mainCharacter until he spawns, float value need to be a little bit more than in the mainSpawn script value
    {
        yield return new WaitForSeconds(2.2f);
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter").transform;
        vidJ = Bosslife;
    }

}
