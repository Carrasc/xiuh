using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Animator animator;
    public float startShooting;
    public float shootWait;
    public GameObject arrows;
    public Transform shotSpawn;

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

            Instantiate(arrows, shotSpawn.position, shotSpawn.rotation);
            yield return new WaitForSeconds(shootWait);

        }

        //Rigidbody rigidbody = GetComponent<Rigidbody> ();//Create the object
        //rigidbody.velocity = transform.forward * speed;//To enable to move the objects
    }
}
