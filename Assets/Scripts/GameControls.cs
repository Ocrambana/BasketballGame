using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    [SerializeField]
    private Slider powerSlider;
    [SerializeField]
    private float slideDuration = 2f;

    private bool isSliding = false,
                 canThrow = true;
    private Vector2 lastPoint = Vector2.zero;

    public void StartSlide(Vector3 startInput)
    {
        if (canThrow)
        {
            isSliding = true;
            lastPoint = Camera.main.ScreenToViewportPoint(startInput);
            StartCoroutine(CountdownToEndSlide());
        }
    }

    public IEnumerator CountdownToEndSlide()
    {
        yield return new WaitForSeconds(slideDuration);
        EndSlide();
    }

    public void Slide(Vector3 input)
    {
        if(isSliding)
        {
            Vector2 tmp = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float addSlide = tmp.y - lastPoint.y;
            powerSlider.value += addSlide;
            lastPoint = tmp;
        }
    }

    public void EndSlide()
    {
        if(isSliding)
        {
            isSliding = false;
            SendMessageToThrow();
        }
    }

    private void SendMessageToThrow()
    {
        if (canThrow)
        {
            SendMessage("ThrowBall", powerSlider.value);
            canThrow = false;
        }
    }

    private void Reset()
    {
        powerSlider.value = 0f;
        canThrow = true;
    }
}
