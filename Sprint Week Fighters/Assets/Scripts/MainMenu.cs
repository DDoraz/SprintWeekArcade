using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("DavidScene", LoadSceneMode.Single);
            Debug.Log("Key1 Pressed");
        }
    }
}
