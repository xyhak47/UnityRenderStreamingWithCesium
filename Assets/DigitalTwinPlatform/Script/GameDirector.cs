using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneLogic
{
   void Enter();
   void Exit();
}


public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance = null;
    GameDirector()
    {
        Instance = this;
    }

    [SerializeField] private GameObject[] Scenes;

    void Start()
    {
        //EnterScene("Earth");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterScene(SceneType scene_type)
    {
        FadeInOut.Instance.AutoFade(0f, () =>
        {
            foreach (var scene in Scenes)
            {
                if (scene.GetComponent<SceneLogic>().type  == scene_type)
                {
                    scene.GetComponent<SceneLogic>().Enter();
                }
                else
                {
                    scene.GetComponent<SceneLogic>().Exit();
                }
            }
        });
    }

    public void EventFromUI(string event_name)
    {
        if (event_name == WebUIEventName.Back)
        {
            EnterScene(SceneType.Earth);
        }
        else if(event_name == WebUIEventName.CesiumEarth)
        {
            EnterScene(SceneType.EarthCesium);
        }
        else if (event_name == WebUIEventName.FactoryEnter)
        {
            EnterScene(SceneType.Factory);
        }
    }
}
