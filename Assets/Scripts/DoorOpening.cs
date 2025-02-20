using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] bool isDoorRotating;
    [SerializeField] bool isDoorSliding;

    [SerializeField] bool isDoorOpening;
    [SerializeField] bool isDoorClosing;

    private Quaternion startRotation;
    private Vector3 startPosition;

    [SerializeField] Quaternion desiredRotation;
    [SerializeField] Vector3 desiredPosition;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (isDoorRotating == isDoorSliding) Debug.LogError("Select only one door opening type");
        startRotation = transform.rotation;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDoorOpening)
        {
            if(isDoorRotating)
            {
                transform.rotation = Quaternion.Lerp(startRotation, desiredRotation, Time.deltaTime * speed);
            }
            if(isDoorSliding)
            {
                Vector3.Lerp(startPosition, desiredPosition, speed);
            }
        }
        if(isDoorClosing)
        {
            if (isDoorRotating)
            {
                Quaternion.Lerp(desiredRotation, startRotation, speed);
            }
            if (isDoorSliding)
            {
                Vector3.Lerp(desiredPosition, startPosition, speed);
            }
        }
    }


}
