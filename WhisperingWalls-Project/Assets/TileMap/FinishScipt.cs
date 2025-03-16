using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScipt : MonoBehaviour
{
    public bool isFinished = false;

    // Start is called before the first frame update
    void Awake()
    {
        isFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFinished == true)
        {
            MainGameManager.instance.NextLevel(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
            isFinished = true;
        // Add any additional actions like displaying a "You Win!" message
    }
}
