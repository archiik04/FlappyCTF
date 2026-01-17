using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CTFController : MonoBehaviour
{
    // Import native function from SecretValidation.dll
    [DllImport("SecretValidation", CallingConvention = CallingConvention.Cdecl)]
    private static extern void CalculateFinalFlag(
        int score,
        float xPos,
        string deviceID,
        IntPtr outBuf,
        int bufLen
    );

    private bool flagGenerated = false;

    public void GenerateFlagOnce(int score)
    {
        if (flagGenerated)
            return;

        flagGenerated = true;

        float xPos = 0.0f; // deterministic
        string deviceID = "UNITY_DEVICE"; // deterministic for CTF

        IntPtr buffer = Marshal.AllocHGlobal(256);

        try
        {
            CalculateFinalFlag(score, xPos, deviceID, buffer, 256);
            string flag = Marshal.PtrToStringAnsi(buffer);
            Debug.Log("FLAG: " + flag);
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }
}
