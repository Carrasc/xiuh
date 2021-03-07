using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camara : MonoBehaviour
{

    public Vector3 myPos;
    public Vector3 deathCam;
    private Transform myPlay; //Move the camera for when the player is dead
    Camera cam;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(WaitSearch());
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlay != null)
        {
            transform.position = myPlay.transform.position + myPos; //Makes the camera follow the player
        }
        else transform.position = deathCam; 

    }

    IEnumerator WaitSearch() //wait to search for the mainCharacter until he spawns, float value need to be a little bit more than in the mainSpawn script value
    {
        yield return new WaitForSeconds(2.00001f);
        myPlay = GameObject.FindGameObjectWithTag("mainCharacter").transform;
    }


}