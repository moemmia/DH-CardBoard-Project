using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    Transform _transform;
    Transform _target;

    void Awake() {
        _transform = GetComponent<Transform>();
    }
    
    void Start() { 
        _target = Camera.main.GetComponent<Transform>();
    }


    void Update() {
        _transform.LookAt(_target);
    }
}
