using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameController : MonoBehaviour
{
    
    protected Transform _transform;
    protected Transform _parent;
    protected Transform _target;

    void Awake() {
        _transform = GetComponent<Transform>();
        _parent = _transform.parent;
    }

    
    void Start() { 
        _target = Camera.main.GetComponent<Transform>();
    }

    void Update() {
        CheckRotation();
    }

    void CheckRotation() {
        Vector3 dir1 = new Vector3(_transform.position.x, .0f, _transform.position.z) - new Vector3(_parent.position.x, .0f, _parent.position.z);
        Vector3 dir2 = new Vector3(_target.forward.x, .0f, _target.forward.z);
        float angle = Vector3.SignedAngle(dir1, dir2, Vector3.up);
        _transform.RotateAround(_parent.position, Vector3.up, angle * Time.deltaTime);
    }

}
