using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    List<LightBehaviour> lights = new();
    // Start is called before the first frame update
    void Start()
    {
        lights = FindObjectsOfType<LightBehaviour>().ToList();
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
