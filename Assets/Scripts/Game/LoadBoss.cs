using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBoss : MonoBehaviour {

    public string Scene; //Scene name to load after touching the door

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mainCharacter") //If the mainCharacter touches the door
        {
            //int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(Scene);
        }
    }
}
