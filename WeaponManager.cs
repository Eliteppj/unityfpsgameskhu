using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public static bool ischangeweapon = false; //무기 중복 교체 실행 방지 값
    [SerializeField]
    public static Transform currentWeapon; //현재 무기
    public static Animator currentWeaponAnim; //현재 무기 애니메이션


    // 현재무기의 타입
    [SerializeField]
    private string currentweapontype;


    [SerializeField]
    private float changeweapondelaytime; //각각 무기 교체,  교체가 완전히 끝난 시점.

    [SerializeField]
    private float changeweaponenddelaytime;



    //무기 종류들 관리
    [SerializeField]
    private Gun[] guns;
    [SerializeField]
    private melee[] melees;




    private Dictionary<string, Gun> gundictionary = new Dictionary<string, Gun>();
    private Dictionary<string, melee> handdictionary = new Dictionary<string, melee>();

    [SerializeField]
    private GunController theGunController;
    [SerializeField]
    private MeleeWeaponSystem MeleeWeaponSystem;




    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            gundictionary.Add(guns[i].gunName, guns[i]);
        }
        for (int i = 0; i < melees.Length; i++)
        { 
            handdictionary.Add(melees[i].meleename, melees[i]);
        }

    }

    // Update is called once per frame
  

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        ischangeweapon = true;
        currentWeaponAnim.SetTrigger("Draw");
        yield return new WaitForSeconds(changeweapondelaytime);

        CancelPreWeaponAction();
        WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeweaponenddelaytime);
        currentweapontype = _type;
        ischangeweapon = false;

    }

    private void CancelPreWeaponAction()
    {
        switch(currentWeapon.name)
        {
            case "M16":
                theGunController.CancelReload();
                GunController.isActivate = false;
                break;
            case "manson":
                Weapon_Melee_Hand.isActivate = false;
                break;
            case "Axe":
                Weapon_Melee_Axe.isActivate = false;
                break;
            case "HowaM300":
                Weapon_Melee_Axe.isActivate = false;
                break;
            case "MP5":
                Weapon_Melee_Axe.isActivate = false;
                break;
            case "Pistol":
                Weapon_Melee_Axe.isActivate = false;
                break;

        }
    }

    private void WeaponChange(string _type, string _name)
    {
        GunController.isActivate = false;
        if(_type =="GUN")
            theGunController.GunChange(gundictionary[_name]);
        else if(_type == "Melee")
            MeleeWeaponSystem.MeleeChange(handdictionary[_name]);
        
    }


    public void MasterChanger(string _type, string _itemname)
    {
        StartCoroutine(ChangeWeaponCoroutine(_type, _itemname));

    }
}

