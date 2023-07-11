using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCameraLogic : CameraLogic
{
    private bool hit_earth_point_need_lerp = false;
    [SerializeField] private GameObject earth;
    [SerializeField] private GameObject target;
    private float lerp_speed = 5.0f;

    private Vector3 origin_postion;
    private Quaternion origin_rotation;

    private float fov_max = 60f;
    private float fov_min = 30f;
    private float fov_step = 10f;
    private float fov_target;
    private float origin_distance;



    // Start is called before the first frame update
    void Start()
    {
        RegisterSelf();

        transform.parent.GetComponent<SceneLogic>().OnExit.AddListener(ResetLogic);

        origin_postion = transform.position;
        origin_rotation = transform.rotation;

        fov_target = Camera.main.fieldOfView;

    }

    public override void CheckClick(bool begin)
    {
        if (begin)
        {
        }
    }

    public override void CheckPosOnClick(Vector2 pos)
    {
        CheckHitEarthPoint();
    }

    private void CheckHitEarthPoint()
    {
        RaycastHit hit;
        bool result = CameraController.Instance.CameraRayCast(out hit, earth.name);
        if (result)
        {
            target.transform.position = hit.point;
            target.transform.LookAt(earth.transform);
            target.transform.Rotate(new Vector3(-90, 0, 0));
            target.transform.Rotate(new Vector3(0, 90, 0));

            hit_earth_point_need_lerp = true;

            origin_distance = Vector3.Distance(transform.position, target.transform.position);
        }
    }

    public override void CheckClickAndMoveDelta(Vector2 delta)
    {
        HandleEarthView(delta);
    }

    public override void CheckClickAndMovePosition(Vector2 pos)
    {
    }

    public override void EventFromUI(string event_name)
    {
        if(event_name == WebUIEventName.EarthForward)
        {
            ChangeDistanceToEarth(true);
        }
        if (event_name == WebUIEventName.EarthBackward)
        {
            ChangeDistanceToEarth(false);
        }
    }

    void Update()
    {
        if (hit_earth_point_need_lerp)
        {
            LerpToEarthPoint();
        }

        LerpFOV();
    }

    private void LerpToEarthPoint()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        transform.position = Vector3.Lerp(transform.position, target.transform.position, 
            Time.deltaTime * lerp_speed);

        // distance : origin_distance -> 0 , distance/origin_distance : 1 -> 0
        // 1 - distance/origin_distance : 0 -> 1
        transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, 
            Time.deltaTime * lerp_speed * (1 - distance / origin_distance) * 1.0f);

        Debug.Log("distance = " + distance);
        if (distance < 1f)
        {
            hit_earth_point_need_lerp = false;
            GameDirector.Instance.EnterScene(SceneType.City);
        }
    }

    private void ResetLogic()
    {
        transform.position = origin_postion;
        transform.rotation = origin_rotation;
    }

    private void HandleEarthView(Vector2 offset)
    {
        offset *= 0.02f;
        float xMove = offset.x;
        float yMove = offset.y;

        //Debug.Log("xMove = " + xMove);
        //Debug.Log("yMove = " + yMove);

        Vector2 offCenter = Vector2.zero;
        float targetRadius = 100; 
        float dist = 400;

        float rotateSensitivity = Mathf.Min(2f, (float)((dist - targetRadius) / targetRadius) * 1.2f);

        Quaternion quat = (Quaternion.AngleAxis(rotateSensitivity * xMove, Vector3.up) *
                Quaternion.AngleAxis(rotateSensitivity * yMove, Vector3.left));

        transform.rotation *= quat;

        Vector3 new_pos = transform.rotation * (-Vector3.forward * dist);
        new_pos += new Vector3(transform.right.x * offCenter.x + transform.up.x * offCenter.y,
                                            transform.right.y * offCenter.x + transform.up.y * offCenter.y,
                                            transform.right.z * offCenter.x + transform.up.z * offCenter.y);

        //transform.position = Vector3.Lerp(transform.position, new_pos, Time.deltaTime);
        transform.position = new_pos;
    }

    private void ChangeDistanceToEarth(bool forward)
    {
        float fov_delta = fov_step;
        fov_delta *= forward ? -1 : 1;
        fov_target += fov_delta;
        fov_target = Mathf.Clamp(fov_target, fov_min, fov_max);
    }

    private void LerpFOV()
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fov_target, Time.deltaTime * 5f);

        if (Mathf.Abs(Camera.main.fieldOfView - fov_target) >= 0.01f)
        {
           // Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fov_target, Time.deltaTime * 5f);
        }
        else
        {
            //Camera.main.fieldOfView = fov_target;
        }
    }
}
