using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour {

    private Camera _camera;
    private GameObject bullet;
    public GameObject bulletPrefab;
    public GameObject bulletInitialPosition;

    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                bullet = Instantiate(bulletPrefab) as GameObject;
                bullet.transform.position = bulletInitialPosition.transform.position;
                bullet.transform.LookAt(hit.point);
            }
        }
    }

    void OnGUI()
    {
        int size = 24;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
