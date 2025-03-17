using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;

    [SerializeField] private string mainScene;
    [SerializeField] private string slidingPuzzle;
    [SerializeField] private string mazePuzzle;
    //[SerializeField] private string pipesPuzzle = "PipePuzzle";
    [SerializeField] TextMeshProUGUI keyText;

    int keys = 0;
    bool inPuzzle = false;

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
        keyText.text = "" + keys;

    }

    public void NextLevel(int level)
    { 
        switch (level)
        {
            case 0:
                SceneManager.UnloadSceneAsync(currentScene);
                inPuzzle = false;
                break;
            case 1:
                SceneManager.LoadScene(slidingPuzzle, LoadSceneMode.Additive);
                currentScene = slidingPuzzle;
                inPuzzle = true;
                break;
            case 2:
                SceneManager.LoadScene(mazePuzzle, LoadSceneMode.Additive);
                currentScene = mazePuzzle;
                inPuzzle = true;
                break;
            //case 3:
            //    SceneManager.LoadScene(pipesPuzzle, LoadSceneMode.Additive);
            //    currentScene = pipesPuzzle;
            //    break;
        }
    }

    public void restart()
    {
        int keys = 0;
        bool inPuzzle = false;

        string currentScene = "";

        SceneManager.LoadScene(mainScene);
    }

    public void addKey(int amount)
    {
        keys += amount;
        keyText.text = "" + keys;
    }

    public bool isPuzzle()
    {
        return inPuzzle;
    }

    public int getKeys()
    {
        return keys;
    }
}
