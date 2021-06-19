using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Rigidbody ball;
    public Rigidbody table;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        table = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
