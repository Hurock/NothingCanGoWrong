using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CandleRoomLock : MonoBehaviour
{
    public UnityEvent OnTriggerCloseDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnTriggerCloseDoor.Invoke();
            this.gameObject.SetActive(false);
        }    
    }
}
