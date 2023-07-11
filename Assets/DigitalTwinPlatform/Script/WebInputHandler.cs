using Custom.RenderStreaming.WebInput;
using System.Collections;
using System.Collections.Generic;
using Unity.RenderStreaming;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;



public class WebInputHandler : MonoBehaviour
{
    [HideInInspector] public UnityEvent<bool> Event_OnMouseLeftClick = new UnityEvent<bool>();
    [HideInInspector] public UnityEvent<Vector2> Event_OnMousePosition = new UnityEvent<Vector2>();
    [HideInInspector] public UnityEvent<Vector2> Event_OnMousePositionOnClick = new UnityEvent<Vector2>();
    [HideInInspector] public UnityEvent<Vector2> Event_OnMouseDelta = new UnityEvent<Vector2>();
    [HideInInspector] public UnityEvent<Vector2> Event_OnMouseDeltaOnClick = new UnityEvent<Vector2>();

    [HideInInspector] public UnityEvent<Vector2> Event_OnMouseClickAndMoveDelta = new UnityEvent<Vector2>();
    [HideInInspector] public UnityEvent<Vector2> Event_OnMouseClickAndMovePosition = new UnityEvent<Vector2>();

    public static WebInputHandler Instance = null;
    WebInputHandler()
    {
        Instance = this;
    }

    private Vector2 mouse_pos;
    private Vector2 mouse_delta;


    private bool left_has_clicked = false;

    private void Awake()
    {
        GetComponent<VideoStreamSender>().SetBitrate(16000, 160000);
        GetComponent<WebBrowserInputChannelReceiver>().Event_OnWebButtonClick.AddListener(OnWebButtonClick);
    }

    void Start()
    {
    }


    public void OnWebButtonClick(int id)
    {
        Debug.Log("OnWebButtonClick = " + id);
        if (id == 10)
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.Back);
        }
        else if(id == 11)
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.EarthForward);
        }
        else if (id == 12)
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.EarthBackward);
        }
        else if (id == 13)
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.CesiumFlyToOrigin);
        }
        else if (id == 14)
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.CesiumCameraReset);
        }
        else if (id == 15)
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.CesiumEarth);
        }
    }

    public void OnLeftButtonClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("OnLeftButtonClick performed");
            Event_OnMouseLeftClick.Invoke(true);
            Event_OnMousePositionOnClick.Invoke(mouse_pos);
            Event_OnMouseDeltaOnClick.Invoke(mouse_delta);

            left_has_clicked = true;
        }
        else if (context.canceled)
        {
            Event_OnMouseLeftClick.Invoke(false);

            left_has_clicked = false;
        }
    }

    public void OnMoveDelta(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mouse_delta = context.ReadValue<Vector2>();
            Event_OnMouseDelta.Invoke(mouse_delta);
            //Debug.Log("OnMoveDelta performed : " + context.ReadValue<Vector2>());

            if(left_has_clicked)
            {
                Event_OnMouseClickAndMoveDelta.Invoke(mouse_delta);
            }
        }
    }

    public void OnMovePosition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mouse_pos = context.ReadValue<Vector2>();
            Event_OnMousePosition.Invoke(mouse_pos);
            //Debug.Log("Event_OnMousePositionOnClick : " + context.ReadValue<Vector2>());

            if (left_has_clicked)
            {
                Event_OnMouseClickAndMovePosition.Invoke(mouse_pos);
            }
        }
    }

    public InputActionMap GetCurrentInputActionMap()
    {
        return GetComponent<InputReceiver>().currentActionMap;
    }
}