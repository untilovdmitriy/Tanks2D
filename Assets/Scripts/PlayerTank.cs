using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class PlayerTank : Tank
    {
        void Start()
        {
            rotation = transform.rotation;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                Move(3);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                Move(0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Move(2);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Move(1);
            }

            //выстрел
            if ((Input.GetKey(KeyCode.Space) && timeTilNextFire < 0) || (Input.GetKey(KeyCode.Mouse0) && timeTilNextFire < 0))
            {
                timeTilNextFire = timeBetweenFires;
                Shoot();
            }
            timeTilNextFire -= Time.deltaTime;
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
    }
}
