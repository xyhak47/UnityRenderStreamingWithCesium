using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebUIEventName
{
    // camera
    public static string CameraAutoRatoteSwitch = "CameraAutoRatoteSwitch";

    // cesium
    public static string CesiumEarth = "CesiumEarth";
    public static string CesiumCameraReset = "CesiumCameraReset";
    public static string CesiumFlyToOrigin = "CesiumFlyToOrigin";

    // earth
    public static string EarthForward = "EarthForward";
    public static string EarthBackward = "EarthBackward";

    // factory
    public static string FactoryWanderingBegin = "FactoryWanderingBegin";
    public static string FactoryWanderingEnd = "FactoryWanderingEnd";
    public static string FactoryEnter = "FactoryEnter";

    // city
    public static string Effect = "Effect";


    // game
    public static string Back = "Back";

}


public class UIEventHandler : MonoBehaviour
{
    public static UIEventHandler Instance = null;
    UIEventHandler()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    public void EventFromUI(string event_name)
    {
        CameraController.Instance.EventFromUI(event_name);
        GameDirector.Instance.EventFromUI(event_name);
    }
}
