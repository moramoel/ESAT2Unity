using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    const int max_health = 100;

    private int health_;
    public float speedLimitator;
    public float rotationSpeed;
    private bool alive_;

    //Movement
    private PlayerInput playerInput;
    private float hInput, vInput;
    private float hMovement, vMovement;
    //public float hMaxSpeed, vMaxSpeed;
    private Vector2 input;
    public Vector3 movement;

    //Jump
    private bool is_grounded;
    // Start is called before the first frame update
    void Start()
    {
        health_ = max_health;
        alive_ = true;
        speedLimitator = 0.3f;
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        input = playerInput.actions["Move"].ReadValue<Vector2>();
        
    }


    public void Rotate(InputAction.CallbackContext callback)
    {
        Vector2 inputRot = callback.ReadValue<Vector2>();

        transform.Rotate(new Vector3(0, inputRot.x, 0).normalized * Time.deltaTime * rotationSpeed);
    }

    public void JumpAction(InputAction.CallbackContext callback)
    {
        if(callback.performed && is_grounded)
        {

        }
    }

    private void FixedUpdate()
    {
        movement = (transform.right * input.x + transform.forward * input.y).normalized * speedLimitator;
        gameObject.transform.position += movement;
    }

    void ModifyHealth(int health_modifier)
    {
        health_ += health_modifier;
        if(health_ < 0)
        {
            alive_ = false;
        }
    }
    int GetHealth()
    {
        return health_;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            is_grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            is_grounded = true;
        }
    }
}
