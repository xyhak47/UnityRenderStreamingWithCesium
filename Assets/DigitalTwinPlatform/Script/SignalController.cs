using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalController : MonoBehaviour
{
    public static SignalController Instance = null;
    SignalController()
    {
        Instance = this;
    }

    private List<Signal> signals = new List<Signal>();


    // Start is called before the first frame update
    void Start()
    {
        WebInputHandler.Instance.Event_OnMouseLeftClick.AddListener(CheckClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckClick(bool begin)
    {
        if (signals != null)
        {
            signals.ForEach(s => s.CheckClick(begin));
        }
    }

    public void Add(Signal signal)
    {
        signals.Add(signal);
    }
}
