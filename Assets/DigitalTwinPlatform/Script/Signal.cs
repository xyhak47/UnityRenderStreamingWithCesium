using UnityEngine;

public class Signal : MonoBehaviour
{
    Vector3 trans1;//记录原位置
    Vector2 trans2;//简谐运动变化的位置，计算得出

    public float zhenFu = 10f;//振幅
    public float HZ = 1f;//频率

    public GameObject ui;

    private void Awake()
    {
        trans1 = transform.localPosition;
    }

    private void Start()
    {
        SignalController.Instance.Add(this);
        ui.SetActive(false);
    }

    private void Update()
    {
        FloatAnimation();
    }

    public void CheckClick(bool begin)
    {
        if(begin)
        {
            RaycastHit hit;
            bool hitted = CameraController.Instance.CameraRayCast(out hit, gameObject.name);
            if(hit.collider && hit.collider.gameObject.GetComponent<Signal>() == this)
            {
                ui.SetActive(true);
            }
        }
    }

    private void FloatAnimation()
    {
        trans2 = trans1;
        trans2.y = Mathf.Sin(Time.fixedTime * Mathf.PI * HZ) * zhenFu + trans1.y;

        transform.localPosition = trans2;
    }
}
