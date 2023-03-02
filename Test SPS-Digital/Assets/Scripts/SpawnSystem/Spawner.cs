using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    [SerializeField] private Transform[] spawnPos;

    [SerializeField] private GameObject enemy;

    private void Start()
    {
        instance = this;
        Spawn();
    }
    public void Spawn()
    {
        var rand = Random.Range(1, 3);
        if (rand == 1)
        {
            Instantiate(enemy, spawnPos[0]);
        }
        else
        {
            Instantiate(enemy, spawnPos[0]);
            Instantiate(enemy, spawnPos[1]);
        }
        GameController.instance.countEnemy = rand;
    }
}
