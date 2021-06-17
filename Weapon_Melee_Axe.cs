using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Melee_Axe : MeleeWeaponSystem
{
    public static bool isActivate = true;
    // Update is called once per frame
    void Update()
    {
        if (isActivate)
        {
            TryAttack();
        }


    }

    protected override IEnumerator HitCoroutine()
    {
        while (isswing)
        {
            if (CheckObject())
            {
                isswing = false;
                Debug.Log(hitinfo.transform.name);
            }
            yield return null;

        }

    }

    public override void MeleeChange(melee _meleeWeapon)
    {
        if (WeaponManager.currentWeapon != null)
        {
            WeaponManager.currentWeapon.gameObject.SetActive(false);

            currentmelee = _meleeWeapon;
            WeaponManager.currentWeapon = currentmelee.GetComponent<Transform>();
            WeaponManager.currentWeaponAnim = currentmelee.anim;

            currentmelee.transform.localPosition = Vector3.zero;
            currentmelee.gameObject.SetActive(true);
            isActivate = true;
        }
    }
}

