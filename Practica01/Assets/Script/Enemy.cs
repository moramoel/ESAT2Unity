using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public float distance;
    Vector3 lookvec;
    float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        lifeTime = Time.time + 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            distance = Vector3.Distance(transform.position, target.transform.position);
            lookvec = new Vector3(target.transform.position.x, 0.0f, target.transform.position.z);
            if (distance > 0.001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                transform.LookAt(lookvec);
            }

        }
        else
        {
            Destroy(gameObject);
            GameManager.Instance.enemy_count--;
        }
        //if(Time.time > lifeTime)
        //{
        //    GameManager.Instance.enemy_count--;
        //    Destroy(gameObject);
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Hero>().ModifyHealth(-2);
            GameManager.Instance.enemy_count--;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Vault")
        {
            GameManager.Instance.enemy_count--;
            Destroy(gameObject);
        }
    }
}
