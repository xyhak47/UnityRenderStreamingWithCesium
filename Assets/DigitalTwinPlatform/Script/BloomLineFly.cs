using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomLineFly : MonoBehaviour
{
    private bool begin_fly = false;
    private float begin_pos_y = -14f;
    private float end_pos_y = 14f;
    private Vector3 origin_pos;
    float new_y;

    // Start is called before the first frame update
    void Start()
    {
        origin_pos = transform.localPosition;
        new_y = begin_pos_y;
    }

    // Update is called once per frame
    void Update()
    {
        if (begin_fly)
        {
            new_y = Mathf.Lerp(new_y, end_pos_y, Time.deltaTime);
            //Debug.Log("new_y = " + new_y);


            float new_x = transform.localPosition.x;
            float new_z = transform.localPosition.z;
            if (new_y >= end_pos_y -1f)
            {
                new_y = begin_pos_y;

                new_x = Random.Range(-15f, 15f);
                new_z = Random.Range(-15f, 15f);
            }

            transform.localPosition = new Vector3(new_x, new_y, new_z);
        }
        else
        {
  
            transform.localPosition = origin_pos;
        }

    }

    public void Fly(bool begin)
    {
        begin_fly = begin;
    }
}
