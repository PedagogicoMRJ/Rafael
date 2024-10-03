using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionHandler : MonoBehaviour
{
    public List<LapCounter> lapCounters = new List<LapCounter>();
    void Start
    {
        LapCounter[] lapCountersArray = FindObjectsOfType<LapCounter>();
        lapCounters = lapCountersArray.ToList<LapCounter>();
        foreach (LapCounter lapCounter in lapCounters)
            lapCounter.OnPassCheckpoint += OnPassCheckpoint;
    }
    void OnPassCheckpoint(LapCounter lapCounter)
    {
        Debug.Log($"Carro {lapCounter.gameObject.name} passou o checkpoint");
    }
}