using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongManager : MonoBehaviour
{
    bool isGameActive;
    bool isRallyActive;

    public BallController ball;
    public BatController batP1;
    public BatController batP2;
    public TableController table;

    int matchCount;
    int serveCount = 1;
    float[] gameScore = new float[] { 0, 0 };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ball.getIsBallGrabbed());
    }
    
    private void ChangeServeTurn()
    {
        if (batP2.GetTurnToServe())
        {
            batP1.SetTurnToServe(true);
            batP2.SetTurnToServe(false);
            return;
        }

        batP2.SetTurnToServe(true);
        batP1.SetTurnToServe(false);
    }

    private void ResetBallPosition()
    {
        if (batP2.GetTurnToServe())
        {
            ball.transform.localPosition = new Vector3(0.4f, -0.15f, -0.4f);
            return;
        }

        ball.transform.localPosition = new Vector3(-1.8f, -0.15f, 0.9f);
    }

    public void ProcessGameScore()
    {
        if (serveCount == 2)
        {
            ChangeServeTurn();
            serveCount = 0;
        }

        ResetBallPosition();

        serveCount++;
    }
}
