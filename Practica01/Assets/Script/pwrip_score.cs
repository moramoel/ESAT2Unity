using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pwrip_score : MonoBehaviour
{
    public int score;
    float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = Time.time + 12;
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
            GameManager.Instance.ModifyScore(score);
            GameManager.Instance.bost_count--;
            Destroy(gameObject);
        }
    }
}
