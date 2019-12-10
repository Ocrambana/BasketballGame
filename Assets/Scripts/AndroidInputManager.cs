using UnityEngine;

public class AndroidInputManager : MonoBehaviour
{
    private GameControls gc;

    private void Start()
    {
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
