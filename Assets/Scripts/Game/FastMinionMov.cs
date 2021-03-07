using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastMinionMov : MonoBehaviour {//Code for the minions that follows and kill the player

    private Transform mainCharacter; //The main character to follows
                                   

    private float speed = 30f; //Minion speed
    private Vector3 positionCharacter;//Get the position of the minion
                                     

    void Start()
    {
        StartCoroutine(WaitSearch());
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Beyond")
        {
            Destroy(gameObject);
            
        }
    }

    void Update()
    {
        if (mainCharacter != null)
        {
            Vector3 angle = transform.rotation.eulerAngles;
            positionCharacter = mainCharacter.transform.position - transform.position;//To get the direction of the minion
            positionCharacter = positionCharacter.normalized;//To make the movement of the minion smooth

            if (angle.y == 0 && (mainCharacter.transform.position.x < transform.position.x))
            {
                transform.Rotate(0, 180, 0);
            }
            else if (angle.y == 180 && (mainCharacter.transform.position.x > transform.position.x))
                transform.Rotate(0, -180, 0);


            transform.Translate(positionCharacter * speed * Time.deltaTime, Space.World);//Move the minion toward the main character
        }

    }

    IEnumerator WaitSearch() //The minions wait to search for the mainCharacter until he spawns, float value need to be a little bit more than in the mainSpawn script value
    {
        yield return new WaitForSeconds(2.2f);
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }
}
