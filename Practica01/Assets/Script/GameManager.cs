using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject spawnPoint;
    public GameObject hero;
    public GameObject heroGM_;
    public GameObject enemyPF;
    public GameObject UI;
    public int enemy_count;

    public int score = 0;
    public int bost_count;

    private float timer_;

    public int playerLives;


    //public GameObject SpawnerObject;

    public GameObject spawner;



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
    void Start()
    {
        bost_count = 0;
        enemy_count = 0;
        playerLives = 3;
        //Init timer
        timer_ = Time.time;
        //Spawnear Heroe
        if(spawner != null)
        {

            spawner.GetComponent<GameSpawner>().SpawnHero(spawnPoint.transform.position, hero);
            spawner.GetComponent<GameSpawner>().SpawnEnemy(enemyPF);
        }
        //Spawnear enemigos
    }
    public void InitGame()
    {
        bost_count = 0;
        enemy_count = 0;
        playerLives = 3;
        //Init timer
        timer_ = Time.time;
        //Spawnear Heroe
        if (spawner != null)
        {

            spawner.GetComponent<GameSpawner>().SpawnHero(spawnPoint.transform.position, hero);
            spawner.GetComponent<GameSpawner>().SpawnEnemy(enemyPF);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (...){
        //    spawner.SpawnEnemy(Vector3, );
        //}
        if(enemy_count < 3 && spawner != null)
        {
            spawner.GetComponent<GameSpawner>().SpawnEnemy(enemyPF);
        }
        if(UI == null)
        {
            UI = GameObject.FindGameObjectWithTag("UIManager");
        }
        if (spawner == null)
        {
            spawner = GameObject.FindGameObjectWithTag("GameSpawner");
            if(spawner != null)
            {
                spawner.GetComponent<GameSpawner>().SpawnHero(spawnPoint.transform.position, hero);
                spawner.GetComponent<GameSpawner>().SpawnEnemy(enemyPF);
            }
        }
    }

    public void EndGame()
    {

    }

    public void ModifyScore(int score_mod)
    {
        score += score_mod;
    }

    public void ResetPlayer()
    {
        heroGM_ = GameObject.FindGameObjectWithTag("Player");
        Destroy(heroGM_);
        spawner.GetComponent<GameSpawner>().SpawnHero(spawnPoint.transform.position, hero);
        playerLives--;
        UI.GetComponent<UIManager>().ModifyH();
    }

    public void EditHeart(int health_)
    {
        UI.GetComponent<UIManager>().EditHeartImage(health_);
    }
}
