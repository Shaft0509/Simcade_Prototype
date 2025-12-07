using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CarPhysics>() != null)
        {
            gameManager.GoalReached();
        }
    }
}
