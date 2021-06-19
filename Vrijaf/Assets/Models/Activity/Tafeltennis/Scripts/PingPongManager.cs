using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongManager : MonoBehaviour
{
    bool hasGameStarted;
    bool hasRallyStarted;

    bool isBallGrabbed;
    bool isP1BatGrabbed;
    bool isP2BatGrabbed;

    int round;
    float[] roundScore = new float[] { 0, 0 };




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsBallGrabbed(bool isGrabbed)
    {
        isBallGrabbed = isGrabbed;
    }

    public void SetIsP1BatGrabbed(bool isGrabbed)
    {
        isP1BatGrabbed = isGrabbed;
    }

    public void SetIsP2BatGrabbed(bool isGrabbed)
    {
        isP2BatGrabbed = isGrabbed;
    }
}
