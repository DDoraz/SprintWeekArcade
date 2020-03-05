using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    public GameObject grabCamera;
    public bool cameraSlide = false;
    public GameObject enemySpawnerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraSlide == true)
        {
            grabCamera.GetComponent<moveCamera>().moveCameraOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraSlide = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemySpawnerObject.GetComponent<SpawnManager>().screenMoved = true;
            //enemySpawnerObject.GetComponent<SpawnManager>().nextSpawnTime = 5f;
        }
    }
}
