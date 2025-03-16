using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioClip scream;
    float speed;
    public bool vertical;
    float changeTime = 7.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool flip = true;
    public static int enemiesHit;
    bool broken = true;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        speed = 6.0f;
        enemiesHit = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            if (flip)
            {

                flip = false;
                timer = changeTime;
            }
            else
            {

                flip = true;
                timer = changeTime;
            }
        }

    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("MoveX", 0);
            //speed = 2.0f;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("MoveX", direction);
            //speed = 2.0f;
        }

        rigidbody2D.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //speed = 0.5f;
        PlayerScript player = other.gameObject.GetComponent<PlayerScript>();

        if (player != null)
        {
            player.AddBattery(-1);
            player.PlaySound(scream);
        }
    }

}
