using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    const int max_health = 100;

    private int health_;
    private float speed_;
    private bool alive_;
    // Start is called before the first frame update
    void Start()
    {
        health_ = max_health;
        alive_ = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (alive_)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            }
        }
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
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
