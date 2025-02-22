using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Valve : BaseItems
{
    public bool isInteractable = true;

    public int currentPosition = 3;

    public UnityEvent OnValveChange;

    [SerializeField] private GameObject VFX;

    [SerializeField] float delayTimer = 1;
    bool isTimerOn = false;
    float timer;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerOn)
        {
            timer += Time.deltaTime;
            if (timer > delayTimer )
            {
                isTimerOn = false;
            }
        }
    }

    public override void OnInteractBegin()
    {
        if (isInteractable)
        {
            base.OnInteractBegin();
            Debug.Log("Interacting");
            if (!isTimerOn)
            {
                currentPosition = Random.Range(0, 3);
                ChangeVFX();
            }
            isTimerOn = true;
        }
    }

    public override void OnInteractEnd()
    {
        if (isInteractable)
        {
            base.OnInteractEnd();
        }
    }

    public override void OnHoverBegin()
    {
        if (isInteractable)
        {
            base.OnHoverBegin();
        }
    }

    public override void OnHoverEnd()
    {
        if (isInteractable)
        {
            base.OnHoverEnd();
        }
    }

    public void ChangeVFX()
    {
        switch (currentPosition)
        {
            case 0:
                {
                    VFX.SetActive(false);
                    OnValveChange.Invoke();
                    break;
                }
            case 1:
                {
                    VFX.SetActive(true);
                    VFX.GetComponent<ParticleSystem>().startLifetime = 0.1f;
                    break;
                }
            case 2:
                {
                    VFX.SetActive(true);
                    VFX.GetComponent<ParticleSystem>().startLifetime = 0.2f;
                    break;
                }
            case 3:
                {
                    VFX.SetActive(true);
                    VFX.GetComponent<ParticleSystem>().startLifetime = 0.4f;
                    break;
                }
            default:
            {
                break;
            }
        }
    }
}
