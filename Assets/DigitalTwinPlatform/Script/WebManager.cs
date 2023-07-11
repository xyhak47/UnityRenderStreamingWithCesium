using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;
using ZenFulcrum.EmbeddedBrowser;

public class WebManager : MonoBehaviour
{
    public static WebManager Instance = null;
    WebManager()
    {
        Instance = this;
    }

    private Browser browser;
    //private string target_url = "digital_twin.html";
    private string target_url = "main.html";

    

    private void Awake()
    {
        InitBrowser();
    }


    // Start is called before the first frame update
    void Start()
    {
        browser.GetComponent<RawImage>().enabled = true;
        WebInputHandler.Instance.Event_OnMousePosition.AddListener(OnUpdateMousePos);
        WebInputHandler.Instance.Event_OnMouseLeftClick.AddListener(OnMouseLeftClick);

    }

    public void InitBrowser()
    {
        browser = GetComponent<Browser>();

        target_url = Application.streamingAssetsPath + "/Browser/" + target_url;

        UnityWebRequest request = new UnityWebRequest (target_url);

        Debug.Log("InitBrowser = " + request.url);
        //browser.Url = target_url;

        browser.Url = request.url;
        request.Dispose();

        browser.RegisterFunction("call_unity", (JSONNode jk) =>
        {
            string html_call = "html_call = " + jk[0].Value as string;

            UIEventHandler.Instance.EventFromUI(WebUIEventName.FactoryWanderingBegin);
        });

        browser.RegisterFunction("open_effect", (JSONNode jk) =>
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.FactoryWanderingEnd);
        });

        browser.RegisterFunction("close_effect", (JSONNode jk) =>
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.CameraAutoRatoteSwitch);
        });

        browser.RegisterFunction("camera_rotate", (JSONNode jk) =>
        {
            UIEventHandler.Instance.EventFromUI(WebUIEventName.FactoryEnter);
        });

        browser.RegisterFunction("back", (JSONNode jk) =>
        {
    
        });
    }

    private void OnUpdateMousePos(Vector2 pos)
    {
        GetComponent<GUIBrowserUI>().input_mouse_pos = pos;
    }

    private void OnMouseLeftClick(bool clicked)
    {
        GetComponent<GUIBrowserUI>().mouse_left_clicked = clicked;
    }
}
