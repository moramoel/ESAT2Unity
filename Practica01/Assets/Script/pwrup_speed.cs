using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pwrup_speed : MonoBehaviour
{
    public float speedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            other.GetComponent<Hero>().IncreaseSpeed(speedMultiplier);
            GameManager.Instance.bost_count--;
            Destroy(gameObject);
        }
    }
}
