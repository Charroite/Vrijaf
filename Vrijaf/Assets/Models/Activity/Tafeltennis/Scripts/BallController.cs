using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public PingPongManager manager;

    Rigidbody ball;
    List<string> collisionsToIgnore;
    
    bool isBallGrabbed;
    bool didTouchGround;

    void Start()
    {
        ball = GetComponent<Rigidbody>();

        collisionsToIgnore = new List<string>() { "P1_PingPongBat", "P2_PingPongBat", "PingPongTable" };
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
        if (!didTouchGround)
        {
            if (!collisionsToIgnore.Contains(collision.gameObject.name))
            {
                didTouchGround = true;
                StartCoroutine(ResetBallPosition());
            }
        }
    }

    IEnumerator ResetBallPosition()
    {
        yield return new WaitForSeconds(2);

        didTouchGround = false;

        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        manager.ProcessGameScore();
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
