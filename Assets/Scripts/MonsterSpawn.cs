using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//GDOG ;)
public class MonsterSpawn : MonoBehaviour
{
    GameObject enemy;
    public GameObject[] enemies;
    public Transform[] spawns;

    public float spawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject);
        InvokeRepeating("spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawn()
    {
        availibilty();

        if (availibilty() == true)
        {
            int spawnIndex = Random.Range(0, spawns.Length);
            int enemyIndex = Random.Range(0, enemies.Length);
            enemy = enemies[enemyIndex];
            Instantiate(enemy, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
            Debug.Log("Enemy Spawned");
        }
    }

    bool availibilty()
    {
        for(int i = 0; i < 7; i++)
        {
            if(spawns[i] != enemy)
            {
                return true;
            }
        }
        return false;
    }
}
