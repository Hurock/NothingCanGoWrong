using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cable : MonoBehaviour
{
    public bool isCorrectCable;

    public UnityEvent OnCableCut;

    private void OnMouseDown()
    {
        OnCableCut.Invoke();
    }
}
