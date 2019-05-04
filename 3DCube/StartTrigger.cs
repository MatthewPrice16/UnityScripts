using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        //GetComponent<PlayerMovement>().enabled = false;
        gameManager.StartLevel();

    }

}
