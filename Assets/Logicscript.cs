using UnityEngine;
using UnityEngine.UI;

public class Logicscript : MonoBehaviour
{
    public int playerscore = 0;
    public Text scoret;

    // Impossible target (intentional)
    public int targetScore = 3301;

    private bool flagTriggered = false;

    void Start()
    {
        // Safety check
        if (scoret == null)
        {
            Debug.LogError("Score Text not assigned in Logicscript!");
        }

        // Reset state
        playerscore = 0;
        flagTriggered = false;

        if (scoret != null)
            scoret.text = playerscore.ToString();
    }

    public void addscore()
    {
        playerscore++;

        // INTENTIONAL SCORE CAP
        if (playerscore > 3299)
        {
            playerscore = 3299;
        }

        if (scoret != null)
            scoret.text = playerscore.ToString();

        // Impossible condition → native DLL
        if (!flagTriggered && playerscore == targetScore)
        {
            flagTriggered = true;

            CTFController ctf = FindObjectOfType<CTFController>();
            if (ctf != null)
            {
                ctf.GenerateFlagOnce(playerscore);
            }
            else
            {
                Debug.LogError("CTFController not found in scene!");
            }
        }
    }
  
}
