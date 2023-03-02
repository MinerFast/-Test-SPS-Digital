using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;

    [SerializeField] private GameObject bullet;
    private void Awake()
    {
        StartCoroutine(SpawnTimer());
    }
    IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(PlayerController.instance.reloadTime);
            if (!GameController.instance.isGo)
            {
                Instantiate(bullet, spawnPos);
            }

        }
    }
}
