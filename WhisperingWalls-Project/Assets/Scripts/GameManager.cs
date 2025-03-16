using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    int totalPipes = 13;
    int correctedPipes = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for(int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void correctMove()
    {
        correctedPipes++;
        Debug.Log(correctedPipes);
        if (correctedPipes == 13)
        {
            Debug.Log("You win!");
        }
    }
    public void wrongMove()
    {
        correctedPipes--;
    }
}
