using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    private void Awake()
    {
        Camera _camera = Camera.main;

        if (_camera != null)
        {
            _camera.transform.SetParent(transform);
            _camera.transform.localPosition = new Vector3(0, 10, -6);
            _camera.transform.localRotation = Quaternion.Euler(36, 0, 0);
        }
        else
        {
            Debug.LogError("���� ī�޶� ã�� �� �����ϴ�.");
        }

        controller = GetComponent<PlayerController>();
    }
}
