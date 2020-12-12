using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    protected Transform _transform;

    protected RaycastHit _hit;
    protected ActionController _currentObj;
    protected float startTime;

    protected float _timeToActivate;

    void Start () {
        _transform = GetComponent<Transform>();
    }

    void Update() {
        CheckRayActions();
    }

    void CheckRayActions () {
        if(Physics.Raycast(_transform.position, _transform.forward, out _hit)) {

            var h = _hit.collider.GetComponent<ActionController>();
            if (h) {
                if(h == _currentObj){
                    if(Time.time - startTime >= _timeToActivate) {
                        _currentObj.Action.Invoke();
                        startTime = Time.time;
                    }
                } else {
                    _currentObj = h;
                    startTime = Time.time;
                    _timeToActivate = _currentObj.timeToActivate;
                }
            }

        } else {

            _currentObj = null;

        }
    }

    public void TraslateTo(Transform go) {
        Vector3 pos = go.position;
        _transform.position = new Vector3(pos.x,_transform.position.y,pos.z);
    }

}
