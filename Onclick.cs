using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onclick : MonoBehaviour
{
    Button button;
    public GameObject spp;
    public GameObject gsm;
    public GameObject GS;
    public GameObject SCFADE;
    public GameObject backbutton;
    public GameObject WeaponC;
    public GameObject[] _loot;
    public GameObject player1;
    public GameObject npcm;
    public GameObject mss;
    
    public void OnClickButton()
    {
        mss.GetComponent<ActionC>().SS_Buttonclick();
        if (player1.GetComponent<PlayerStatus>().Player_HP <=0)
        {
            player1.GetComponent<PlayerStatus>().Player_HP = 100;
        }
        
        WeaponC.GetComponent<WeaponManager>().MasterChanger("Melee", "barehand");
        spp.GetComponent<PlayerSpawnPoint>().randomspawn();
        GS.SetActive(false);
        gsm.GetComponent<GameStatusManager>().gameplaying = true;
        gsm.GetComponent<GameStatusManager>().canmove = true;
        gsm.GetComponent<GameStatusManager>().caninventory = true;
        InventoryController.InventoryActivated = false;
        backbutton.SetActive(false);
        var tmp1 = SCFADE.transform.GetComponent<Image>();
        tmp1.color = new Color(0, 0, 0, 0);
        Debug.Log("Play BUtton");

        for(int i = 0; i<_loot.Length;i++)
        {
            _loot[i].GetComponent<Loot_Info>()._reset();
        }
        Cursor.visible = false;

        npcm.GetComponent<NPC_Manager>().Revis();
    }



}
