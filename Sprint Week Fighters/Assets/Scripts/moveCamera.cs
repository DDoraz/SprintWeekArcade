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
    public Transform endMarker5 = null;
    public bool LastStage = false;
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
        if(spawnManager.GetComponent<SpawnManager>()._spawnedEnemies == 6)
        {
            transform.position = Vector3.Lerp(transform.position, endMarker.position, Time.deltaTime);
        }

        if (spawnManager.GetComponent<SpawnManager>()._spawnedEnemies == 8)
        {
            transform.position = Vector3.Lerp(transform.position, endMarker2.position, Time.deltaTime);
        }

        if (spawnManager.GetComponent<SpawnManager>()._spawnedEnemies == 10)
        {
            transform.position = Vector3.Lerp(transform.position, endMarker4.position, Time.deltaTime);
        }

        if (spawnManager.GetComponent<SpawnManager>()._spawnedEnemies == 12)
        {
           
            transform.position = Vector3.Lerp(transform.position, endMarker5.position, Time.deltaTime);
            LastStage = true;
        }
        Debug.Log(spawnManager.GetComponent<SpawnManager>()._spawnedEnemies);
    }
}
