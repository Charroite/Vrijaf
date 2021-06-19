using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public PingPongManager pingPongManager;

    Rigidbody ball;

    bool didTouchGround = false;
    string lastPlayerHit;

    void Start()
    { 
        ball = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        pingPongManager.SetIsBallGrabbed(true);
    }

    private void OnTriggerExit(Collider other)
    {
        pingPongManager.SetIsBallGrabbed(false);
    }

    

    private void OnCollisionEnter(Collision collision)
    { 
       if(collision.gameObject.name == "Terrain" && !didTouchGround)
        {
            didTouchGround = true;
            StartCoroutine(resetBallPosition());
        }

       if(collision.gameObject.tag == "PingPongBat" && collision.gameObject.name != lastPlayerHit)
        {
            lastPlayerHit = collision.gameObject.name;
        } 
    }

    IEnumerator resetBallPosition()
    {
        yield return new WaitForSeconds(2);

        didTouchGround = false;

        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        if(lastPlayerHit == "P1_PingPongBat")
        {
            transform.localPosition = new Vector3(0.4f, -0.15f, -0.4f);
            yield break;
        }

        if(lastPlayerHit == "P2_PingPongBat")
        {
            transform.localPosition = new Vector3(-1.8f, -0.15f, 0.9f);
        }
    }
}
