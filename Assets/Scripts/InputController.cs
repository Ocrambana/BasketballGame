using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Slider powerSlider;
    [SerializeField]
    private float scalefactor = 10f;
    [SerializeField]
    private float slideDuration = 2f;

    private bool isSliding = false;
    private Vector3 previousPoint;
    private GameObject ball;

    private void Awake()
    {
        if(! powerSlider)
        {
            Debug.LogWarning("Power Slider not setted in Input Controller");
        }
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isSliding = true;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            (RectTransform)transform,
            eventData.position,
            Camera.main,
            out previousPoint);
        StartCoroutine(StopSlideCorutine());
    }

    public IEnumerator StopSlideCorutine()
    {
        yield return new WaitForSeconds(slideDuration);
        isSliding = false;
        ThrowBall();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isSliding)
        {
            Vector3 tmp;

            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                (RectTransform)transform,
                eventData.position,
                Camera.main,
                out tmp);

            powerSlider.value += Vector3.Distance(previousPoint,tmp) / scalefactor;
            previousPoint = tmp;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ThrowBall();
    }

    private void ThrowBall()
    {

    }
}
