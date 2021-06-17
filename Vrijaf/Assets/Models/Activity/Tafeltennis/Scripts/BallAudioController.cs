using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioController : MonoBehaviour
{
    public AudioSource hitDefault;
    public AudioSource hitRacket;
    public AudioClip hitDefaultSound;
    public AudioClip hitRacketSound;

    // Start is called before the first frame update
    void Start()
    {
        hitDefault = gameObject.AddComponent<AudioSource>();
        hitRacket = gameObject.AddComponent<AudioSource>();

        hitRacket.clip = hitRacketSound;
        hitDefault.clip = hitDefaultSound;

        hitDefault.playOnAwake = false;
        hitRacket.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Racket")
        {
            hitRacket.Play();
        } 
        else{
            hitDefault.Play();
        }
    }
}
