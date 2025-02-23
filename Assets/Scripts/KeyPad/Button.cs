using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioClip buttonPress;
    public int keypadNumber = 1;

    public UnityEvent KeypadClicked;

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        KeypadClicked.Invoke();
        SoundFXManager.instance.PlaySoundFXClip(buttonPress, transform, 1f);
    }
}
