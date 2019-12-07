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
    private float scaleFactor = 10f;
    [SerializeField]
    private float slideDuration = 2f;

    private bool isSliding = false;
    private Vector3 previousPoint;
    private GameManager gameManager;
    private bool canThrow = true;

    private void Awake()
    {
        if(! powerSlider)
        {
            Debug.LogWarning("Power Slider not setted in Input Controller");
        }

        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(canThrow)
        {
            isSliding = true;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                (RectTransform) transform,
                eventData.position,
                Camera.main,
                out previousPoint);
            StartCoroutine(StopSlideCorutine());
        }
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
                (RectTransform) transform,
                eventData.position,
                Camera.main,
                out tmp);

            powerSlider.value += Vector3.Distance(previousPoint,tmp) / scaleFactor;
            previousPoint = tmp;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isSliding = false;
        ThrowBall();
    }

    private void ThrowBall()
    {
        if(canThrow)
        {
            gameManager.ThrowBall(powerSlider.value);
            canThrow = false;
        }
    }

    public void Reset()
    {
        powerSlider.value = 0f;
        canThrow = true;
    }
}
