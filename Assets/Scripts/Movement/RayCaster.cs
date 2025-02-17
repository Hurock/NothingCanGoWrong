using System;
using System.Collections;
using UnityEngine;

public class RayCaster : MonoBehaviour 
{

    public Transform cameraTransform;
    public Transform EndTransform;
    public Vector3 Direction;
    public float RayLength;
    public LayerMask layerMask;

    public event Action<Collider> OnRayEnter;
    public event Action<Collider> OnRayStay;
    public event Action<Collider> OnRayExit;

    Collider previous;
    RaycastHit hit = new RaycastHit();

    private void Start()
    {
        
        layerMask = LayerMask.GetMask("Interactable", "Character");
    }

    private void FixedUpdate()
    {
        cameraTransform = Camera.main.transform;
        CastRay();
    }

    public bool CastRay()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Hit: " + hit.transform.gameObject.name);
            hit.transform.SendMessage("InteractBegin");

        }
        else
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward) * 1000, Color.red);
            //Debug.Log("Did not Hit");
        }
        ProcessCollision(hit.collider);
        return hit.collider != null ? true : false;
    }

    public bool CastLine()
    {
        Physics.Linecast(cameraTransform.position, EndTransform.position, out hit, layerMask);
        ProcessCollision(hit.collider);
        return hit.collider != null ? true : false;
    }

    private void ProcessCollision(Collider current)
    {
        // No collision this frame.
        if (current == null)
        {
            // But there was an object hit last frame.
            if (previous != null)
            {
                if(previous.gameObject.GetComponent<BaseItems>())
                {
                    var temp = previous.gameObject.GetComponent<BaseItems>() as IInteractable;
                    if (temp != null)
                    {
                        temp.InteractEnd();
                    }
                }
            }
        }

        // The object is the same as last frame.
        else if (previous == current)
        {
            if (Input.GetKey(KeyCode.E))
            {
                var temp = previous.gameObject.GetComponent<BaseItems>() as IInteractable;
                if (temp != null)
                {
                    temp.OnInteract();
                }
            }
        }

        // The object is different than last frame.
        else if (previous != null)
        {
            if (previous.gameObject.GetComponent<BaseItems>())
            {
                var temp = previous.gameObject.GetComponent<BaseItems>() as IInteractable;
                if (temp != null)
                {
                    temp.InteractEnd();
                }
            }

            if (current.gameObject.GetComponent<BaseItems>())
            {
                var temp = current.gameObject.GetComponent<BaseItems>() as IInteractable;
                if (temp != null)
                {
                    temp.InteractBegin();
                }
            }
        }

        // There was no object hit last frame.
        else
        {
            if (current.gameObject.GetComponent<BaseItems>())
            {
                var temp = current.gameObject.GetComponent<BaseItems>() as IInteractable;
                if (temp != null)
                {
                    temp.InteractBegin();
                }
            }
        }

        // Remember this object for comparing with next frame.
        previous = current;
    }


    private void DoEvent(Action<Collider> action, Collider collider)
    {
        if (action != null)
        {
            action(collider);
        }
    }

}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{

    private Transform cameraTransform;

    LayerMask layerMask;

    private Collider previous;

    [SerializeField] private GameObject InteractPrefab;

    private void Start()
    {
        
        layerMask = LayerMask.GetMask("Interactable", "Character");
    }

    
    void FixedUpdate()
    {
        RaycastHit hit;
        cameraTransform = Camera.main.transform;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Hit: " + hit.transform.gameObject.name);
            hit.transform.SendMessage("InteractBegin");

        }
        else
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward) * 1000, Color.red);
            //Debug.Log("Did not Hit");
        }
    }
}
*/
