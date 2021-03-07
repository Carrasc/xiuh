//Luis Fernando Carrasco A01021172
//Daniel Pelagio Vazquez A0122
//Alexandro Francisco Marcelo A01021383

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementPrin : MonoBehaviour
{
    Animator animator;
    public Rigidbody rb;
    private float movement = 60f; //Speed on the x axis 
    private float jumpSpeed = 160f; //The speed is for the jump hight
    private bool jump; //Variable to know if the player is jumping
    float abism = -120f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void OnCollisionStay(Collision collision) //Function to make sure the character is on the ground
    {

        if ((collision.gameObject.tag == ("Floor") && jump == true) || collision.gameObject.tag == ("PlatformBoss"))//If he is on the ground, make the variable jump false so that it can jump
        {
            jump = false;
            animator.SetBool("jump", false);
        }
    }

    void OnCollisionExit(Collision collision) //When the character stops touching the ground, make the variable true so that it can not jump on the air
    {
        jump = true;
    }

    void FixedUpdate()
    {

        if (Input.GetAxisRaw("Vertical") > 0 && jump == false)
        { //Only jump when you are in the ground
            animator.SetBool("jump", true);
        }

        if (Input.GetAxisRaw("Horizontal") > 0 || (Input.GetAxisRaw("Horizontal")) < 0)
        {
            animator.SetBool("walk", true);
        }

        else if ((Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0) && Input.GetAxisRaw("Vertical") > 0 && jump == false) {
            animator.SetBool("jump", true);
            animator.SetBool("walk", false );    
        }

        if ((Input.GetAxisRaw("Horizontal") > 0) == false && Input.GetAxisRaw("Horizontal") < 0 == false)
        {
            animator.SetBool("walk", false);
        }


        Vector3 pos = transform.position;
        Vector3 angle = transform.rotation.eulerAngles;

        if (angle.y == 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
                transform.Rotate(0, 180, 0);
        }

        else if (angle.y == 180)
        {
            if (Input.GetAxis("Horizontal") > 0)
                transform.Rotate(0, -180, 0);
        }

        if (pos.y < abism)//If it falls into the abism, it dies
        {
            
            Destroy(gameObject);
            Debug.Log("You have fallen into the abism, -1");
        }

        if ((Input.GetAxisRaw("Vertical")) > 0 && jump == false)
        { //Only jump when you are in the ground
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse); //We use AddForce, so the object doesnt teleport, also speed so it jumps higher that the gravity force
        }
        else if (Input.GetAxisRaw("Horizontal")>0)
        {
            transform.position = movement * Time.deltaTime * Vector3.right + transform.position;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
            transform.position = movement * Time.deltaTime * Vector3.left + transform.position;
        
    }
}
