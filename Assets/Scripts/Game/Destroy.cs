using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public float destroyTime = 2.0f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
