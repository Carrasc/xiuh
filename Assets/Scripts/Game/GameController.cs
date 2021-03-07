using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float startWave;
    public float waveWait;
    public float spawnWait;
    public GameObject feathers;
    public Vector3 spawnValues;

    void Start()
    {
        StartCoroutine(SpawnFeathers());
    }

    IEnumerator SpawnFeathers()
    {
        yield return new WaitForSeconds(startWave); //amount of time to starts spawning feaders
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); //Posicion donde inicializa el objeto (solo es random en x); //Posicion donde inicializa el objeto (solo es random en x)
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(feathers, spawnPosition, spawnRotation); //Ininialize the object
                yield return new WaitForSeconds(spawnWait); //Use ywield for the IEnumerator 
            }
            yield return new WaitForSeconds(waveWait);
            //break;
        }
    }
}
