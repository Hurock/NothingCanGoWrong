using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pipes : MonoBehaviour
{
    [SerializeField] private AudioClip[] blockSounds;
    public UnityEvent PipeClicked;
    private Vector3 newAngle;

    private void OnMouseDown()
    {
        //Debug.Log("Clicked");
        /*transform.Rotate(new Vector3(90, 0, 0));
        if(transform.rotation.x > 360)
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }*/
        newAngle += new Vector3(90, 0, 0);
        transform.localEulerAngles = newAngle;
        Debug.Log(transform.localEulerAngles.x);
        PipeClicked.Invoke();
        SoundFXManager.instance.PlayRandomSoundFXClip(blockSounds, transform, 1f);
    }
}
