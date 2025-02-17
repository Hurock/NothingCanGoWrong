using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void InteractBegin();
    public void InteractEnd();
    public void OnInteract();
}
