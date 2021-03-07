using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "minion" || col.gameObject.tag == "Boss" || col.gameObject.tag == "Invin")
		{ 
            Destroy(gameObject);
        }
    }
}
