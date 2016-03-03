using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    //level
    public Transform groundPrefab;
    public Transform wallPrefab;
    float x, y, w, h, thick = 25;

    //for spawning players
    public int enemyCount = 2;
    public Transform enemy;
    public Transform player;

    float respawnTimer = 2.0f;

	// Use this for initialization
	void Start () {
        x = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x;
        y = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y;
        w = Screen.width / Screen.height < 1.4f ? Screen.width * 2.5f : Screen.width * (Screen.width / Screen.height);
        h = Screen.width / Screen.height < 1.4f ? Screen.height * 2.5f : Screen.height * (Screen.width / Screen.height);
        //расположение объектов уровня (стен, фона)       

        Transform ground = (Transform)Instantiate(groundPrefab, new Vector3(0, 0, 1), transform.rotation);
        ground.localScale = new Vector2(w, h);

        Transform[] walls = new Transform[4];
        walls[0] = (Transform)Instantiate(wallPrefab, new Vector3(-x, 0, 0), transform.rotation); //left
        walls[0].localScale = new Vector2(thick, h);

        walls[1] = (Transform)Instantiate(wallPrefab, new Vector3(x, 0, 0), transform.rotation); //right
        walls[1].localScale = new Vector2(thick, h);

        walls[2] = (Transform)Instantiate(wallPrefab, new Vector3(0, y, 0), transform.rotation);//top
        walls[2].localScale = new Vector2(w, thick);

        walls[3] = (Transform)Instantiate(wallPrefab, new Vector3(0, -y, 0), transform.rotation); //bottom
        walls[3].localScale = new Vector2(w, thick);
        
        //spawn
        SpawnEnemies();
        SpawnPlayer();
	}

    void SpawnPlayer()
    {
        Instantiate(player, Camera.main.transform.position + new Vector3(x - 2, y - 2, -Camera.main.transform.position.z), transform.rotation);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, Camera.main.transform.position + new Vector3(-x + 2, -y + 2, -Camera.main.transform.position.z), transform.rotation);
        }
    }

    void Update()
    {
        if (respawnTimer > 0)
        {
            respawnTimer -= Time.deltaTime;
        }
        else
        {
            respawnTimer = 2.0f;
            if (GameObject.FindGameObjectWithTag("Player") == null) SpawnPlayer();
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) SpawnEnemies();
        }
    }
}
