using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;

    EasyFileSave myFile;

    // Start is called before the first frame update
    void Awake()
    {

        if(Instance==null)
        {
            Instance = this;
            StartProses();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("shotBulletText").GetComponent<Text>().text = "Shot Bullet : " + ShotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("enemyKilledText").GetComponent<Text>().text = "Enemy Killed : " + enemyKilled.ToString();
            WinProces();
        }
    }


    void StartProses()
    {
        myFile = new EasyFileSave();
        LoadData();
    }


    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();
    }


    public void LoadData()
    {
        if(myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }


    public void WinProces()
    {
        if(enemyKilled>=5)
        {
            print("....KAZANDINIZ....");
        }
    }

    public void LosePorces()
    {
        print("...Kaybettiniz...");
    }
}
