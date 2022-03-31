using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float minimumDistance = .2f;
    [SerializeField] private float maximumTime = 1.0f;
    [SerializeField][Range(0,1)] private float directionThresold = .9f;
    
    
    private InputsManager inputsManager;

    private Vector2 startPosition;
    private float startTime;

    private Vector2 endPosition;
    private float endTime;
    
    public delegate void Swipe(ActionTypes swipeType);
    public event Swipe Swipping;
    private void Awake()
    {
        inputsManager = FindObjectOfType<InputsManager>();
    }

    private void OnEnable()
    {
        inputsManager.OnStartTouch += SwipeStart;
        inputsManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputsManager.OnStartTouch -= SwipeStart;
        inputsManager.OnEndTouch -= SwipeEnd;
    }


    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }   
    
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximumTime)
        {
            Debug.DrawLine(startPosition,endPosition,Color.red,5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
            //Debug.Log("Swipe Detected " + direction2D);

        }
            
    }


    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.left, direction) > directionThresold)
        {
            Debug.Log("SwipeLeft");
            if (Swipping != null) Swipping(ActionTypes.SwipeLeft);
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThresold)
        {
            Debug.Log("SwipeRight");
            if (Swipping != null) Swipping(ActionTypes.SwipeRight);

        }
    }
    
}
