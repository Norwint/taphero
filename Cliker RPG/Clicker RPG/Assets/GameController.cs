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
    public Text dpcText;
    public Text dpsText;
    public Text moneyText;
    public Text buydpcText;
    public Text buydpsText;
    public Text moneybuydpcText;
    public Text moneybuydpsText;

    public Image healthbar;
    public Image enemyimage;

    public static AudioClip hitenemy, coinSound;
    static AudioSource audioSrc;

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
        hitenemy = Resources.Load<AudioClip>("hitenemy1");
        coinSound = Resources.Load<AudioClip>("coin");
        audioSrc = GetComponent<AudioSource>();
    }

    public void Update()
    {
        healthText.text = (int)health + "/" + healthCap + " HP";
        enemyText.text = enemy + "/" + "10";
        stageText.text = "Stage - " + stage;
        moneyText.text = money.ToString();
        dpcText.text = "" + dpc;
        dpsText.text = "" + dps;
        stageText.text = "Stage - " + stage;
        buydpcText.text = "+ " + buydpc + " DPC";
        buydpsText.text = "+ " + buydps + " DPS";
        moneybuydpcText.text = moneybuydpc.ToString();
        moneybuydpsText.text = moneybuydps.ToString();

        healthbar.fillAmount = (float)(health / healthCap);

        if (dps > 0)
        {
            health = health - (Time.deltaTime * 1.2);
        }

        if (health <= 0)
        {
            audioSrc.PlayOneShot(coinSound);
            enemyimage.sprite = Resources.Load<Sprite>("Sprites/" + Random.Range(1, 6));
            money += Random.Range(1, 5);

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

            if (stage == 1)
            {
                healthCap = 30;
                health = 30;
                if (enemy == 10)
                {
                    enemyimage.sprite = Resources.Load<Sprite>("Sprites/boss");
                    healthCap = 50;
                    health = 50;
                }
            }
            else if (stage == 2)
            {
                healthCap = 45;
                health = 45;
                if (enemy == 10)
                {
                    enemyimage.sprite = Resources.Load<Sprite>("Sprites/boss");
                    healthCap = 170;
                    health = 170;
                }
            }
            else if (stage == 3)
            {
                healthCap = 71;
                health = 71;
                if (enemy == 10)
                {
                    enemyimage.sprite = Resources.Load<Sprite>("Sprites/boss");
                    healthCap = 300;
                    health = 300;
                }
            }
            else if (stage == 4)
            {
                enemyimage.sprite = Resources.Load<Sprite>("Sprites/boss");
                healthCap = 125;
                health = 125;
                if (enemy == 10)
                {
                    healthCap = 500;
                    health = 500;
                }
            }
            else if (stage == 5)
            {
                enemyimage.sprite = Resources.Load<Sprite>("Sprites/boss");
                healthCap = 250;
                health = 250;
                if (enemy == 10)
                {
                    healthCap = 1000;
                    health = 1000;
                }
            }
        }
    }

    public void Hit()
    {
        health = health - dpc;
        audioSrc.PlayOneShot(hitenemy);
    }

    public void BuyDPC()
    {
        if (money >= moneybuydpc)
        {
            dpc = dpc + 1;
            money = money - moneybuydpc;
        }

        if (dpc > buydpc)
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