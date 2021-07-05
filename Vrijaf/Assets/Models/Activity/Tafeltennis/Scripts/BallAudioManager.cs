using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioManager : MonoBehaviour
{
    public AudioClip hitDefaultSound;
    public AudioClip hitRacketSound;
    AudioSource hitDefault;
    AudioSource hitRacket;
    
    bool isFirstColision = true;

    void Start()
    {
        hitDefault = gameObject.AddComponent<AudioSource>();
        hitRacket = gameObject.AddComponent<AudioSource>();

        hitRacket.clip = hitRacketSound;
        hitDefault.clip = hitDefaultSound;

        hitDefault.playOnAwake = false;
        hitRacket.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFirstColision)
        {
            isFirstColision = false;
            return;
        }

        if (collision.gameObject.CompareTag("PingPongBat"))
        {
            hitRacket.Play();
        }

        else{
            hitDefault.Play();
        }
    }
}
