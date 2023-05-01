using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController playerController;  
    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Players").GetComponent<PlayerController>();
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("dokundu");
        playerPosition(collision, false);
    }
    void playerPosition(Collision collision, bool isDirection)
    {

        if (collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Players")
        {
            Debug.Log("dokundu");
            // playerController = collision.gameObject.GetComponentInParent<PlayerController>();
            if (gameObject.tag == "WallRight")
            {
                playerController.IsRight = isDirection;
                playerController.IsLeft = !isDirection;
            }
            else if (gameObject.tag == "WallLeft")
            {
                playerController.IsLeft = isDirection;
                playerController.IsRight = !isDirection;
            }
        }
        else
        {
            return;

        }

    }
}
