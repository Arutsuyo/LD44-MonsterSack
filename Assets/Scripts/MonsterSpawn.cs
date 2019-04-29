using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    GameObject enemy;
    public GameObject[] enemies;
    public Transform[] spawns;

    public float spawnTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawn()
    {
        if (availibilty() == true)
        {
            int spawnIndex = Random.Range(0, spawns.Length);
            int enemyIndex = Random.Range(0, enemies.Length);
            
            Instantiate(enemy, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
    }

    bool availibilty()
    {
        for(int i = 0; i < 7; i++)
        {
            if(spawns[i] == enemy)
            {
                return false;
            }
        }
        return true;
    }
}
