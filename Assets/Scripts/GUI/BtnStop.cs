using UnityEngine;
using UnityEngine.UI;

public class BtnStop : MonoBehaviour
{
    [SerializeField]private Button ButtonStop;
    private bool isPaused = false;
    [SerializeField]private Traslation traslation;

    private void Awake()
    {
        ButtonStop.onClick.AddListener(OnButtonStopClick);
    }

    private void OnButtonStopClick()
    {
        Debug.Log("Stop");
        isPaused = !isPaused;
        if (isPaused)
        {
            //Time.timeScale = 0; // Pausar a simula��o
            StopAllCoroutines();
            traslation.StopAllCoroutines();
        }
        else
        {
            Time.timeScale = 1;  // Rotomar a simula��o
        }
    }

}
