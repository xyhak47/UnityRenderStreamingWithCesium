using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public interface ICameraLogic
{
    void RegisterSelf();
    void CheckClick(bool begin);
    void CheckPosOnClick(Vector2 pos);
    void CheckClickAndMoveDelta(Vector2 pos);
    void CheckClickAndMovePosition(Vector2 pos);
    void EventFromUI(string event_name);
}


public class CameraController : MonoBehaviour
{
    public static CameraController Instance = null;
    CameraController()
    {
        Instance = this;
    }

    private List<GameObject> logics = new List<GameObject>();

    private Vector2 mouse_pos;


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        WebInputHandler.Instance.Event_OnMouseLeftClick.AddListener(CheckClick);
        WebInputHandler.Instance.Event_OnMousePositionOnClick.AddListener(CheckPosOnClick);
        WebInputHandler.Instance.Event_OnMouseClickAndMoveDelta.AddListener(CheckClickAndMoveDelta);
        WebInputHandler.Instance.Event_OnMouseClickAndMovePosition.AddListener(CheckClickAndMovePosition);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCameraLogic(GameObject logic)
    {
        logics.Add(logic);
    }

    private void CheckClick(bool begin)
    {
        if(logics != null)
        {
            logics.ForEach(i =>
            {
                if (i.gameObject.activeSelf)
                    i.GetComponent<ICameraLogic>().CheckClick(begin);
            });
        }
    }

    private void CheckPosOnClick(Vector2 pos)
    {
        if (logics != null)
        {
            mouse_pos = pos;
            logics.ForEach(i =>
            {
                if (i.gameObject.activeSelf)
                    i.GetComponent<ICameraLogic>().CheckPosOnClick(pos);
            });
        }
    }

    private void CheckClickAndMoveDelta(Vector2 pos)
    {
        if (logics != null)
        {
            logics.ForEach(i =>
            {
                if (i.gameObject.activeSelf)
                    i.GetComponent<ICameraLogic>().CheckClickAndMoveDelta(pos);
            });
        }
    }

    private void CheckClickAndMovePosition(Vector2 pos)
    {
        if (logics != null)
        {
            logics.ForEach(i =>
            {
                if (i.gameObject.activeSelf)
                    i.GetComponent<ICameraLogic>().CheckClickAndMovePosition(pos);
            });
        }
    }


    public bool CameraRayCast(out RaycastHit hit, string obj_name)
    {
        Ray ray = Camera.main.ScreenPointToRay(mouse_pos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.Log("射线碰撞到游戏物体的标签名: " + hit.collider.tag);
            //Debug.Log("射线碰撞到游戏物体的名字: " + hit.collider.name);
            //Debug.DrawLine(ray.origin, hit.point, Color.red);

            return obj_name == hit.collider.name;
        }

        return false;
    }

    public void EventFromUI(string event_name)
    {
        if (logics != null)
        {
            logics.ForEach(i =>
            {
                if (i.gameObject.activeSelf)
                    i.GetComponent<ICameraLogic>().EventFromUI(event_name);
            });
        }

    }
}
