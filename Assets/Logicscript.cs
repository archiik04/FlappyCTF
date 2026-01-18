using UnityEngine;
using UnityEngine.UI;

public class Logicscript : MonoBehaviour
{
    public int playerscore;
    public Text scoret;

    public int targetScore = 3301;
    private bool flagTriggered;

    private void Start()
    {
        if (scoret == null)
        {
            Debug.LogError("Score Text not assigned in Logicscript!");
        }

        playerscore = 0;
        flagTriggered = false;

        if (scoret != null)
        {
            scoret.text = playerscore.ToString();
        }
    }

    public void gettheflaghere()
    {
        playerscore++;

        if (scoret != null)
        {
            scoret.text = playerscore.ToString();
        }

        if (!flagTriggered && playerscore == targetScore)
        {
            flagTriggered = true;

            CTFController ctf = FindObjectOfType<CTFController>();
            if (ctf != null)
            {
                ctf.RequestFlagFromServer(playerscore);
            }
        }
    }
}
