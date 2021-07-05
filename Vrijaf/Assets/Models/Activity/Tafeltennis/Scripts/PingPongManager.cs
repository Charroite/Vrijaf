using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongManager : MonoBehaviour
{
    public BallController ball;
    public BatController batP1;
    public BatController batP2;
    public TableController table;

    bool isGameActive;
    bool isRallyActive;

    int matchCount;
    int serveCount = 1;
    float[] gameScore = new float[] { 0, 0 };

    void Update()
    {
        //Debug.Log(ball.getIsBallGrabbed());
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
            ball.transform.localPosition = new Vector3(0.05f, -0.15f, -0.2f);
            return;
        }

        ball.transform.localPosition = new Vector3(-1.5f, -0.5f, 0.7f);
    }

}
