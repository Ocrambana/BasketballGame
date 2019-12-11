using UnityEngine;

public class PCInputManager : MonoBehaviour
{
    private GameControls gc;

    private void Start()
    {
        gc = GetComponent<GameControls>();
        enabled = false;
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

    public void ActivateInput()
    {
        enabled = true;
    }

    public void DeactivateInput()
    {
        enabled = false;
    }
}
