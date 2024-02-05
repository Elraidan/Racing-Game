using UnityEngine;
using UnityEngine.Events;

public class CarLapCounter : MonoBehaviour
{
    
    int passedCheckpointNumber = 0;
    int numberOfPassedCheckpoints = 2;

    public UnityEvent<CarLapCounter> OnPassCheckpoint; // Assuming you have declared UnityEvent somewhere

    int lapsCompleted = 0;
    bool isRaceCompleted = false;

    public int lapsToComplete = 3;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("CheckPoint"))
        {
            if (isRaceCompleted)
                return;

            Checkpoint checkpoint = collider2D.GetComponent<Checkpoint>();

            if (passedCheckpointNumber + 1 == checkpoint.checkPointNumber)
            {
                passedCheckpointNumber = checkpoint.checkPointNumber;
                numberOfPassedCheckpoints++;

                if (OnPassCheckpoint != null)
                {
                    OnPassCheckpoint.Invoke(this);
                }

                if (checkpoint.isFinishLine)
                {
                    passedCheckpointNumber = 0;
                    lapsCompleted++;

                    if (lapsCompleted >= lapsToComplete) // You need to define 'lapsToComplete'
                    {
                        isRaceCompleted = true;
                        Debug.Log("Race completed!");
                    }
                    else
                    {
                        Debug.Log("One lap made");
                    }
                }
            }
        }
    }
}
