using UnityEngine;

public class GameController : MonoBehaviour
{
    public new CameraController camera;

    public void DropdownSample(int i)
    {
        switch (i)
        {
            case 0: camera.ChangeFocusByNumber(0); break;
            case 1: camera.ChangeFocusByNumber(1); break;
            case 2: camera.ChangeFocusByNumber(2); break;
            case 3: camera.ChangeFocusByNumber(3); break;
            case 4: camera.ChangeFocusByNumber(4); break;
            case 5: camera.ChangeFocusByNumber(5); break;
            case 6: camera.ChangeFocusByNumber(6); break;
            case 7: camera.ChangeFocusByNumber(7); break;
            case 8: camera.ChangeFocusByNumber(8); break;
        }
    }
}
