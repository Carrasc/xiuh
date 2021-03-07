using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuetzalcoatlShoot : MonoBehaviour {

    Animator animator;
    public float startShooting;
    public float shootWait;
    public GameObject arrows;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;

    void Start()
    {
        StartCoroutine(SpawnShoots());
    }

    void update()
    {

    }

    IEnumerator SpawnShoots()
    {
        yield return new WaitForSeconds(startShooting); //amount of time to starts spawning feaders
        while (true)
        {

            Instantiate(arrows, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(arrows, shotSpawn2.position, shotSpawn2.rotation);
            Instantiate(arrows, shotSpawn3.position, shotSpawn3.rotation);

            yield return new WaitForSeconds(shootWait);

        }

        //Rigidbody rigidbody = GetComponent<Rigidbody> ();//Create the object
        //rigidbody.velocity = transform.forward * speed;//To enable to move the objects
    }
}
