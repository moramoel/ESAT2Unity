using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject spawnPoint;

    private float timer_;

    public GameObject hero;
    public GameObject SpawnerObject;

    private GameSpawner spawner;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void StartGame()
    {
        spawner = GetComponent<GameSpawner>();
        //Init timer
        timer_ = Time.time;
        //Spawnear Heroe
        spawner.SpawnHero(spawnPoint.transform.position);
        //Spawnear enemigos
    }

    // Update is called once per frame
    void Update()
    {
        //if (...){
        //    spawner.SpawnEnemy(Vector3, );
        //}
    }

    public void EndGame()
    {

    }
}
