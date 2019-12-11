using UnityEngine;

public class AndroidInputManager : MonoBehaviour
{
    private GameControls gc;

    private void Start()
    {
        gc = GetComponent<GameControls>();
        enabled = false;
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

    public void ActivateInput()
    {
        enabled = true;
    }

    public void DeactivateInput()
    {
        enabled = false;
    }
}
