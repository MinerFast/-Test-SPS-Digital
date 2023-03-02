using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject damageCanvas;

    [SerializeField] private Transform spawnPos;

    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void FixedUpdate()
    {
        this.transform.position = spawnPos.position;
        slider.value =  PlayerController.instance.hp;
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
