using UnityEngine;
using TMPro;

public class CTFController : MonoBehaviour
{
    private bool flagGenerated;
    private TextMeshProUGUI flagText;

    private void Awake()
    {
       
        GameObject flagObj = GameObject.Find("FlagText");
        if (flagObj != null)
        {
            flagText = flagObj.GetComponent<TextMeshProUGUI>();
        }

        if (flagText == null)
        {
            Debug.LogError("FlagText not found or missing TextMeshProUGUI!");
        }
    }

    public void RequestFlagFromServer(int score)
    {
        if (flagGenerated || score != 3301)
            return;

        flagGenerated = true;

        string flag = "defcon_flag{ACE_OFFLINE_MODE_STUB_8ACAEDEA}";
        DisplayFlag(flag);
    }

    private void DisplayFlag(string flag)
    {
        if (flagText == null) return;

        flagText.text = flag;
        flagText.color = new Color(0.7f, 0f, 0f); // Dark red
        flagText.fontSize = 36;
        flagText.alignment = TextAlignmentOptions.Center;
        flagText.enableWordWrapping = true;
    }
}
