using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private int health_;
    private float speed_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealth(int new_health)
    {
        health_ = new_health;
    }

    int GetHealth()
    {
        return health_; 
    }

}
