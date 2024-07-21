using UnityEngine;

public class LightController : MonoBehaviour
{
    public float change = 10000; // Intensidade mínima
    public float original = 64766; // Intensidade máxima
    public Light pointLight;

    public void ChangeLightintensity(float change)
    {
        pointLight.intensity = change;
    }


    void Update()
    {
        if(CameraController.instance.nameCurrentFocus == "Mercurio" || CameraController.instance.nameCurrentFocus == "Venus")
        {
            ChangeLightintensity(change);
        } else
        {
            ChangeLightintensity(original);
        }
    }

    
}
