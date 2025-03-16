using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed = 1.0f; // Movement speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow)
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrow)


        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput); // Create movement vector
        transform.Translate(moveDirection * speed * Time.deltaTime); // Move the character
    }
}
