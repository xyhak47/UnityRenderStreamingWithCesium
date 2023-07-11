using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MousePosUI : MonoBehaviour
{
    public UnityEvent<bool> Event_OnMouseLeftClick = new UnityEvent<bool>();
    public UnityEvent<Vector2> Event_OnMousePosition = new UnityEvent<Vector2>();

    private void Awake()
    {
        WebInputHandler.Instance.Event_OnMouseLeftClick.AddListener(OnMouseLeftClick);
        WebInputHandler.Instance.Event_OnMousePosition.AddListener(OnMousePosUpdate);
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseLeftClick(bool begin_or_end)
    {
        GetComponent<Image>().enabled = begin_or_end;
    }

    private void OnMousePosUpdate(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition = pos;
        GetComponent<Image>().color = Color.red;
    }
}
