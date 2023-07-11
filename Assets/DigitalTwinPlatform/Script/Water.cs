using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private float TextureOffset_y = 0;
    private Material mat_water;
    // Start is called before the first frame update
    void Start()
    {
        mat_water = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        TextureOffset_y += Time.deltaTime;
        mat_water.SetTextureOffset("_MainTex", new Vector2(0, TextureOffset_y));
    }
}
