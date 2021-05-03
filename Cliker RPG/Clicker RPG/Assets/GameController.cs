using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public double health;
    public double healthCap;
    public double dpc;
    public double dps;
    public double enemy;
    public double stage;
    public double stageMax;
    public double money;
    public double buydpc;
    public double buydps;
    public double moneybuydpc;
    public double moneybuydps;

    public Text healthText;
    public Text enemyText;
    public Text stageText;
    public Text dpsText;
    public Text moneyText;
    public Text buydpcText;
    public Text moneybuydpcText;


    public Image healthbar;

    public void Start()
    {
        healthCap = 30;
        health = healthCap;
        dpc = 1;
        dps = 0;
        enemy = 0;
        stage = 1;
        stageMax = 1;
        money = 0;
        buydpc = 1;
        buydps = 1;
        moneybuydpc = 5;
        moneybuydps = 5;
    }

    public void Update()
    {
        healthText.text = health + "/" + healthCap + " HP";
        enemyText.text = enemy + "/" + "10";
        stageText.text = "Stage - " + stage;
        moneyText.text = money.ToString();
        dpsText.text = "" + dpc;
        stageText.text = "Stage - " + stage;
        buydpcText.text = "+ " + buydpc + " DPC";
        buydpcText.text = "+ " + buydps + " DPS";
        moneybuydpcText.text = moneybuydpc.ToString();

        healthbar.fillAmount = (float)(health / healthCap);
    }

    public void Hit()
    {
        health = health - dpc;
        if (stage == 2)
        {
            healthCap = 45;
        } else if (stage == 3)
        {
            healthCap = 71;
        }

        if (health <= 0)
        {

            money += Random.Range(1, 5);
            health = healthCap;

            if (stage == stageMax)
            {
                enemy += 1;
                if (enemy > 10)
                {
                    enemy = 0;
                    stage += 1;
                    stageMax += 1;
                }

            }
        }
    }

    public void BuyDPC()
    {
        if (money >= moneybuydpc)
        {
            dpc += 1;
            money = money - moneybuydpc;
        }

        if(dpc > buydpc)
        {
            buydpc = buydpc + 1;
            moneybuydpc = moneybuydpc + 2;
        }
    }

    public void BuyDPS()
    {
        if (money >= moneybuydps)
        {
            dps += 1;
            money = money - moneybuydps;
        }

        if (dps > buydps)
        {
            buydps = buydps + 1;
            moneybuydps = moneybuydps + 2;
        }
    }
}
