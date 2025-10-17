using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSpawner : MonoBehaviour
{
    public GameObject speedGood;
    public GameObject speedBad;
    public GameObject coin;

    private int bost_num;
    private Vector3 ran_pos;
    private float lastTime;
    private int waitTime;
    private int waitTimeEnemy;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = Random.Range(1, 5);
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTime + waitTime < Time.time && GameManager.Instance.bost_count < 10)
        {
            SpawnBosts();
            lastTime = Time.time;
            waitTime = Random.Range(1, 5);
            GameManager.Instance.bost_count++;
        }
    }

    public void SpawnHero(Vector3 position, GameObject hero)
    {
        Instantiate(hero,position, Quaternion.identity);
    }
    public void SpawnEnemy(GameObject enemy)
    {
        Vector3 pos = new Vector3(Random.Range(-40, 40), 0, Random.Range(-40, 40));
        Instantiate(enemy, pos, Quaternion.identity);
        GameManager.Instance.enemy_count++;
    }

    public void SpawnBosts()
    {
        bost_num = Random.Range(1,5);
        ran_pos.x = Random.Range(-40, 40);
        ran_pos.y = 1;
        ran_pos.z = Random.Range(-40, 40);
        if (bost_num == 1)
        {
            Instantiate(coin, ran_pos, Quaternion.identity);
        }
        else if(bost_num < 3)
        {
            Instantiate(speedGood, ran_pos, Quaternion.identity);
        }
        else
        {
            Instantiate(speedBad, ran_pos, Quaternion.identity);
        }
    }
}
