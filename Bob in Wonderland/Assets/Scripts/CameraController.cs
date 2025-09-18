using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed = 40f; // ����� �������� ������� ��� �����������
    private Transform ground; // ��������� ��� �� Transform ��� �������

    void Start()
    {
        // ���������� �� GameObject ��� ������� �� ����� "Ground" ��� Unity Editor
        GameObject groundObject = GameObject.Find("Ground");
        if (!groundObject)
        {
            Debug.LogError("Ground object not found in the scene. Please ensure there is a GameObject named 'Ground'.");
            this.enabled = false; // �������������� ��� script �� ��� ������ �� ground
            return;
        }
        ground = groundObject.transform;
    }


    void Update()
    {
        // ������ ���� �� ������ ��� ���� ���� ����� z ��� �������
        float forwardMovement = Input.GetAxis("Vertical");
        transform.Translate(0, 0, forwardMovement * speed * Time.deltaTime);

        // ������ ���� ��� ���� ���� ��������� ���� (���� ����� y)
        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.KeypadPlus))
        {
            transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
        }

        // ���������� ���� ��� ��� ����� y ��� ground ��������������� �� Horizontal axis
        float rotation = Input.GetAxis("Horizontal") * (-speed) * Time.deltaTime;
        transform.RotateAround(ground.position, Vector3.up, rotation);
    }
}
