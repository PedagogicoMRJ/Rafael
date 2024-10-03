using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LapCounter : MonoBehaviour
{
     int nCheckpoint;
     int nPassedcheckpoints;
    float TimeCheckpointPassed;
    int lapsCompleted = -1;
    bool isRaceCompleted = false;
    const int allLaps = 77;
    int carPosition = 0;
    public event Action<LapCounter> OnPassCheckpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            if(isRaceCompleted)
            return;
            Checkpoint checkpoint = collision.GetComponent<Checkpoint>();
            if (nCheckpoint + 1 == checkpoint.nCheckpoint)
            {
                nCheckpoint = checkpoint.nCheckpoint;
                nPassedcheckpoints++;
                TimeCheckpointPassed = Time.time;
                if (checkpoint.isFinish)
                {
                    nCheckpoint = 0;
                    lapsCompleted++;
                    Debug.Log($"{gameObject.name} fez {lapsCompleted} voltas");
                    if (lapsCompleted >= allLaps)
                    {
                        isRaceCompleted = true;
                        Debug.Log($"{gameObject.name} ficou em {carPosition.ToString()}");
                    }
                }
                OnPassCheckpoint?.Invoke(this);
            }
        }
    }
    public void SetCarPosition(int position)
    {
        carPosition = position;
    }
    public int GetNCheckpointPassed()
    {
        return nPassedcheckpoints;
    }
    public float GetTimeCheckpointPassed()
    {
        return TimeCheckpointPassed;
    }
}    