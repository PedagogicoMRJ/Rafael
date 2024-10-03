using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LapCounter : MonoBehaviour
{
    int nCheckpoint;
    int nPassedcheckpoints;
    float timeCheckpointPassed;
    public event Action<LapCounter> OnPassCheckpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            Checkpoint checkpoint = collision.GetComponent<Checkpoint>();
            if (nCheckpoint + 1 == checkpoint.nCheckpoint)
            {
                nCheckpoint = checkpoint.nCheckpoint;
                nPassedcheckpoints++;
                timeCheckpointPassed = Time.time;
                OnPassCheckpoint?.Invoke(this);
            }
        }
    }
}    