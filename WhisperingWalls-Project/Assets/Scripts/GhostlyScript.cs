using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public Transform target; // The sprite to follow

    public float followSpeed = 0.5f; // How fast to follow

    private SpriteRenderer spriteRenderer;

    Animator animator;



    public void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);

        transform.position = newPosition;

        if (target.transform.position.x < this.transform.position.x)
        {
            animator.SetFloat("Move X", -1);
            animator.SetFloat("Move Y", 0);
        }
        else if (target.transform.position.x > this.transform.position.x)
        {
            animator.SetFloat("Move X", 1);
            animator.SetFloat("Move Y", 0);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //speed = 0.5f;
        PlayerScript player = other.gameObject.GetComponent<PlayerScript>();

        if (player != null)
        {
            player.ChangeHealth();
        }
    }
    //void FixedUpdate()
    //{
    //    this.spriteRenderer.flipX = target.transform.position.x < this.transform.position.x;
    //}
}



