using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;
    GameController()
    {
        Instance = this;
    }

    public GameObject building;
    public GameObject flying_bar;

    public Text building_data;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
           // SpecialEffectMode(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //SpecialEffectMode(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
        }
    }

    public void SpecialEffectMode(bool on)
    {
        if(on)
        {
            building.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }
        else
        {
            building.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        }

        flying_bar.GetComponent<BloomLineFly>().Fly(on);
    }

    public void Back()
    {
    }

    public void UpdateBuildingData(string data)
    {
        building_data.text = data;
    }
}
