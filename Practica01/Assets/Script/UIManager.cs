using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Hearts Image")]
    public Image[] heart;
    public Image heart2;
    public Image heart3;

    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 2;
        for(int i = 0; i <= lives; i++)
        {
            heart[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyH()
    {
        heart[lives].gameObject.SetActive(false);
        lives--;
    }

    public void EditHeartImage(float health_)
    {
        heart[lives].fillAmount = health_/10;
        Debug.Log(health_ / 10);
    }
}
