using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI highscoreText;
    public Slider sliderStamina;
    public Slider sliderSpeed;
    public GameObject player;
    PlayerController pcontroler;
    void Start()
    {
        pcontroler = GameObject.FindObjectOfType<PlayerController>();

    }


    void Update()
    {
        ScoreCalculator();
        MoneyCalcultor();
        Display();


    }
    void ScoreCalculator()
    {

        scoreText.text = "Score : " + pcontroler.distance;

    }
    void MoneyCalcultor()
    {

        moneyText.text = "Money : " + pcontroler.money.ToString();
    }
    void Display()
    {
        sliderSpeed.value =  pcontroler.speed;
        sliderStamina.value = pcontroler.stamina;
    }
}
