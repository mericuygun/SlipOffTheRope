using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseStats : MonoBehaviour
{
    public Button addSpeed;
    public Button addStamina;
    PlayerController pcont;
    public int speedBuyValue = 10;
    public int staminaBuyValue = 10;
    void Start()
    {
        pcont = GameObject.FindObjectOfType<PlayerController>();
    }
    public void SpeedButton()
    {
        Debug.Log("Speed arttýyor...");
        pcont.money -= speedBuyValue;
        pcont.speed += 1;
    }
    public void StaminaButton()
    {
        Debug.Log("Stamina arttýyor...");
        pcont.money -= staminaBuyValue;
        pcont.stamina++;
    }
}
