using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    LightBehaviour[] lights;
    // Start is called before the first frame update
    void Start()
    {
        lights = FindObjectsOfType<LightBehaviour>();
    }

    public void TurnAllOff()
    {
        foreach (LightBehaviour light in lights)
        {
            light.SetLightOn(false);
        }
    }

    public void TurnAllOn()
    {
        foreach (LightBehaviour light in lights)
        {
            light.SetLightOn(true);
        }
    }
}
