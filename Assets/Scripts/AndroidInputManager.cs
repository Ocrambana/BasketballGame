using UnityEngine;
using UnityEditor;

public class AndroidInputManager : MonoBehaviour
{
    private GameControls gc;

    private void Start()
    {
        if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows ||
            EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows64)
        {
            this.enabled = false;
        }

        gc = GetComponent<GameControls>();
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                gc.StartSlide(t.position);
            }

            if (t.phase == TouchPhase.Moved)
            {
                gc.Slide(t.position);
            }
        }
        else
        {
            gc.EndSlide();
        }
    }
}
