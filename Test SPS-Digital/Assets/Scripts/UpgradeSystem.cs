using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem instance;

    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Prices")]
    [SerializeField] private TextMeshProUGUI hpPriceText;
    [SerializeField] private TextMeshProUGUI damagePriceText;
    [SerializeField] private TextMeshProUGUI reloadTimePriceText;

    [Header("Lvls")]
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI reloadTimeText;

    [Space]
    [SerializeField] private Slider playerHealthBar;

    private int hp;
    private int damage;
    private float reloadTime;
    private float money;

    #region MonoBehaviour
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        print(PlayerPrefs.GetFloat("Money"));
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetFloat("Money", 0);
        }
        else
        {
            money = PlayerPrefs.GetFloat("Money");
        }
        if (!PlayerPrefs.HasKey("Hp"))
        {
            PlayerPrefs.SetInt("Hp", 1);
            hp = 1;
        }
        else
        {
            hp = PlayerPrefs.GetInt("Hp");
        }
        if (!PlayerPrefs.HasKey("Damage"))
        {
            PlayerPrefs.SetInt("Damage", 1);
            damage = 1;
        }
        else
        {
            damage = PlayerPrefs.GetInt("Damage");
        }
        if (!PlayerPrefs.HasKey("ReloadTime"))
        {
            PlayerPrefs.SetFloat("ReloadTime", 1);
            reloadTime = 1;
        }
        else
        {
            reloadTime = PlayerPrefs.GetFloat("ReloadTime");
        }
        SetCount(false, true);
    }
    #endregion
    #region Upgrade
    public void UpgradeHp()
    {
        if (money >= hp * 20)
        {
            money -= hp * 20;
            ApplyMoney();
            hp++;
            SetCount(true, false);
            UpdateSystem();
        }
    }
    public void UpgradeDamage()
    {
        if (money >= damage * 20)
        {
            money -= damage * 20;
            damage++;
            SetCount(false, false);
            UpdateSystem();
        }
    }
    public void UpgradeSpeed()
    {
        if (money >= reloadTime * 20)
        {
            money -= reloadTime * 20;
            reloadTime++;
            SetCount(false, false);
            UpdateSystem();
        }
    }
    void UpdateSystem()
    {
        PlayerPrefs.SetInt("Hp", hp);
        PlayerPrefs.SetInt("Damage", damage);
        PlayerPrefs.SetFloat("ReloadTime", reloadTime);
    }
    #endregion
    #region Add
    void SetCount(bool isChangeHp, bool isFirstChangeHp)
    {
        var maxCountHp = 50 * hp;
        if (isChangeHp)
        {
            PlayerController.instance.hp = PlayerController.instance.hp + 50;
        }
        if (isFirstChangeHp)
        {
            PlayerController.instance.hp = maxCountHp;
        }
        PlayerController.instance.damage = 25 * damage;
        PlayerController.instance.reloadTime = 3f - reloadTime * 0.6f;
        if (PlayerController.instance.reloadTime <= 0.6f)
        {
            PlayerController.instance.reloadTime = 0.6f;
        }

        playerHealthBar.maxValue = 50 * hp;
        ApplyText();
        ApllyPrice();
        ApplyMoney();

    }
    public void AddMoney(float count)
    {
        money += count;
        ApplyMoney();
    }
    #endregion
    #region Apply
    void ApplyText()
    {
        hpText.text = "Hp - " + hp + " lvl";
        damageText.text = "Damage - " + damage + " lvl";
        reloadTimeText.text = "Speed - " + reloadTime + " lvl";
    }
    void ApllyPrice()
    {
        hpPriceText.text = "Price: " + hp * 20;
        damagePriceText.text = "Price: " + damage * 20;
        reloadTimePriceText.text = "Price: " + reloadTime * 20;
    }
    void ApplyMoney()
    {
        moneyText.text = money.ToString();
        PlayerPrefs.SetFloat("Money", money);
    }
    #endregion

}
