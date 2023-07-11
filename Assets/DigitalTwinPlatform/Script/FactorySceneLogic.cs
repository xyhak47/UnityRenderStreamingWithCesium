using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySceneLogic : SceneLogic
{
    [SerializeField] private Material skybox;


    // Start is called before the first frame update
    void Start()
    {
        //if (skybox) RenderSettings.skybox = skybox;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
