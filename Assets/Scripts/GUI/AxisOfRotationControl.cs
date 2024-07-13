using UnityEngine;
using UnityEngine.UI;

public class AxisOfRotationControl : MonoBehaviour
{
    public GameObject test;
    public Toggle toggle;

    void Update()
    {
        if (toggle != null && !toggle.isOn)
        {
            test.SetActive(false);
        } else {
            test.SetActive(true);
        }
    }
}
