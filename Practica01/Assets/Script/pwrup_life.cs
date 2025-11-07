using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class pwrup_life : MonoBehaviour
{
    public int life = 2;
    float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = Time.time + 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lifeTime)
        {
            GameManager.Instance.bost_count--;
            Destroy(gameObject);
        }
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
