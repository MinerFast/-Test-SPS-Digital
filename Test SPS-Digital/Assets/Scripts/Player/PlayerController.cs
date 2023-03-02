using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private PlayerHealthBar healthBar;

    [Header("Options")]
    public int hp = 100;
    public int damage = 25;
    public float reloadTime = 0.4f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (hp <= 0)
        {
           GameController.instance.Lose();
        }
    }
    public void TakeDamage(int count)
    {
        healthBar.SetDamageText(count);
    }
}
