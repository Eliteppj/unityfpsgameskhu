using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour // 게임을 시작할 때마다 플레이어의 현재 체력을 최대 체력으로 초기화하는 스크립트
{
    public GameObject gsm;
    public Image GS;
    public GameObject backbutton;
    public GameObject inventory;
    public GameObject lobbys;
    [SerializeField]
    private PlayerInfo playerInfo;

    public double Player_HP;
    public double Player_Energy;
    public double Player_Water;
    public double Player_Weight;
    public GameObject npcm;

    private void Start()
    {
        Player_HP = playerInfo.Player_Max_HP;
        Player_Energy = playerInfo.Player_Max_Energy;
        Player_Water = playerInfo.Player_Max_Water;
        Player_Weight = 0;
    }


    private void Update()
    {
        
        if (gsm.GetComponent<GameStatusManager>().gameplaying)
        {
            RealTimeHP();
            RealTimeEnergy();
            RealTimeWater();
            CheckPlayerHP();
        }
        else if(gsm.GetComponent<GameStatusManager>().gameplaying == false)
            Restore();

    }

    private void Restore()
    {
        if (Player_HP< playerInfo.Player_Max_Energy)
            Player_HP += 1 * Time.deltaTime;
    }

    private void CheckPlayerHP()
    {
       if(Player_HP <=0)
        {
            GameSet();
            Cursor.visible = true;
        }
    }

    public void GameSet()
    {
        inventory.SetActive(false);
        gsm.GetComponent<GameStatusManager>().canmove = false;
        gsm.GetComponent<GameStatusManager>().caninventory = false;
        gsm.GetComponent<GameStatusManager>().cansetting = false;
        gsm.GetComponent<GameStatusManager>().canshop = false;
        var tmp1 = GS.transform.GetComponent<Image>();
        tmp1.color = new Color(0, 0, 0, 1);
        lobbys.SetActive(true);
        gsm.GetComponent<GameStatusManager>().gameplaying = false;
        backbutton.SetActive(true);
        Cursor.visible = true;
        npcm.GetComponent<NPC_Manager>().Revis();
}

    private void RealTimeHP()
    {
        if (Player_Energy <= 0 || Player_Water <= 0)
            Player_HP -= 1 * Time.deltaTime;
    }

    private void RealTimeEnergy()
    {
        if (Player_Energy > 0)
        {
            Player_Energy -= 1 * Time.deltaTime;
        }
        else if (Player_Energy < 0)
        {
            Player_Energy = 0;
        }
           
    }

    private void RealTimeWater()
    {
        if (Player_Water > 0)
        {
            Player_Water -= 1 * Time.deltaTime;
        }
        else if(Player_Water <0)
        {
            Player_Water = 0;
        }
    }





    public void add_hp(double number, int count = 1)
    {
        for(int i = 0; i < count; i++)
        {
            Player_HP += number;
        }
    }

    public void add_engery(double number, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            Player_Energy += number;
        }
    }

    public void add_water(double number, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            Player_Water += number;
        }
    }

    public void add_weight(double number, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            Player_Weight += number;
        }
    }

    public void sub_weight(double number, int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            Player_Weight -= number;
        }
    }

}
