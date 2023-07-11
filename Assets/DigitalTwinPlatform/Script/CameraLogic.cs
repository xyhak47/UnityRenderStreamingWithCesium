using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour, ICameraLogic
{
    private void Start()
    {
        
    }

    public virtual void RegisterSelf()
    {
        CameraController.Instance.AddCameraLogic(gameObject);
    }


    public virtual void CheckClick(bool begin)
    {
    }

    public virtual void CheckPosOnClick(Vector2 pos)
    {

    }

    public virtual void CheckClickAndMoveDelta(Vector2 pos)
    {
    }

    public virtual void CheckClickAndMovePosition(Vector2 pos)
    {

    }

    public virtual void EventFromUI(string event_name)
    {

    }
}
