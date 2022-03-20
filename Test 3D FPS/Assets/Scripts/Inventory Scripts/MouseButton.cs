using UnityEngine;

public class MouseButton : MonoBehaviour
{
    public static bool mouseButtonDown;
    private bool mouseButtonDown_1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !mouseButtonDown_1)
        {
            mouseButtonDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseButtonDown = false;
        }
    }
}
