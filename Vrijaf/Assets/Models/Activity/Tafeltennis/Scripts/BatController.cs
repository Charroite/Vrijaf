using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    Rigidbody bat;

    public PingPongManager pingPongManager;
    public BatController batOpponent;

    bool isGrabbed;
    bool didHitLast;
    bool turnToServe;

    void Start()
    {
        bat = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrabbed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrabbed = false;  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PingPongBall" && !didHitLast)
        {
            batOpponent.SetDidHitLast(false);
            didHitLast = true;
        }
    }

    public bool GetIsGrabbed()
    {
        return isGrabbed;
    }

    public bool GetDidHitLast()
    {
        return didHitLast;
    }

    public void SetDidHitLast(bool boolean)
    {
        didHitLast = boolean;
    }

    public bool GetTurnToServe()
    {
        return turnToServe;
    }

    public void SetTurnToServe(bool boolean)
    {
        turnToServe = boolean;
    }
}
