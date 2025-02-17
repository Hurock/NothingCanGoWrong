using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void OnHoverBegin();
    public void OnHoverEnd();
    public void OnInteractBegin();
    public void OnInteractEnd();
}
