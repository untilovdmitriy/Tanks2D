using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tank : MonoBehaviour
{
    public Transform bullet;

    //для движения
    protected float speed = 3f;
    protected Quaternion rotation; //запомним изначальное положение танка
    protected int direction;

    //для выстрела
    protected float bulletDistance = 1.0f; // Как далеко от центра танка будет появлятся пуля
    protected float timeBetweenFires = 0.5f; // Задержка между выстрелами
    protected float timeTilNextFire = 0.0f; // Счетчик задержки между выстрелами

    void Start()
    {
        rotation = transform.rotation;
    }

    void Update()
    {  
    
    }

    protected void Move(int dir)
    {
        switch (dir)
        {
            case 0:
                {
                    transform.rotation = rotation;
                    transform.Rotate(Vector3.back, 180f);
                    transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
                    break;
                }
            case 1:
                {
                    transform.rotation = rotation;
                    transform.Rotate(Vector3.back, 90f);
                    transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
                    break;
                }
            case 2:
                {
                    transform.rotation = rotation;
                    transform.Rotate(Vector3.back, 270f);
                    transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
                    break;
                }

            case 3:
                {
                    transform.rotation = rotation;
                    transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
                    break;
                }
        }
    }

    /// <summary>
    /// выстрел в направлении движения
    /// </summary>
    protected void Shoot()
    {
        // Высчитываем позицию танка
        float posX = this.transform.position.x + (Mathf.Cos((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -bulletDistance);
        float posY = this.transform.position.y + (Mathf.Sin((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * -bulletDistance);
        // Создаём пулю
        Instantiate(bullet, new Vector3(posX, posY, 0), this.transform.rotation);
    }
}