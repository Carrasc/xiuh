using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeMove : MonoBehaviour {

    public float speed = 15f;

    void Update()
    {
        Vector3 angle = transform.rotation.eulerAngles;

        transform.Rotate(0, 0, 10 );
        //angle.x = angle.x + 10;

        if (angle.y == 0 && speed < 0)
        {
            transform.Rotate(0, 180, 0);
        }
        else if (angle.y == 180 && speed > 0)
            transform.Rotate(0, -180, 0);

        transform.position = Vector3.right * speed * Time.deltaTime + transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Limit")
        {
            speed = speed * -1;
        }
    }
}
