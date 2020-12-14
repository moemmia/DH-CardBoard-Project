using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlowController : MonoBehaviour
{

    public float timeToWait = 120;
    [SerializeField]
    protected UnityEvent ActionEvent;

    void Start() {
        StartCoroutine(waitToEndScene(timeToWait));
    }

    IEnumerator waitToEndScene(float time) {
        yield return new WaitForSeconds(time);
        ActionEvent.Invoke();
    }

}
