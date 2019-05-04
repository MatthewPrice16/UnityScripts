using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{

    public void LoadNextLevel()
    {

     GameObject gm = GameObject.Find("GameManager");
     GameManager gmScript = gm.GetComponent<GameManager>();

        if (gmScript.completed)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
