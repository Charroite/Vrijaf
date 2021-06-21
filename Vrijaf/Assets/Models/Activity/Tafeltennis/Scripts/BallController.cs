using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody ball;

    public PingPongManager pingPongManager;

    bool isBallGrabbed;
    bool didTouchGround;

    void Start()
    { 
        ball = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        isBallGrabbed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isBallGrabbed = false;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "P1_PingPongBat" && collision.gameObject.name != "P2_PingPongBat" && collision.gameObject.name != "PingPongTable" && !didTouchGround)
        {
            didTouchGround = true;
            StartCoroutine(ResetBallPosition());
        }
    }

    IEnumerator ResetBallPosition()
    {
        yield return new WaitForSeconds(2);

        didTouchGround = false;

        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        pingPongManager.ProcessGameScore();
    }

    public bool GetIsBallGrabbed()
    {
        return isBallGrabbed;
    }

    public bool GetDidBallTouchGround()
    {
        return didTouchGround;
    }
}
