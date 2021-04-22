using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public double health;
    public double healthCap;
    public double dpc;

    public Text healthText;

    public Image healthbar;

    public void Start()
    {
        healthCap = 20;
        health = healthCap;
        dpc = 1;
    }

    public void Update()
    {
        healthText.text = health + "/" + healthCap + " HP";
        healthbar.fillAmount = (float)(health / healthCap);
    }

    public void Hit()
    {
        Debug.Log("HE ENTRADO");
        health = health - dpc;

        if (health <= 0)
        {
            health = healthCap;

        }
    }
}
