using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    private int sceneIndex;
    public int SceneIndex { get { return sceneIndex; } }    

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject nextLevelPanel;
    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Start()
    {
        gameOver = false;
     
    }

    public void GameOverPanel()
    {
       gameOver = true;
        if (gameOver&&gameOverPanel!=null)
        {
            gameOverPanel.SetActive(true); 
        }

    }
    public void NextLevelPanel()
    {
        if (nextLevelPanel != null)
        {
            nextLevelPanel.SetActive(true);
        }
       
    }
    /// <summary>
    /// Ayný levelý yeniden baþlat
    /// </summary>
    public void Restart()
    {
       
        SceneManager.LoadScene(sceneIndex);

    }
    /// <summary>
    /// Level ekraný deðiþtirir.
    /// </summary>
    public void NextLevel()
    {
        gameOver = true;//panel açýldýðýnda karakter harekteti olmasýn

        
        if (sceneIndex + 1 <= SceneManager.sceneCountInBuildSettings - 1)
        {

            SceneManager.LoadScene(sceneIndex + 1);

        }
        else
        {
            SceneManager.LoadScene(sceneIndex);

        }


    }

    public void QuitGame()
    {
        gameOver = true;
        Application.Quit();
    }
}