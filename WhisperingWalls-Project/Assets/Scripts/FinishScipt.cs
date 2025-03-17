using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        BallMove ball = collision.GetComponent<BallMove>();
        if (ball != null )
        {
            isFinished = true;
            MainGameManager.instance.addKey(1);
        }

        // Add any additional actions like displaying a "You Win!" message
    }
}
