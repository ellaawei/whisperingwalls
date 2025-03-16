using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;

    [SerializeField] private string mainScene = "MainScene-pls no delete";
    [SerializeField] private string slidingPuzzle = "SlidingPuzzleEEEEEE";
    [SerializeField] private string mazePuzzle = "maze";
    [SerializeField] private string pipesPuzzle = "PipePuzzle";

    string currentScene = "";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void NextLevel(int level)
    { 
        switch (level)
        {
            case 0:
                SceneManager.UnloadSceneAsync(currentScene); 
                break;
            case 1:
                SceneManager.LoadScene(slidingPuzzle, LoadSceneMode.Additive);
                currentScene = slidingPuzzle;
                break;
            case 2:
                SceneManager.LoadScene(mazePuzzle, LoadSceneMode.Additive);
                currentScene = mazePuzzle;
                break;
            case 3:
                SceneManager.LoadScene(pipesPuzzle, LoadSceneMode.Additive);
                currentScene = pipesPuzzle;
                break;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(mainScene);
    }
}
