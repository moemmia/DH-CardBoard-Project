using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    protected UnityEvent ActionEvent;

    [SerializeField]
    protected Slider ActionSlider;

    public float timeToActivate = .0f;

    public bool Action(float time) {
        if(time >= timeToActivate) {
            ActionEvent.Invoke();
            return true;
        } else {
            ActionSlider.value = time / timeToActivate;
            return false;
        }
    }

    public void ResetAction() {
        ActionSlider.value = 0;
    }
}
