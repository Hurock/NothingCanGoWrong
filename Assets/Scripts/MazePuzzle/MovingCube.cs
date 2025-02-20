using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public bool isActive = false;

    [SerializeField] float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (Input.GetKey(KeyCode.Escape)) isActive = false;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude > 0.1f)
            {
                Vector3 moveDirection = gameObject.transform.up * vertical + gameObject.transform.right * horizontal;
                moveDirection.Normalize();
                gameObject.transform.Translate(moveDirection * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MazeEnd")
        {
            FindObjectOfType<MazePuzzleManager>().OnInteractEnd();
        }
    }
}
