using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D o)
    {
        PlayerScript player = o.GetComponent<PlayerScript>();
        if (player != null)
        {
            player.AddFlashlight();
            Destroy(gameObject);
        }
    }
}
