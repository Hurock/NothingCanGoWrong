using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    bool isDoorOpen = false;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetBool("IsDoorOpen", true);
    }

    public void CloseDoor()
    {
        anim.SetBool("IsDoorOpen", false);
    }
}
