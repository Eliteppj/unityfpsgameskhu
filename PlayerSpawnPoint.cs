using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        randomspawn();

    }

   public void randomspawn()
    {
        int i = Random.Range(0, 3);
        player.transform.position = transform.GetChild(i).position;
    }
}
