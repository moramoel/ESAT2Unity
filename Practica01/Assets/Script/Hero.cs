using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    const int max_health = 10;

    public int health_;
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
    public float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        is_grounded = false;
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
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        movement = (transform.right * input.x + transform.forward * input.y).normalized * speedLimitator;
        gameObject.transform.position += movement;
    }

    public void ModifyHealth(int health_modifier)
    {
        if(health_+health_modifier <= max_health)
        {
            health_ += health_modifier;
        }
        else
        {
            health_ = max_health;
        }
        if(health_ <= 0)
        {
            GameManager.Instance.ResetPlayer();
        }
        else
        {
            GameManager.Instance.EditHeart(health_);
        }
    }
    int GetHealth()
    {
        return health_;
    }

    public void IncreaseSpeed(float speedMultiplier)
    {
        speedLimitator *= speedMultiplier;
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
            is_grounded = false;
        }
    }
}
