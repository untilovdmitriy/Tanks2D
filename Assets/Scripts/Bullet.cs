using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    float speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
