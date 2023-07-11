using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryCameraLogic : CameraLogic
{
    private Vector3 origin_pos;
    private Quaternion origin_rotation;

    void Start()
    {
        RegisterSelf();

        origin_pos = transform.position;
        origin_rotation = transform.rotation;
    }

    void Update()
    {

    }

    public override void CheckClick(bool begin)
    {
        GetComponent<CameraFreelook>().mouse_click_left = begin;

        if (begin)
        {
        }
    }

    public override void CheckPosOnClick(Vector2 pos)
    {

    }

    public override void CheckClickAndMoveDelta(Vector2 offset)
    {
        GetComponent<CameraFreelook>().mouse_click_left = true;
        GetComponent<CameraFreelook>().offset = offset;
    }

    public override void CheckClickAndMovePosition(Vector2 pos)
    {

    }

    public override void EventFromUI(string event_name)
    {
        if(event_name == WebUIEventName.FactoryWanderingBegin)
        {
            PlayAnimation(true);
        }
        else if (event_name == WebUIEventName.FactoryWanderingEnd)
        {
            PlayAnimation(false);
        }
        else if (event_name == WebUIEventName.CameraAutoRatoteSwitch)
        {
            GetComponent<CameraFreelook>().autoRotate = !GetComponent<CameraFreelook>().autoRotate;
        }
    }


    private void PlayAnimation(bool begin)
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = begin;
        if(begin)
        {
            animator.SetTrigger("Play");
        }
        else
        {
            CameraSetToOrigin();
        }
    }

    private void CameraSetToOrigin()
    {
        transform.position = origin_pos;
        transform.rotation = origin_rotation;
    }
}
