using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Transform coffeeTransform;
   [SerializeField] public bool follow;
    Rigidbody rigidbodyV;
    public bool obstacle;
    [SerializeField] GameObject coffeePrefab,LIDPrefab,slivePrefab;
    Animator animator;
    ScoreManager scoreManager;
    public bool isFinish;
    private void Awake()
    {
        rigidbodyV=GetComponent<Rigidbody>();
        follow = true;
        obstacle = false;
        animator = GetComponent<Animator>();
        scoreManager = FindObjectOfType<ScoreManager>();
        isFinish = true;
    }


    public void Jump()
    {

        rigidbodyV.AddForce(RandomForce(-2, 5), RandomForce(5, 15), RandomForce(15, 20),ForceMode.Impulse);
        obstacle = true;
        follow = true;
        if (transform.parent)
        {
            transform.parent.GetComponent<PlayerController>().playerOk = false;
            transform.SetParent(null);
        }
        coffeePrefab.SetActive(false);
        LIDPrefab.SetActive(false); 
    }
    float RandomForce(short minF,short maxF)
    {
        return Random.Range(minF,maxF);
    }
    void Update()
    {
        PlayersCollection();
        
    }

    IEnumerator CoffeeAnim()
    {
        animator.SetBool("CupAnim", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("CupAnim", false);
    }
    IEnumerator SliveAnim()
    {
        animator.SetBool("CupAnim", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("CupAnim", false);
    }
    private void OnCollisionEnter(Collision collision)
    {
     
        if(collision.gameObject.GetComponent<PlayerController>() && collision.gameObject.GetComponent<PlayerController>().playerOk==false)
        {
            gameObject.transform.SetParent(collision.transform);
            gameObject.transform.position =new Vector3(collision.transform.localPosition.x, collision.transform.localPosition.y, collision.transform.localPosition.z+3f);
            StartCoroutine(CoffeeAnim());
            collision.gameObject.GetComponent<PlayerController>().playerOk = true;
            scoreManager.ScoreUpdate(10);
            follow = false;
        }

        if (collision.gameObject.CompareTag("Player")&&follow)
        {
            coffeeTransform =collision.transform;
            follow = false;
            collision.gameObject.GetComponent<Player>().follow = false;
            obstacle = false;
            StartCoroutine(CoffeeAnim());
            scoreManager.ScoreUpdate(10);
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PiramitObs"))
        {
            // Jump();
            scoreManager.ScoreUpdate(-10);
            Destroy(gameObject);
        }
        if (other.CompareTag("Coffee"))
        {
           coffeePrefab.SetActive(true);
        }
        if (other.CompareTag("LID"))
        {
            LIDPrefab.SetActive(true);
        }
        if (other.CompareTag("Slive"))
        {
          slivePrefab.SetActive(true);
        }
        if (other.CompareTag("Finish"))
        {
          PlayerController playerController = FindObjectOfType<PlayerController>();
           
            
            playerController.IsLeft = false;
            playerController.IsRight = false;
            playerController.speed = 7;
            
            playerController.transform.position = new Vector3(0, playerController.transform.position.y, playerController.transform.position.z);

        }
    }
    void PlayersCollection()
    {
        if (coffeeTransform != null && isFinish)
        {
            Vector3 targetPosition = new Vector3(coffeeTransform.position.x, transform.position.y, coffeeTransform.position.z + 3f);
            transform.position =new Vector3(Vector3.Lerp(transform.position, targetPosition, 11f * Time.deltaTime).x, targetPosition.y, targetPosition.z);  
        }
    }

     
}
