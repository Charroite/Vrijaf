using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody ball;
    bool didTouchGround = false;
    string lastPlayerHit;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.name == "Terrain" && !didTouchGround)
        {
            didTouchGround = true;
            StartCoroutine(resetBallPosition());
        }

       if(collision.gameObject.tag == "TennisBat" && collision.gameObject.name != lastPlayerHit)
        {
            lastPlayerHit = collision.gameObject.name;
        } 
    }

    IEnumerator resetBallPosition()
    {
        yield return new WaitForSeconds(2);
        
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        if(lastPlayerHit == "P1_Bat")
        {
            transform.localPosition = new Vector3(0.4f, -0.15f, -0.4f);
        }

        if(lastPlayerHit == "P2_Bat")
        {
            transform.localPosition = new Vector3(-1.8f, -0.15f, 0.9f);
        }

        didTouchGround = false;
    }
}
