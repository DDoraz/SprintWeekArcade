using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool LoadingInitiated = false;
    public AudioClip gamestart;
    private AudioSource source;
    // Update is called once per frame
    public void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (!LoadingInitiated)
            {
                StartCoroutine(DelayedLoad());
                LoadingInitiated = true;
            }
        }
    }

    IEnumerator DelayedLoad()
    {
        //Play the clip once
        source.PlayOneShot(gamestart, 1);

        //Wait until clip finish playing
        yield return new WaitForSeconds(1.25f);

        //Load scene here
        SceneManager.LoadScene(1);
    }
}
