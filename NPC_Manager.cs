using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Manager : MonoBehaviour
{
    public GameObject[] list;

public void Revis()
    {
        for(int i = 0; i<list.Length; i++)
        {
            list[i].GetComponent<NPC_Melee>().hp = 100;
            list[i].GetComponent<NPC_Melee>().islive = true;


        }


    }



}
