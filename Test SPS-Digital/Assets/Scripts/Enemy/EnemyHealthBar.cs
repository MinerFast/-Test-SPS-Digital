using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyController enemy;

    [SerializeField] private GameObject damageCanvas;

    [SerializeField] private Transform spawnPos;

    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        this.gameObject.transform.parent = GameObject.FindGameObjectWithTag("HealthBars").transform;
    }
    private void FixedUpdate()
    {
        this.transform.position = spawnPos.position;
        if (!enemy.isDie)
        {
            slider.value = enemy.hp;
        }
        else
        {
            slider.value = 0;
        }
    }
    public void SetDamageText(int count)
    {
        var canvas = Instantiate(damageCanvas, spawnPos);
        canvas.GetComponent<Canvas>().worldCamera = Camera.main;
        var text = canvas.transform.Find("Damage");
        text.GetComponent<TextMeshProUGUI>().text = "-" + count;
        text.transform.position = spawnPos.position;
    }
}
