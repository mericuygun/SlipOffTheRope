using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButton : MonoBehaviour
{
    public int speedBuyValue = 10;
    public Button addSpeedButton;
    PlayerController pcont;
    void Start()
    {
        pcont = GameObject.FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        
    }
    public void SpeedButton2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Speed arttýyor");
            pcont.money -= speedBuyValue;
            pcont.speed += 1;
        }
    }
}
