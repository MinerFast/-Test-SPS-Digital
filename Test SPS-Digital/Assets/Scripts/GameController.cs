using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private GameObject lose;

    [Header("Options")]
    public float speed = 0.5f;
    public int countEnemy;

    [Header("States")]
    public bool isGo = false;

    private void Awake()
    {
        Time.timeScale = 1f;
        instance = this;
    }
    public void ChangeIsGo(bool count)
    {
        isGo = count;
    }
    public void Lose()
    {
        lose.SetActive(true);
        Time.timeScale = 0f;
    }
}
