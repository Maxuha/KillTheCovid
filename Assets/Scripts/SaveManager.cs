using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static int Load()
    {
        if (PlayerPrefs.HasKey("Record"))
        {
            return PlayerPrefs.GetInt("Record");
        }
        return 0;
    }

    public static void Save(int record)
    {
        PlayerPrefs.SetInt("Record", record);
    }
}
