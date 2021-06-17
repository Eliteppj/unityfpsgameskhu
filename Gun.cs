using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum bullettype1 { rifle, pistol };


    public string gunName; //총의 이름
    public bullettype1 bullettype; //사용하는 총알의 종류
    public float range; //사거리
    public float accuracy; //명중률
    public float fireRate; //연사력
    public float reloadTime; //재장전시간

    public int damage; // 총의 공격력
    public int reloadBulletCount; //한번에 탄창에 넣을 수 있는 탄 수
    public int currentBulletCout; //현재 총 안에 있는 탄 수

    public float retroActionForce; //반동 세기
    public Animator anim;
    public ParticleSystem Flash;
    public AudioClip fire_sound;
    


}
