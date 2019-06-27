using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FoodController : MonoBehaviour
{
    public GameSetup gameSet;
    public PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        gameSet = FindObjectOfType<GameSetup>();
        PV = GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D e)
    {
        //Debug.Log("FOOD");
        //if (e.gameObject.name == "PlayerAvatar(Clone)" || e.gameObject.name == "PlayerAvatar 1(Clone)")
        //{
        //    Debug.Log("destroy FOOD");
        //    Destroy(gameObject);
        //}

        if (e.gameObject.tag == "Master")
        {
            PV.RPC("addHealthMaster",RpcTarget.All);
            Destroy(gameObject);
        }
        else if(e.gameObject.tag == "Client") {
            PV.RPC("addHealthClient", RpcTarget.All);
            Destroy(gameObject);
        }





    }

    [PunRPC]
    public void addHealthMaster()
    {
        gameSet.playerHealthMaster += 10;
    }

    [PunRPC]
    public void addHealthClient()
    {
        gameSet.playerHealthClient += 10;
    }

}
