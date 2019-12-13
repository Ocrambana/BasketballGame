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
    private Vector2 firstPoint = Vector2.zero;
    private Vector3 throwPower;

    public void StartSlide(Vector3 startInput)
    {
        if (canThrow)
        {
            isSliding = true;
            firstPoint = Camera.main.ScreenToViewportPoint(startInput);
            lastPoint = firstPoint;
            StartCoroutine(CountdownToEndSlide());
            throwPower = Vector3.zero;
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
            Vector2 tmp = Camera.main.ScreenToViewportPoint(input);
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
            throwPower.x += powerSlider.value; 
            throwPower.z += powerSlider.value; 
            SendMessage("ThrowBall", throwPower);
            canThrow = false;
        }
    }

    private void Reset()
    {
        powerSlider.value = 0f;
        canThrow = true;
    }
}
