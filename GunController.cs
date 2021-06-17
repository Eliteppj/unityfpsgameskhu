using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public GameObject gsm;
    public static bool isActivate = false;

    [SerializeField]
    private Gun currentgun;

    private float currentFireRate;
    private bool isreload =false;

    private AudioSource audioSource;


    private RaycastHit hitInfo;

    [SerializeField]
    private Camera theCam;

    [SerializeField]
    private GameObject hit_effect;

    public GameObject bulletinv;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        WeaponManager.currentWeapon = currentgun.GetComponent<Transform>();
        WeaponManager.currentWeaponAnim = currentgun.anim;
    }
    // Update is called once per frame
    void Update()
    {
        if(isActivate && gsm.GetComponent<GameStatusManager>().canmove==true && !InventoryController.InventoryActivated)
        {
            GunFireRateCalc();
            TryFire();
            TryReload();
        }
    }


    private void GunFireRateCalc()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime; 
        }

    }

    private void TryFire()
    {
        if (Input.GetButton("Fire1") && currentFireRate <= 0 && !isreload)
        {
            Fire();
        }

    }

    private void Fire()
    {
        if(!isreload)
        {
            if (currentgun.currentBulletCout > 0)
                Shoot();
        }
       
    }
    private void Shoot()
    {
        currentgun.currentBulletCout--;
        currentFireRate = currentgun.fireRate;
        currentgun.anim.SetTrigger("Fire");
        PlaySE(currentgun.fire_sound);
        currentgun.Flash.Play();
        Hit();
    }


    private void Hit()
    {
        if (Physics.Raycast(theCam.transform.position, theCam.transform.forward +
            new Vector3(Random.Range(-currentgun.accuracy,currentgun.accuracy), Random.Range(-currentgun.accuracy, currentgun.accuracy),0)
            , out hitInfo, currentgun.range))
        {
           if (hitInfo.transform.GetComponent<NPC_Melee>()!=null)
            {
                hitInfo.transform.GetComponent<NPC_Melee>().hp -= currentgun.damage;

            }
            Debug.Log(hitInfo.transform.name);
            GameObject clone = Instantiate(hit_effect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(clone, 2f);
        }
        
    }

    private void TryReload()
    {
        if(Input.GetKeyDown(KeyCode.R) && !isreload)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    public void CancelReload()
    {
        if(isreload)
        {
            StopAllCoroutines();
            isreload = false;
        }
    }




   IEnumerator ReloadCoroutine()
    {
      
        isreload = true;
        currentgun.anim.SetTrigger("Reload");

        yield return new WaitForSeconds(currentgun.reloadTime);

        if (currentgun.bullettype ==Gun.bullettype1.pistol) //현재 들고 있는 총이 9mm탄을 사용할 때
        {
            for (int i = 0; i< bulletinv.transform.childCount; i++)
            {
                string tmp1 = bulletinv.transform.GetChild(i).GetChild(0).GetComponent<Text>().text;
                if(tmp1== "9mmBullet")
                {
                   int tmp2 = int.Parse(bulletinv.transform.GetChild(i).GetChild(2).GetComponent<Text>().text); //현재 가지고 있는 9mm총알의 개수
                   int tmp3 = currentgun.currentBulletCout + tmp2; // 현재 총 안에 들어있는 총알 + 인벤토리에 가지고 있는 총알의 합

                    if(currentgun.reloadBulletCount>tmp3) //현재 보유한 총알의 수가 장전하려는 총의 전체 총알의 수보다 작을 때 있는 총알을 전부 넣기
                    {
                        currentgun.currentBulletCout = tmp3;
                        bulletinv.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = 0.ToString(); // 총알을 전부 집어넣었으므로 인벤토리에 있는 모든 총알이 소진
                    }
                    else if(currentgun.currentBulletCout < tmp3)
                    {
                        currentgun.currentBulletCout = currentgun.reloadBulletCount;
                        bulletinv.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = (tmp3 - currentgun.reloadBulletCount).ToString(); // 최대 수만큼 채워넣고 나머지는 갖고 있기
                    }
                  
                }
            }
        }



        else if (currentgun.bullettype ==Gun.bullettype1.rifle) //현재 들고 있는 총이 소총탄을 사용할 때
        {
            for (int i = 0; i < bulletinv.transform.childCount; i++)
            {
                string tmp1 = bulletinv.transform.GetChild(i).GetChild(0).GetComponent<Text>().text;
                if (tmp1 == "RifleBullet")
                {
                    int tmp2 = int.Parse(bulletinv.transform.GetChild(i).GetChild(2).GetComponent<Text>().text); //현재 가지고 있는 9mm총알의 개수
                    int tmp3 = currentgun.currentBulletCout + tmp2; // 현재 총 안에 들어있는 총알 + 인벤토리에 가지고 있는 총알의 합

                    if (currentgun.reloadBulletCount > tmp3) //현재 보유한 총알의 수가 장전하려는 총의 전체 총알의 수보다 작을 때 있는 총알을 전부 넣기
                    {
                        currentgun.currentBulletCout = tmp3;
                        bulletinv.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = 0.ToString(); // 총알을 전부 집어넣었으므로 인벤토리에 있는 모든 총알이 소진
                    }
                    else if (currentgun.currentBulletCout < tmp3)
                    {
                        currentgun.currentBulletCout = currentgun.reloadBulletCount;
                        bulletinv.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = (tmp3 - currentgun.reloadBulletCount).ToString(); // 최대 수만큼 채워넣고 나머지는 갖고 있기
                    }

                }
            }

        }


        

        isreload = false;

    }


    private void PlaySE(AudioClip _clip)
    {

        audioSource.clip = _clip;
        audioSource.Play();

    }

    public void GunChange(Gun _gun)
    {
        if(WeaponManager.currentWeapon != null)
        {
            WeaponManager.currentWeapon.gameObject.SetActive(false);

            currentgun = _gun;
            WeaponManager.currentWeapon = currentgun.GetComponent<Transform>();
            WeaponManager.currentWeaponAnim = currentgun.anim;

            currentgun.transform.localPosition = Vector3.zero;
            currentgun.gameObject.SetActive(true);
            isActivate = true;
        }
    }

}
