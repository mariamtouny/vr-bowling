using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public List<Pins> pins;
    public List<Ball> balls;
    private int currentTurn = 1;
    private int rollInTurn = 1;
    private int currentRollScore = 0;
    public Transform ballStartPosition;

    private List<int> scoresPerTurn = new List<int>();

    private bool scoringDone = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (!scoringDone && AllBallsStopped())
        {
            int fallenPins = CountFallenPins();
            Debug.Log($"Frame {currentTurn} - Roll {rollInTurn}: {fallenPins} pins");

            currentRollScore += fallenPins;
            rollInTurn++;

            if (rollInTurn > 2 || fallenPins == 10)
            {
                scoresPerTurn.Add(currentRollScore);
                Debug.Log($"Frame {currentTurn} score: {currentRollScore}");

                currentTurn++;
                rollInTurn = 1;
                currentRollScore = 0;

                if (currentTurn > 10)
                {
                    Debug.Log("Game Over!");
                    return;
                }

                ResetPins();
            }

            ResetBalls();
            scoringDone = true;
        }
    }
    private bool AllBallsStopped()
    {
        foreach (var ball in balls)
        {
            if (ball.IsMoving)
                return false;
        }
        return true;
    }

    private HashSet<Pins> alreadyFallenPins = new HashSet<Pins>();

    private int CountFallenPins()
    {
        int count = 0;
        foreach (var pin in pins)
        {
            if (pin.IsFallen && !alreadyFallenPins.Contains(pin))
            {
                alreadyFallenPins.Add(pin);
                count++;
            }
        }
        return count;
    }
    public void ResetPins()
    {
        foreach (var pin in pins)
        {
            pin.ResetPin();
        }
        alreadyFallenPins.Clear();
    }

    public void ResetBalls()
    {
        foreach (var ball in balls)
        {
            ball.ResetBall();
        }

        scoringDone = false;
    }
}
