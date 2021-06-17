using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeaponSystem : MonoBehaviour //추상 클래스, 라인 67참조
{
    public GameObject gsm;
    //현재 장착된 손 타입 무기
    [SerializeField]
    protected melee currentmelee;



    protected bool isattack = false;
    protected bool isswing = false;

    protected RaycastHit hitinfo;


    protected void TryAttack()
    {
        if (gsm.GetComponent<GameStatusManager>().canmove == true && !InventoryController.InventoryActivated)
        {
            if ((Input.GetButton("Fire1")))
            {
                if (!isattack)
                {
                    StartCoroutine(AttackCoroutine());
                }

            }

        }
    }


    protected IEnumerator AttackCoroutine()
    {
        isattack = true;
        currentmelee.anim.SetTrigger("Attack");

        yield return new WaitForSeconds(currentmelee.attackdelayA);
        isswing = true;

        StartCoroutine(HitCoroutine());
        //공격 활성화 시점

        yield return new WaitForSeconds(currentmelee.attackdelayB);
        isswing = false;

        yield return new WaitForSeconds(currentmelee.attackdelay - currentmelee.attackdelayA - currentmelee.attackdelayB);

        isattack = false;
    }

   


    //미완성 '자식에서 완성해라'
    protected abstract IEnumerator HitCoroutine();


    
    protected bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitinfo, currentmelee.range))
        {
            return true;
        }
        return false;
    }

    //완성함수지만 추가 편집이 가능한 함수
    public virtual void MeleeChange(melee _meleeWeapon)
    {
        if (WeaponManager.currentWeapon != null)
        {
            WeaponManager.currentWeapon.gameObject.SetActive(false);

            currentmelee = _meleeWeapon;
            WeaponManager.currentWeapon = currentmelee.GetComponent<Transform>();
            WeaponManager.currentWeaponAnim = currentmelee.anim;

            currentmelee.transform.localPosition = Vector3.zero;
            currentmelee.gameObject.SetActive(true);
        }
    }

}
