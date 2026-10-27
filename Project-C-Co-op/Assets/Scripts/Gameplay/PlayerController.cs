// Code from Rize Education class GDM4 - C# programming
using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f; 
    private float jumpHeight = 7f;
    private Rigidbody2D rb;
    //private SpriteRenderer sp;
    private CharacterController controller;
    public ContactFilter2D ContactFilterDown;
    public ContactFilter2D ContactFilterLeft;
    public ContactFilter2D ContactFilterRight;
    public Sprite facingLeft;
    public Sprite facingRight;
    public Sprite facingForward;
    public int playerNumber = 1;


    public static event Action<String> onLevelComplete;
    public static event Action onLevelFail;
    private bool IsGrounded => rb.IsTouching(ContactFilterDown);
    private bool IsTouchingRight => rb.IsTouching(ContactFilterRight);
    private bool IsTouchingLeft => rb.IsTouching(ContactFilterLeft);

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();    
        //sp = GetComponent<SpriteRenderer>();
        Time.timeScale = 1;    
    }

    void Update()
    {
        Move();
        Jump();

    }
    


    

    void Move() // Directional Movement
    {
        //if (GameManager.Instance.IsGameOver() ) return;
        if (Time.timeScale == 0) return;
        float moveInput = 0;
        if (playerNumber == 1) 
        {
            
            if (Input.GetKey(KeyCode.A))
            {
                moveInput = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveInput = 1;
            }
            else
            {
                rb.linearVelocityX = 0;
            }
        }
        else if (playerNumber == 2) 
        {
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveInput = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                moveInput = 1;
            }
            else
            {
                rb.linearVelocityX = 0;
            }
        }
        

        if ( (moveInput < 0 && !IsTouchingLeft) || (moveInput > 0 && !IsTouchingRight) ) // If input to move and not walking into a wall
        {
            rb.linearVelocityX = moveInput * moveSpeed;
            if (moveInput < 0)
            {
                //sp.sprite = facingLeft;
            }
            else
            {
                //sp.sprite = facingRight;
            }
            if (IsGrounded)
            {
                //AudioManager.Instance.PlayWalkingSoundEffect();                
            }
        }
        else if ((moveInput < 0 && IsTouchingLeft) || (moveInput > 0 && IsTouchingRight) ) // If input to move and walking into wall. This prevents the player from clinging to walls
        {
            rb.linearVelocityX = 0;
        }
        else if (moveInput == 0)
        {
            //sp.sprite = facingForward;            
        }
        
    }

    void Jump() // Vertical Movement
    {
        //if (GameManager.Instance.IsGameOver() ) return;
        if (Time.timeScale == 0) return;
        if (playerNumber == 1) 
        {
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded)
            {
                rb.linearVelocityY = jumpHeight; 
                //AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);  
            }
        }
        else if (playerNumber == 2) 
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded)
            {
                rb.linearVelocityY = jumpHeight; 
                //AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);  
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)  // Spikes - death, Goal - win
    {
        switch( collision.gameObject.tag.ToString() )
        {
            case "Spikes":
                //AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.spikesSound);
                //onLevelFail?.Invoke();  
                break;

            case "Goal":
                //onLevelComplete?.Invoke(SceneManager.GetActiveScene().name );
                break;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            
        }
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }

}
