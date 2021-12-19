using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemManager : MonoBehaviour
{
    public float health;
    public float damage;

    bool dead = false;

    bool colliderBusy = false;

    public Slider slider;


    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PLayerManager>().GetDamage(damage);

        }else if(other.tag=="bullet")
        {
            GetDamage(other.GetComponent<bulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")

        {
            colliderBusy = false;
        }
    }


    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;

        AmIDead();
    }

    public void AmIDead()
    {
        if (health <= 0)
        {
            DataManager.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }



}
