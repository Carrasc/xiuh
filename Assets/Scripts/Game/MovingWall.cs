using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {

    private float speed = 15f;
  

    void Update()
    {
        transform.position = speed * Time.deltaTime * Vector3.up + transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beyond")
            speed = ((speed + 60f) * -1);
        else if (other.gameObject.tag == "Floor")
            speed = ((speed + 60f) * -1);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "mainCharacter")
            Destroy(other.gameObject);
    }
}
