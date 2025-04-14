using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public GameObject player;
    
    private Rigidbody playerRb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.linearVelocity.magnitude >= 50.0f)
        {
            //place-Holder until death animation created
            player.SetActive(false);
            Debug.Log("GameOver");
        }
    }


}
