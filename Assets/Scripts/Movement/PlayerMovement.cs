using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f;
    public float mouseSensitivity = 100f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Transform cameraTransform;
    private Animator animator;
    private Vector3 velocity; // Stores gravity effect
    private bool isGrounded;

    AudioManager audioManager;

    private void Awake()
        {
           audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep grounded
        }

        // Player Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;


        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("IsWalking", true);
            Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
            moveDirection.y = 0f;
            moveDirection.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
