using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cable : MonoBehaviour
{
    [SerializeField] private AudioClip electricWire;
    public bool isCorrectCable;

    public UnityEvent OnCableCut;

    private void OnMouseDown()
    {
        OnCableCut.Invoke();
        SoundFXManager.instance.PlaySoundFXClip(electricWire, transform, 1f);
    }
}
