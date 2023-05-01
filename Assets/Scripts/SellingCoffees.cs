using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingCoffees : MonoBehaviour
{
 
    Player player;
    private Animator animator;
    [SerializeField] int money;
    private ScoreManager scoreManager;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager = FindObjectOfType<ScoreManager>();
            player =other.GetComponent<Player>();
            player.isFinish = false;
            Debug.Log("Ele deðdi");
            scoreManager.ScoreUpdate(money);

            //other.GetComponent<Player>().isFinish = false;
            other.transform.SetParent(gameObject.transform);
            animator.SetBool("isHandMoving", true);
        }
        else if (other.CompareTag("Players"))
        {
            animator.SetBool("isHandMoving", true);
        }
    }
}
