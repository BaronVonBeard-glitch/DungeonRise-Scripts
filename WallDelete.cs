using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallDelete : MonoBehaviour
{
    public bool wallsDeleted;

    public GameObject wallDeleteTrigger;
    public GameObject player;
    


    private Vector3 triggerPos;
    private Vector3 playerPos;
    private Vector3 offsetTrig;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        
        
    }

    // Update is called once per frame
    void Update()
    {
        offsetTrig = new Vector3(0, -80, 0);
        playerPos = player.transform.position;
        triggerPos = new Vector3(0, playerPos.y + offsetTrig.y, 0);
        wallDeleteTrigger.transform.position = triggerPos;
        WallDeleteTrue();

    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall_Delete_Trigger"))
        {
            Destroy(gameObject);
            wallsDeleted = true;
        }
          
    }

    public void WallDeleteTrue()
    {
        if (wallsDeleted)
        {
            Debug.Log("Walls Deleted");
        }
    }



}
