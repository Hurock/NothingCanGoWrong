using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pipes : MonoBehaviour
{
    public UnityEvent PipeClicked;

    private void OnMouseDown()
    {
        //Debug.Log("Clicked");
        PipeClicked.Invoke();
    }
}
