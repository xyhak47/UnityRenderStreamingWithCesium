using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CityCameraLogic : CameraLogic
{
    //[SerializeField] private GameObject building;
    private InputActionMap map;

     void Start()
    {
        RegisterSelf();

                
        map = WebInputHandler.Instance.GetCurrentInputActionMap();
        map.Disable();
        GetComponent<CustomFreeCamera>().RegisterInputs(map);
        map.Enable();

        map.FindAction("city_look").Disable();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void CheckClick(bool begin)
    {
        if (begin)
        {
            map.FindAction("city_look").Enable();
        }
        else
        {
            map.FindAction("city_look").Disable();
        }
    }
}
