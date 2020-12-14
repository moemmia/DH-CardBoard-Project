using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    protected Transform _transform;
    protected Transform _target;
    protected RaycastHit _hit;
    protected ActionController _currentObj;
    protected float startTime;

    void Awake () {
        _transform = GetComponent<Transform>();
    }
    
    void Start() { 
        _target = Camera.main.GetComponent<Transform>();
    }

    void Update() {
        CheckRayActions();
    }

    void CheckRayActions () {
        if(Physics.Raycast(_target.position, _target.forward, out _hit)) {
            var h = _hit.collider.GetComponent<ActionController>();
            if (h) {
                if(h == _currentObj){
                    if(_currentObj.Action(Time.time - startTime)){
                        startTime = Time.time;
                    }
                } else {
                    _currentObj?.ResetAction();
                    _currentObj = h;
                    startTime = Time.time;
                }
            } else {
                _currentObj?.ResetAction();
                _currentObj = null;
            }
        } else {
            _currentObj?.ResetAction();
            _currentObj = null;
        }
    }

    public void TraslateTo(Transform go) {
        Vector3 pos = go.position;
        _transform.position = new Vector3(pos.x,_transform.position.y,pos.z);
    }

}
