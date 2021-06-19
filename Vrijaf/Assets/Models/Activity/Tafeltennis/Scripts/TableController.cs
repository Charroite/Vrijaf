using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public PingPongManager pingPongManager;

    bool didBallHitTable;

    Rigidbody table;
    private void OnCollisionEnter(Collision collision)
    {
        // Check if game has started
        if (collision.gameObject.name == "PingPongBall")
        {
            //Debug.Log(collision.gameObject.name);
        }
    }
}
