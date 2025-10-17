using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pwrip_score : MonoBehaviour
{
    public int score;
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
            GameManager.Instance.ModifyScore(score);
            GameManager.Instance.bost_count--;
            Destroy(gameObject);
        }
    }
}
