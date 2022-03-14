
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)] //S'effectue en premier
public class InputsManager : MonoBehaviour
{

    private TouchControls playerControls;
    private Camera mainCamera;

    #region Events

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    
    public delegate void TapTouch(ActionTypes actionTypes);
    public event TapTouch OnTapTouch;

    #endregion

    private void Awake()
    {
        playerControls = new TouchControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        TouchSimulation.Disable();
    }

    private void Start()
    {
        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx); //On s'abbonne à l'évent
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx); //On s'abbonne à l'évent
        playerControls.Touch.Contact.started += ctx => TapTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utilities.ScreenToWorld(mainCamera,playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()),(float)context.startTime);
    }  
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) OnEndTouch(Utilities.ScreenToWorld(mainCamera,playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()),(float)context.time);

    }

    private void TapTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnTapTouch != null) OnTapTouch(ActionTypes.Click);
        Debug.Log("Touch");
    }

    public Vector2 PrimaryPosition()
    {
        return Utilities.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

    

    /*
         public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;   
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
        private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
        TouchSimulation.Enable();
        

    }

    private void OnDisable()
    {
        touchControls.Disable();
        TouchSimulation.Disable();
        


    }
    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.started += ctx => EndTouch(ctx);

    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Started " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(),(float)context.startTime);
    } 
    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(),(float)context.time);

    }


    private void FingerDown(Finger finger)
    {
        if (OnStartTouch != null) OnStartTouch(finger.screenPosition,Time.time);

    }


    private void Update()
    {
        //UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches; //Pour avoir la liste des touch sur l'écran 
    }
    */
}
