using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    bool isLightOn;

    bool isLightFlickering;

    float timer;


    Light lightComp;

    [SerializeField] float delayBetweenFlicker;
    // Start is called before the first frame update
    void Start()
    {
        lightComp = GetComponent<Light>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (isLightOn && isLightFlickering)
        {
            timer += Time.deltaTime;
            if (timer > delayBetweenFlicker) 
            {
                lightComp.enabled = !lightComp.enabled;
                timer = 0f;
            }
        }
    }

    public void SetLightOn(bool lightOn)
    {
        isLightOn = lightOn;
        if (lightOn)
        {
            lightComp.enabled = true;
        }
        else
        {
            lightComp.enabled = false;
        }
    }

    public void SetFlickering(bool flickering)
    {
        isLightOn = true;
        isLightFlickering = flickering;
    }    
    public void ChangeColorToWhite()
    {
        lightComp.color = Color.white;
    }
}
