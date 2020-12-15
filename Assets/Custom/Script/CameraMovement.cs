using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity;
    public float velocity;
    Transform _transform;
    void Awake() {
        _transform = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        _transform.localEulerAngles = _transform.localEulerAngles + Time.deltaTime * mouseSensitivity * new Vector3 (-mouseY, mouseX, 0.0f);
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _transform.Translate(new Vector3(horizontal,0.0f, vertical) * Time.deltaTime * velocity);
    }
}
