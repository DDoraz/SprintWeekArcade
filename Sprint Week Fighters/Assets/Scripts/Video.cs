using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            text1.SetActive(true);
        }
        else { text1.SetActive(false); }


        if (Input.GetKey(KeyCode.W))
        {
            text2.SetActive(true);
        }
        else { text2.SetActive(false); }

        if (Input.GetKey(KeyCode.E))
        {
            text3.SetActive(true);
        }
        else { text3.SetActive(false); }

        if (Input.GetKey(KeyCode.R))
        {
            text4.SetActive(true);
        }
        
        if (Input.GetKey(KeyCode.T))
        {
            text5.SetActive(true);
        }
        else { text5.SetActive(false); }

        if (Input.GetKey(KeyCode.Y))
        {
            text6.SetActive(true);
        }
        else { text6.SetActive(false); }

        if (Input.GetKey(KeyCode.U))
        {
            text7.SetActive(true);
        }
        else { text7.SetActive(false); }

        if (Input.GetKey(KeyCode.I))
        {
            text8.SetActive(true);
        }
        else { text8.SetActive(false); }

        if (Input.GetKey(KeyCode.O))
        {
            text9.SetActive(true);
        }
        else { text9.SetActive(false); }

        if (Input.GetKey(KeyCode.P))
        {
            text10.SetActive(true);
        }
        else { text10.SetActive(false); }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            text4.SetActive(false);
        }
    }
       
}
