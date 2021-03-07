using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingSword : MonoBehaviour {

    Collider swordCollider; //The box collider of the sword
	public Animator anima;
    private bool cooldown = false; //cooldown for the sword throw
    private bool cooldownAttack = false; //cooldown for the main attack
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;

    void Start () {
		anima = GetComponent<Animator> ();
        swordCollider = GetComponent<Collider>();
    }

	void Update ()
    {
        Vector3 angle = transform.rotation.eulerAngles;
        if (cooldownAttack == true || cooldown == true) //Only activate the collider of the sword when he is attacking
        {
            swordCollider.enabled = true;
        }
        else
            swordCollider.enabled = false; 

        if (Input.GetButton("Fire1") && cooldownAttack == false)
        {
            anima.Play("SwordAttack");
            AudioSource1.Play();
            cooldownAttack = true;
            StartCoroutine(AttackWait());
        }
        

        if (Input.GetButton("Fire2") && cooldown == false)
        {
            anima.Play("SwordThrow");
            AudioSource2.Play();
            cooldown = true;
            StartCoroutine(SwordWait());
        }
    }

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "minion") 
        {
            Destroy(col.gameObject);
        }

        //If the enemy is the boss
    }

    IEnumerator SwordWait()
    {
        yield return new WaitForSeconds(2.0f); //cooldown sword throw 
        cooldown = false;
    }

    IEnumerator AttackWait() //cooldown main attack
    {
        yield return new WaitForSeconds(0.2f); //amount of time to starts spawning feaders
        cooldownAttack = false;
    }


}
