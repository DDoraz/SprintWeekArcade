using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private Transform target;
    public Animator animator;
    public ParticleSystem particle1;
    public ParticleSystem particle2;

    public AudioClip winSound;
    private AudioSource source;

    bool LoadingInitiated = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!LoadingInitiated)
            {
                StartCoroutine(DelayedLoad());
                particle1.Play();
                particle2.Play();
                target.gameObject.SetActive(false);
                animator.SetTrigger("BlastOff");
                source.PlayOneShot(winSound, .7f);
                LoadingInitiated = true;
            }
        }
    }

    IEnumerator DelayedLoad()
    {
        //Wait until clip finish playing
        yield return new WaitForSeconds(2);
        //Load scene here
        SceneManager.LoadScene(2);
    }

}
