using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody ball;
    bool didTouchGround = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.name == "Terrain" && !didTouchGround)
        {
            didTouchGround = true;
            StartCoroutine(resetBallPosition());
        }
    }

    IEnumerator resetBallPosition()
    {
        yield return new WaitForSeconds(2);
        
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;
        transform.localPosition = new Vector3(-1.8f, -0.15f, 1);

        didTouchGround = false;
    }
}
