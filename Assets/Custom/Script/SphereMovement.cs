using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    protected Transform _transform;

    public float size = 1;

    void Awake() {
        _transform = GetComponent<Transform>();
    }

    void Update() {
        _transform.Translate(new Vector3(Mathf.Sin(Time.time), Mathf.Cos(Time.time), .0f) * Time.deltaTime * size);
    }
}
