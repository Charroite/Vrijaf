using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public PingPongManager pingPongManager;
    Rigidbody bat;

    void Start()
    {
        bat = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(bat.gameObject.name == "P1_PingPongBat")
        {
            pingPongManager.SetIsP1BatGrabbed(true);
        }

        if (bat.gameObject.name == "P2_PingPongBat")
        {
            pingPongManager.SetIsP2BatGrabbed(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (bat.gameObject.name == "P1_PingPongBat")
        {
            pingPongManager.SetIsP1BatGrabbed(false);
        }

        if (bat.gameObject.name == "P2_PingPongBat")
        {
            pingPongManager.SetIsP2BatGrabbed(false);
        }
    }
}
