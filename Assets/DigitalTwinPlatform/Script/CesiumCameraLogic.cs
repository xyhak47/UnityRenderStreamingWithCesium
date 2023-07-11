using CesiumForUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.Networking;

public class CesiumCameraLogic : CameraLogic
{
    [SerializeField] private CustomCesiumCameraController cesium_camera_ctrl;
    [SerializeField] private Cesium3DTileset custom_building;
    [SerializeField] private CesiumSubScene sub_scene_city;


    private quaternion origin_rotation;
    private double3 origin_position;

    private InputActionMap map;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        RegisterSelf();


        origin_rotation = cesium_camera_ctrl.GetComponent<CesiumGlobeAnchor>().rotationGlobeFixed;
        origin_position = cesium_camera_ctrl.GetComponent<CesiumGlobeAnchor>().positionGlobeFixed;

        ConfigureInputs();

        LoadCustomBuilding();
        //cesium_camera_ctrl.GetComponent<CesiumFlyToController>().OnFlightComplete += LoadCustomBuilding;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ConfigureInputs()
    {
        map = WebInputHandler.Instance.GetCurrentInputActionMap();
        map.Disable();
        cesium_camera_ctrl.ConfigureInputs(map);
        map.Enable();

        map.FindAction("cesium_look").Disable();
    }

    public void LoadCustomBuilding()
    {
        string target_url = "file:///" + Application.streamingAssetsPath + "/Cesium/City/tileset.json";
        custom_building.url = target_url;
     }

    public override void EventFromUI(string event_name)
    {
        if (event_name == WebUIEventName.CesiumCameraReset)
        {
            cesium_camera_ctrl.GetComponent<CesiumGlobeAnchor>().rotationGlobeFixed = origin_rotation;
            cesium_camera_ctrl.GetComponent<CesiumGlobeAnchor>().positionGlobeFixed = origin_position;
        }
        else if (event_name == WebUIEventName.CesiumFlyToOrigin)
        {
            FlyToOrigin();
        }
    }

    public override void CheckClick(bool begin)
    {
        if(begin)
        {
            map.FindAction("cesium_look").Enable();
        }
        else
        {
            map.FindAction("cesium_look").Disable();
        }
    }

    private void FlyToOrigin()
    {
        double3 fly_to_pos = new double3(sub_scene_city.ecefX, sub_scene_city.ecefY, sub_scene_city.ecefZ);


        cesium_camera_ctrl.GetComponent<CesiumFlyToController>().
            FlyToLocationEarthCenteredEarthFixed(fly_to_pos, 13f, 20f, true);
    }
}
