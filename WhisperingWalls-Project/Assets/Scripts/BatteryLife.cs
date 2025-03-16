using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLife : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D o)
    {
        PlayerScript player = o.GetComponent<PlayerScript>();
        if (player != null)
        {
            if (player.hasFlashlight2)
            {
                player.AddBattery(1);
                Destroy(gameObject);
            }
        }
    }


}

