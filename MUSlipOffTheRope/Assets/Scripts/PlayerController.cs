using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public GameObject prefabPlayer;
    public Material matPlayer;
    public Animator Anim;

    [Header("Stat")] public float speed = 0;
    [Header("Stat")] public float stamina = 0;

    public float timeRemaining;
    public ParticleSystem fbxFire;
    public bool IsDead;
    Vector3 v3move;
    public GameObject buttonRespawn;    
    public int textMoney;
    public int money;
    private Tween fallTween;
    public int distance;
    bool IsSaved;
    bool canMove = true;



    void Start()
    {


        Load();
        SetOriginal();
        timeRemaining = 10 + stamina;
        StartCoroutine(FireFbx());
        IsSaved = false;
    }


    void Update()
    {
        PressNDown();
        Stamina();
        ChangingColor();
        ScoreCalculator();
        MoneyCalcultor();


    }
    void PressNDown()
    {

        v3move = new Vector3(transform.position.x, transform.position.y - 1 - speed, transform.position.z);
        if (Input.GetMouseButtonDown(0) && canMove == true)
        {
            if (fallTween != null)
            {
                fallTween.Kill(); //çalýþan ayný tween varsa durdur kasmasýný önlemek için.
            }
            fallTween = prefabPlayer.transform.DOMove(v3move, 1f);

        }
    }
    void Stamina()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 0)
        {
            Save();
            buttonRespawn.SetActive(true);            
            canMove = false;

        }

    }
    void ChangingColor()
    {

        matPlayer.DOColor(Color.red, timeRemaining).OnComplete(Fading).SetEase(Ease.InExpo);
    }

    void SetOriginal()
    {
        matPlayer.DOColor(Color.white, 0);

    }
    void Fading()
    {
        prefabPlayer.transform.GetChild(1).gameObject.SetActive(false);
        prefabPlayer.transform.GetChild(0).gameObject.SetActive(false);

    }
    IEnumerator FireFbx()
    {
        yield return new WaitForSeconds(timeRemaining - 0.8f);
        prefabPlayer.transform.GetChild(2).gameObject.SetActive(true);
    }
    void ScoreCalculator()
    {
        distance = ((int)prefabPlayer.transform.position.y * -10) + 30; // PlayerController'a aktar


    }
    void MoneyCalcultor()
    {
        textMoney = ((int)prefabPlayer.transform.position.y * -1) + 3; // PlayerController'a aktar

    }

    void Save()
    {
        //pnMoney.playerMoney = money;
        //pnMoney.playerScore = score;
        //pnMoney.playerSpeed = speed;
        //pnMoney.playerStamina = stamina;

        PlayerPrefs.SetInt("money", money);
        if (IsSaved == false)
        {
            IsSaved = true;
            money += textMoney;
        }
        PlayerPrefs.SetFloat("speed", speed);
        PlayerPrefs.SetFloat("stamina", stamina);
    }
    void Load()
    {
        
        money = PlayerPrefs.GetInt("money");
        speed = PlayerPrefs.GetFloat("speed");
        stamina= PlayerPrefs.GetFloat("stamina");

    }

}
