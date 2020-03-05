using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public GameObject spawnManager;
    public Transform endMarker = null; // create an empty gameobject and assign in inspector
    public Transform endMarker2 = null;
    public Transform endMarker3 = null;
    public Transform endMarker4 = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void moveCameraOver()
    {
        if(spawnManager.GetComponent<SpawnManager>()._currentWave == 0)
        {
            transform.position = Vector3.Lerp(transform.position, endMarker.position, Time.deltaTime);
        }

        if (spawnManager.GetComponent<SpawnManager>()._currentWave == 1)
        {
            transform.position = Vector3.Lerp(transform.position, endMarker2.position, Time.deltaTime);
        }

        if (spawnManager.GetComponent<SpawnManager>()._currentWave == 2)
        {
            transform.position = Vector3.Lerp(transform.position, endMarker3.position, Time.deltaTime);
        }

        if (spawnManager.GetComponent<SpawnManager>()._currentWave == 3)
        {
            transform.position = Vector3.Lerp(transform.position, endMarker4.position, Time.deltaTime);
        }

    }
}
