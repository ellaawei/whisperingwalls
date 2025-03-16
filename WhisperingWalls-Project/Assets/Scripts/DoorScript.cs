using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class DoorScript : MonoBehaviour
{
    public AudioClip doorOpening;
    private Animator animator;
    bool doorTriggeredToOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D o)
    {
        PlayerScript player = o.GetComponent<PlayerScript>();
        if (player != null)
        {
            doorTriggeredToOpen = true;
            animator.SetBool("triggerOpen", doorTriggeredToOpen);
            player.PlaySound(doorOpening);
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        PlayerScript player = col.GetComponent<PlayerScript>();
        if (player != null)
        {
            doorTriggeredToOpen = false;
            animator.SetBool("triggerOpen", doorTriggeredToOpen);
        }
    }
}
