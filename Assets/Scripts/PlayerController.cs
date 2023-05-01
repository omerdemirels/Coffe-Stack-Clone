using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public bool playerOk;
   [SerializeField] public float speed=15f;
    public bool run=true;
    private bool isLeft = true;
    private bool isRight = true;
    public bool IsLeft{set { isLeft = value; } } 
    public bool IsRight{ set { isRight = value; }}
    int score;
    ScoreManager scoreManager;
    bool finish;
    GameManager gameManager;
    private void Awake()
    {
        playerOk = false;
        finish = false;
    }
    private void Update()
    {
        Move();
       
    }
    private void Move()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal")*Time.deltaTime;
        if (run)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            if (isRight && horizontalInput > 0)
            {
                transform.position += Vector3.right * horizontalInput * speed;
                isLeft = true;
            }
            //Left
            else if (isLeft && horizontalInput < 0)
            {
                transform.position += Vector3.right * horizontalInput * speed;
                isRight = true;
            }
        } 
        else if (!run)
        {
           
            Vector3 hedef = new Vector3(transform.localPosition.x, score, transform.localPosition.z);
            transform.position = Vector3.MoveTowards(transform.localPosition, hedef, (10) * Time.deltaTime);
            if(Vector3.Distance(transform.localPosition,hedef)==0&&!finish)
            {
                Debug.Log("Oyun Bitti");
                finish = true;
                gameManager=FindObjectOfType<GameManager>();
                if (score == 0)
                {
                    gameManager.GameOverPanel();
                }
                else if (score >= 0)
                {
                    gameManager.NextLevelPanel();
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            scoreManager = FindObjectOfType<ScoreManager>();
            score = scoreManager._Score / 4;
            run = false;
            other.transform.SetParent(gameObject.transform);
        }
    }
}
