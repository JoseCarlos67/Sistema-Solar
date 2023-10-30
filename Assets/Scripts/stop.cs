using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stop : MonoBehaviour
{
    public Text buttonText;
    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0; // Pausar a simulação
            buttonText.text = "Retomar";
        }
        else
        {
            Time.timeScale = 1; // Retomar a simulação
            buttonText.text = "Pausar";
        }
    }
}
