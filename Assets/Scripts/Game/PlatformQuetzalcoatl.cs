using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformQuetzalcoatl : MonoBehaviour {

    Animator animator;
    public float start;
    public float restart;
    public GameObject platform;

    void Start()
    {
        StartCoroutine(SpawnShoots());
    }

    void update()
    {

    }

    IEnumerator SpawnShoots()
    {
        yield return new WaitForSeconds(start); //amount of time to starts spawning feaders
        while (true)
        {
            

            yield return new WaitForSeconds(restart);

        }

        //Rigidbody rigidbody = GetComponent<Rigidbody> ();//Create the object
        //rigidbody.velocity = transform.forward * speed;//To enable to move the objects
    }
}
