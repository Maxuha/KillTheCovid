using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static float timeGame;

    public void OnRestartButton()
    {
        LoadScene(0);
    }

    public static void LoadScene(int scene)
    {
        timeGame = 0;
        SceneManager.LoadScene(scene);
    }
}
