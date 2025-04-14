using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonSpawner : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject backWall;
    public GameObject ladderWall;
    public GameObject platformRight;
    public GameObject platformLeft;
    public GameObject trigger;
    public GameObject player;
    

    private Vector3 playerPosition;
    private Vector3 playerOffsetLeft;
    private Vector3 playerOffsetRight;
    private Vector3 platformPosRight;
    private Vector3 platformPosLeft;
    private Vector3 backWallOffset;
    private Vector3 ladderOffset;
    private Vector3 spawnPos;
    private Quaternion rotationLeft;
    private Quaternion rotationRight;
    private Quaternion ladderWallRotation;

    private int randomNumGen;
    public float spawnCollisionCheckRadius;

    

  

    public bool collisionTrue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationLeft = Quaternion.Euler(-90, 0, 0);
        rotationRight = Quaternion.Euler(-90, -180, 0);
        ladderWallRotation = Quaternion.Euler(-90, -180, 0);
        trigger.SetActive(true);
        //Sets correct rotation of platforms in the instantiating process
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        playerOffsetLeft = new Vector3(-19f, playerPosition.y + 51f, 0);
        playerOffsetRight = new Vector3(22f, playerPosition.y + 50f, 0);
        ladderOffset = new Vector3(-17f, playerPosition.y + 62f, -6.0f);
        //platformPosLeft = new Vector3(-2.25f, playerPosition.y + 45f, 0);
        //platformPosRight = new Vector3(5f, playerPosition.y + 65.5f, 0);
        backWallOffset = new Vector3(-4.7f, playerPosition.y + 49f, 12.05f);
        randomNumGen = Random.Range(0, 10);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
           collisionTrue = true;
            
        }

        if (collisionTrue)
        {
            if (randomNumGen > 6 && !Physics.CheckSphere(playerOffsetLeft, spawnCollisionCheckRadius))
            {
                Instantiate(ladderWall, ladderOffset, Quaternion.identity);
                Instantiate(rightWall, playerOffsetRight, Quaternion.identity);
                
                //playerOffsetLeft = new Vector3(-2.25F, playerPosition.y + 60.5f, 0);
                //playerOffsetRight = new Vector3(2.25f, playerPosition.y + 60.5f, 0);
            }
            else if (randomNumGen < 6 && !Physics.CheckSphere(playerOffsetLeft, spawnCollisionCheckRadius))
            {
                Instantiate(leftWall, playerOffsetLeft, Quaternion.identity);
                Instantiate(rightWall, playerOffsetRight, Quaternion.identity);
                //playerOffsetLeft = new Vector3(-2.25f, playerPosition.y + 45f, 0);
                //playerOffsetRight = new Vector3(2.25f, playerPosition.y + 45f, 0);
                
            }

            //Quaternion.identity just means zero rotation

            //Instantiate(platformLeft, platformPosLeft, rotationLeft);
            //Instantiate(platformRight, platformPosRight, rotationRight);
            if (!Physics.CheckSphere(backWallOffset, spawnCollisionCheckRadius))
            {
                Instantiate(backWall, backWallOffset, Quaternion.identity);
            }
            trigger.SetActive(false);

        }

    }
    
    public void OnTriggerExit(Collider other)
    {

        collisionTrue = false;
        //trigger.SetActive(false);

    }







}
