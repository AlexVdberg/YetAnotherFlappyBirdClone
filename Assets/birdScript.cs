using System;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    // Needs to be populated in Unity Editor
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpVelocity = 10f;

    // Do not need to be populated in Unity Editor
    public static event Action OnCollideWithPipe;
    public static event Action OnGameStart;
    private bool isDead = false;
    private bool isGameStarted = false;
    private Animator wingsAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // This shouldn't be needed because we already set a reference to it in the editor.
        //rb = GetComponent<Rigidbody2D>();
        
        // Get the animation component in the child game object
        wingsAnimation = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // This will grab what we assigned to under Edit->Project Settings->Input Manager
        if (Input.GetButtonDown("Jump"))
        {
            if (!isGameStarted)
            {
                // Start the game and notify other scripts
                isDead = false;
                // isGameStarted gets reset by reloading the scene
                isGameStarted = true;
                rb.simulated = true;
                if (wingsAnimation != null)
                {
                    // I wish this didn't depend on a string. Maybe I should look into global const?
                    // or sending an action to a deticated animation script
                    wingsAnimation.SetBool("Flying", true);
                }

                OnGameStart?.Invoke();
            }

            if (!isDead)
            {   
                rb.linearVelocity = Vector2.up * jumpVelocity;

                /*
                // Hardcoding the key codes is also not a good idea
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // I didn't go with this because you need to press it a few times
                    // to overcome the downward force
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                */
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollideWithPipe?.Invoke();
        // Also stop player from being able to continue jumping
        isDead = true;
        wingsAnimation.SetBool("Flying", false);
        //wingsAnimation.Stop();
    }
}
