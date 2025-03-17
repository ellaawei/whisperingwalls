using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public GameObject snailBarrier;
    public GameObject startScreen;
    bool isStart;
    public bool isStart2 { get { return isStart; } }
    public GameObject hiddenPassage;
    AudioSource audioSource;
    public TextMeshProUGUI flashlightText;
    bool hasFlashlight;
    public bool hasFlashlight2 { get { return hasFlashlight; } }
    bool gameIsOver;
    //public TextMeshProUGUI keysCollected;
    public TextMeshProUGUI batteriesCollected;
    //int keys;
    public TextMeshProUGUI gameOver;
    Vector2 lookDirection = new Vector2(1, 0);
    Animator animator;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    bool haslives;
    int batteries;

    int ghostHit;

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        haslives = true;
        gameOver.text = "";
        batteries = 0;
        //keys = 0;
        batteriesCollected.text = "" + batteries;
        //keysCollected.text = "" + keys;
        gameIsOver = false;
        hasFlashlight = false;
        flashlightText.text = "Flashlight: Not Collected";
        audioSource = GetComponent<AudioSource>();
        hiddenPassage.SetActive(false);
        startScreen.SetActive(true);
        isStart = false;
        snailBarrier.SetActive(true);

        ghostHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isStart = true;
            startScreen.SetActive(false);
            snailBarrier.SetActive(false);
        }
        if (!gameIsOver && isStart)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            Vector2 move = new Vector2(horizontal, vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }
            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            if (Input.GetKeyDown(KeyCode.X))
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
                if (hit.collider != null)
                {
                    NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                    Debug.Log("Hello");
                    if (character != null)

                    {

                        character.DisplayDialog();

                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("PuzzleKey"));
                if (hit.collider != null)
                {
                    MainGameManager.instance.NextLevel(1);
                }
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("PuzzleKey"));
                if (hit.collider != null)
                {
                    MainGameManager.instance.NextLevel(2);
                }
            }
            //if (Input.GetKeyDown(KeyCode.P))
            //{
            //    RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("PuzzleKey"));
            //    if (hit.collider != null)
            //    {
            //        MainGameManager.instance.NextLevel(3);
            //    }
            //}
        }
        if (!haslives)
        {
            gameOver.text = "Game Lost";
            gameIsOver = true;
        }

        if (hasFlashlight && batteries >= 2)
        {
            hiddenPassage.SetActive(true);
        }
        else
        {
            hiddenPassage.SetActive(false);
        }
        if (batteries > 0 && hasFlashlight && MainGameManager.instance.getKeys() == 3)
        {
            gameIsOver = true;
            gameOver.text = "Game Won!\nYou made it out of the mansion";
        }

    }
    void FixedUpdate()
    {
        if ((!gameIsOver) && (MainGameManager.instance.isPuzzle() == false))
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + 3.0f * horizontal * Time.deltaTime;
            position.y = position.y + 3.0f * vertical * Time.deltaTime;
            rigidbody2d.MovePosition(position);
        }
        
    }
    public void ChangeHealth()
    {
        haslives = false;
        gameOver.text = "Game Lost";
        gameIsOver = true;
    }
    public void AddBattery(int num)
    {
        batteries = batteries + num;
        if (batteries < 0)
        {
            gameIsOver = true;
            gameOver.text = "Game Lost";
        }

        if (num < 0)
        {
            ghostHit++;
        }

        batteriesCollected.text = "" + batteries;
    }
    //public void AddKey(int num)
    //{
    //    keys += num;
    //    keysCollected.text = "" + keys;
    //}
    public void AddFlashlight()
    {
        hasFlashlight = true;
        flashlightText.text = "Flashlight: Collected";
    }
    public void PlaySound(AudioClip clip)
    {
        if (!gameIsOver)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
