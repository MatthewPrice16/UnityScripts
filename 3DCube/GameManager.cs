using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public AudioClip marioDeath;
    public AudioSource source;

    public Text result;
    public float restartDelay = 1000f;
    bool gameHasEnded = false;
    public GameObject LevelCompleteUI;
    public GameObject LevelStartedUI;

    public bool completed = false;

    void Start()
    {
        source.clip = marioDeath;

    }

    void FixedUpdate()
    {
        if (gameHasEnded == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RestartLevel();
            }
        }
    }




    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            source.Play();
            gameHasEnded = true;
            LevelCompleteUI.SetActive(true);
            result.text = "FAILED";            
            Invoke("RestartLevel", restartDelay);
            
        }
    }

    public void CompleteLevel()
    {
        completed = true;
        gameHasEnded = true;
        LevelCompleteUI.SetActive(true);
        result.text = "COMPLETE";
    }


    public void StartLevel()
    {
        LevelStartedUI.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
