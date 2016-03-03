using UnityEngine;
using System.Collections;
using System.Linq;

public class EnemyTank : Tank 
{
  //Transform player;
    float timer = -1.0f;
    int[] directions = { 0, 1, 2, 3 };

    void Start()
    {
        rotation = transform.rotation;
        //player = GameObject.Find("PlayerTank").transform;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Move(direction);
        }
        else
        {
            direction = Random.Range(0, 3);
            timer = (float)Random.Range(1, 3);
        }     

        if (timeTilNextFire < 0)
        {
            timeTilNextFire = timeBetweenFires;
            Shoot();
        }
        timeTilNextFire -= Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            var tmp = from dir in directions where direction != dir select dir;

            Move(tmp.ElementAt(Random.Range(0, 2)));
        }
    }
}
