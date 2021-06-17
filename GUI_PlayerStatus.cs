using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_PlayerStatus : MonoBehaviour //플레이어의 최대 체력 과 체력을 GUI에 표시하는 스크립트
{
    private GameObject Inventory;
    private Text text_hp;
    private Text text_maxhp;

    private Text text_energy;
    private Text text_maxenergy;

    private Text text_water;
    private Text text_maxwater;

    private Text text_weight;
    private Text text_maxweight;

    private PlayerStatus c1;
    private PlayerInfo c2;

    void Start()
    {
        Inventory = GameObject.Find("LeftSide");
        c1 = GameObject.Find("Player").GetComponent<PlayerStatus>();
        c2 = GameObject.Find("Player").GetComponent<PlayerInfo>();

        text_hp = GameObject.Find("Value_HP").GetComponent<Text>();
        text_maxhp = GameObject.Find("Text_MaxHP").GetComponent<Text>();

        text_energy = GameObject.Find("Value_Energy").GetComponent<Text>();
        text_maxenergy = GameObject.Find("Text_MaxEnergy").GetComponent<Text>();

        text_water = GameObject.Find("Value_Water").GetComponent<Text>();
        text_maxwater = GameObject.Find("Text_MaxWater").GetComponent<Text>();

        text_weight = GameObject.Find("Value_Weight").GetComponent<Text>();
        text_maxweight = GameObject.Find("Text_MaxWeight").GetComponent<Text>();
        Inventory.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        text_hp.text = c1.Player_HP.ToString();
        text_maxhp.text = "/" + c2.Player_Max_HP.ToString();

        text_energy.text = c1.Player_Energy.ToString();
        text_maxenergy.text = "/" + c2.Player_Max_Energy.ToString();

        text_water.text = c1.Player_Water.ToString();
        text_maxwater.text = "/" + c2.Player_Max_Water.ToString();

        text_weight.text = c1.Player_Weight.ToString();
        text_maxweight.text = "/" + c2.Player_Max_Weight.ToString();
    }
}
