using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class pwrup_life : MonoBehaviour
{
    public int life = 2;
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
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Hero>().ModifyHealth(life);
            GameManager.Instance.bost_count--;
            Destroy(gameObject);
        }
    }
}
