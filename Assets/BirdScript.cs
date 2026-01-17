using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float flapStrength = 6f;

    public Logicscript logic;
    public bool birdalive = true;
    public GameObject gameOverScreen;

    void Start()
    {
        gameObject.name = "Floopy";

        GameObject logicObj = GameObject.FindGameObjectWithTag("Logic");
        if (logicObj != null)
        {
            logic = logicObj.GetComponent<Logicscript>();
        }
        else
        {
            Debug.LogError("Logic object not found! Make sure it is tagged 'Logic'.");
        }

        // Hide Game Over screen at start
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdalive)
        {
            myrigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!birdalive) return;

        birdalive = false;
        Debug.Log("Bird died");

        // Stop physics
        myrigidbody.velocity = Vector2.zero;
        myrigidbody.simulated = false;

        // Show Game Over UI (if assigned)
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // Restart after delay
        Invoke(nameof(RestartGame), 1.5f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
