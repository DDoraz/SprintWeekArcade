using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform endMarker = null; // create an empty gameobject and assign in inspector
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
        transform.position = Vector3.Lerp(transform.position, endMarker.position, Time.deltaTime);
    }
}
