using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{

    //근접무기의 종류
    public bool justhand;
    public bool isAxe;
    public bool bayonet;
    public bool bat;
    public bool cutter;
    public bool knife;



    public string meleename;
    public float range; //공격범위
    public int damage; //공격력
    public float attackdelay; // 공격 딜레이
    public float attackdelayA; //공격 활성화 시점
    public float attackdelayB; //공격 비활성화 시점

    public Animator anim;

 
}
