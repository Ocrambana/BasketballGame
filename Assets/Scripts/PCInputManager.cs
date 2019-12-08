using UnityEngine;
using UnityEditor;

public class PCInputManager : MonoBehaviour
{
    private GameControls gc;

    private void Start()
    {
        if(EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
        {
            this.enabled = false;
        }

        gc = GetComponent<GameControls>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gc.StartSlide(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            gc.Slide(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            gc.EndSlide();
        }
    }
}
