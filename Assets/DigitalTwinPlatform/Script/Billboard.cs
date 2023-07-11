using UnityEngine;

public class Billboard : MonoBehaviour
{

	Transform m_Camera;

	void Start()
	{
		// ��ȡ�������main camera
		m_Camera = Camera.main.transform;
	}

	// ��LateUpdate, ��ÿһ֡��������Canvas����
	void LateUpdate()
	{
		if (m_Camera == null)
		{
			return;
		}
		// �����ҵĽ�ɫ�����UI�������෴�ģ����ֱ����LookAt()����Ҫ��ÿ��UIԪ����ת������
		// Ϊ�˼򵥣��������������������ʵ������һ��������ת�����Լ����Ϊ��������������
		transform.rotation = Quaternion.LookRotation(transform.position - m_Camera.position);
	}
}
