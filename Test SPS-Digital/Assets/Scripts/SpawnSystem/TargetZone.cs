using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZone : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = spawnPos.position;
        GameController.instance.ChangeIsGo(false);
        Spawner.instance.Spawn();
    }
}
