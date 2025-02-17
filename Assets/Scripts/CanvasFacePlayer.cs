using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFacePlayer : MonoBehaviour
{
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform = Camera.main.transform;
        this.transform.LookAt(cameraTransform);
    }
}
