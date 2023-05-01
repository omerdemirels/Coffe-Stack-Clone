using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeAnimControl : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update

    private void OnEnable()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("CoffeeLeft",true);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("CoffeeLeft", false);
         

        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("CoffeRight", true);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("CoffeRight", false);


        }
    }
}
