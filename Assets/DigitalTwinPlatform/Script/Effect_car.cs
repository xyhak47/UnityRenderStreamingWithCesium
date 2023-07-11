using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_car : MonoBehaviour
{
    public LineRenderer carliu;
    public Material carcaizhi;
    public float Speed = 0.9f;
    public float offset = 0;//偏移量
    public XY xy = XY.Y;
  

    // Start is called before the first frame update
    void Start()
    {
        carcaizhi = carliu.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * Speed;
        if(xy == XY.X)
        {
            carcaizhi.SetTextureOffset("_MainTex",new Vector2(offset,0));
        }
        else
        {
            carcaizhi.SetTextureOffset("_MainTex", new Vector2(0,offset));
        }
        
    }
}
public enum XY
{
    X,
    Y
}
