//Luis Fernando Carrasco A01021172
//Daniel Pelagio Vazquez A0122
//Alexandro Francisco Marcelo A01021383

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniomMovement : MonoBehaviour
{
    public float speed = 15f;

    void Update()
    {/*
        Vector3 angle = transform.rotation.eulerAngles;
        if (speed > 0)
        {
                transform.Rotate(0, -180, 0);
        }

        else if (speed < 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0, -180, 0);
        }*/

        Vector3 angle = transform.rotation.eulerAngles;

        if (angle.y == 0 && speed < 0)
        {
            transform.Rotate(0, 180, 0);
        }
        else if (angle.y == 180 && speed > 0)
            transform.Rotate(0, -180, 0);

        transform.position =  Vector3.right * speed * Time.deltaTime + transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Limit")
        {
            speed = speed * -1;
        }
    }
}

