using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMovement : MonoBehaviour {

    private float arrowSpeed = 30f; //Speed of the projectile
    private Transform mainCharacter; //The main character to follows
    private Vector3 positionCharacter;//Get the position of the minion
    private int band = 0;
    int jefe;

    void Start() {
        jefe = BossMovement.vidJ;
    }
    void Awake()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter").transform; //look for target as soon as bullet spawns 
    }
    void Update()
    { 
        if(jefe <= 5)
        {
            arrowSpeed = 45f;
        }
        if (mainCharacter != null)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            if (band == 0)
            {
                rigidbody.velocity = transform.forward * arrowSpeed * Time.deltaTime;
            }
            else if (band == 1)
            {
                transform.Rotate(Vector3.up);
                //rigidbody.velocity = transform.Rotate(Vector3.up) * arrowSpeed;
            }
            positionCharacter = mainCharacter.transform.position - transform.position;//To get the direction of the minion
            positionCharacter = positionCharacter.normalized;//To make the movement of the minion smooth
            transform.Translate(positionCharacter * arrowSpeed * Time.deltaTime, Space.World);//Move the minion toward the main character
        }

        jefe = BossMovement.vidJ;

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        { //If the player is pressing the attack key 
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "ShootToLeft")
        {
            band = 0;
        }
        else if (col.gameObject.tag == "ShootToRight")
        {
            band = 1;
        }
    }
}
