using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionHandler : MonoBehaviour
{
    public List<CarLapCounter> carLapCounters = new List<CarLapCounter>();

    // Start is called before the first frame update
    void Start()
    {
        CarLapCounter[] carLapCounterArray = FindObjectsOfType<CarLapCounter>();

        carLapCounters = carLapCounterArray.ToList<CarLapCounter>();

        foreach (CarLapCounter lapCounter in carLapCounters) // Corrected variable name
        {
           
        }
    }

    void OnPassCheckpoint(CarLapCounter carLapCounter)
    {
        Debug.Log($"Event: Car {carLapCounter.gameObject.name} passed a checkpoint");
    }
}
