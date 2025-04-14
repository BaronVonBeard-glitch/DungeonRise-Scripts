using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    //player
    private Rigidbody playerRb;
    public GameObject player;
    private Animator animator;
    private AudioSource audio;
    

    //floats
    private float horizontalInput;
    private float verticalInput;
    public float playerSpeed = 0.5f;
    private float ladderSpeed = 7.0f;
    public float playerRotation = 720.0f;

    //Vector3
    private Vector3 movement;
    private Vector3 jump;
    private Vector3 jumpTwo;
  
    //Bools
    public bool canJump;
    public bool atLadder;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        jump = new Vector3(0, 30, 0);
        jumpTwo = new Vector3(0, 35, 0);
        canJump = false;
        animator = GetComponent<Animator>();
        audio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        AttackMode();
        playerRb = GetComponent<Rigidbody>();
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontalInput, 0.0f, verticalInput);
      
        //playerRb.MovePosition(transform.position + move * playerSpeed * Time.deltaTime);

        playerRb.AddForce(move * playerSpeed);
        
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, playerRotation); //* Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRb.AddForce(jump, ForceMode.Impulse);
            canJump = false;
        }
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            playerRb.AddForce(jumpTwo, ForceMode.Impulse);
            Debug.Log("Extra Jump Activated");
            canJump= false;
        }
        if (!canJump)
        {
            playerSpeed = 2.0f;
        } else if (canJump)
        {
            playerSpeed = 4.0f;
        }
        if (move != Vector3.zero)
        {
            animator.SetFloat("Speed", 2.0f);
            
        }
        else if (move == Vector3.zero)
        {
            animator.SetFloat("Speed", 0.0f);
            animator.SetBool("Attack", false);
        }

        if (move != Vector3.zero && canJump)
        {
            audio.enabled = true;
        }
        else { audio.enabled = false; }

        LadderControls();
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            atLadder = true;
            canJump = true;
        }
    }
    public void OnCollisionExit()
    {
        atLadder = false;
    }
    public void LadderControls()
    {
        if (atLadder && Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * ladderSpeed * Time.deltaTime;
        }
    }

    public void AttackMode()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Attack", true);
            
        }
    }


    
}
