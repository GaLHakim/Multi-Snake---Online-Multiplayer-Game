using UnityEngine;
using System.Collections;
using Photon.Pun;
using UnityEngine.UI;
using System;
//using UnityStandardAssets;

public class MovePlayers : MonoBehaviour
{
    private PhotonView PV;
    public float xScale = 6f, yScale = 6f;
    public SpawnFood spawnFood;
    Joystick joy;
    Booster boost;
    private float moveSpeed;

    string master, client;

    public GameSetup gameSet;

    void Start()
    {
  
        PV = GetComponent<PhotonView>();
        spawnFood = GetComponent<SpawnFood>();
        joy = FindObjectOfType<Joystick>();
        boost = FindObjectOfType<Booster>();
        gameSet = FindObjectOfType<GameSetup>();

        Debug.Log(gameSet.Master.tag.ToString());
        Debug.Log(PhotonNetwork.IsMasterClient.ToString());
    }

    void Update()
    {
        if (PV.IsMine)
        {
            moveSpeed = 0.02f;
            //boost.baseSpeed = 0.02f;
            transform.localScale = new Vector3(xScale, yScale, 0);
            BasicMovement();
            //BasicScale();
        }
    }

    void BasicMovement()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = joy.Horizontal;
        float moveVertical = joy.Vertical;

        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        transform.position += movement * moveSpeed/*boost.speed*/;
    }

    void OnTriggerEnter2D(Collider2D e)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (e.gameObject.tag == "Client") {
                if (gameSet.playerHealthMaster > gameSet.playerHealthClient)
                {
                    Debug.Log("Master Menang");
                    master = "Master Win";
                    PV.RPC("MasterCondition", RpcTarget.All, master);
                }
                else if (gameSet.playerHealthMaster < gameSet.playerHealthClient)
                {
                    Debug.Log("Master Kalah");
                    client = "Client Win";
                    PV.RPC("ClientCondition", RpcTarget.All, client);
                }
            }
        }
        else
        {
            if (e.gameObject.tag == "Master")
            {
                if (gameSet.playerHealthClient > gameSet.playerHealthMaster)
                {
                    Debug.Log("Client Menang");
                    client = "Client Win";
                    PV.RPC("ClientCondition", RpcTarget.All, client);
                }
                else if (gameSet.playerHealthClient < gameSet.playerHealthMaster)
                {
                    Debug.Log("Master Menang");
                    master = "Master Win";
                    PV.RPC("MasterCondition", RpcTarget.All, master);
                }
            }
        }
    }

    [PunRPC]
    public void MasterCondition(string a)
    {
        gameSet.TextMaster(a);
    }

    [PunRPC]
    public void ClientCondition(string b)
    {
        gameSet.TextClient(b);
    }



    //[PunRPC]
    //public void RPC_DestroyMaster()
    //{
    //    Debug.Log("Master Des");
    //    Destroy(gameSet.Master);
    //    Debug.Log(gameSet.Master.tag.ToString() + " Destroyed");
    //}


    //[PunRPC]
    //public void RPC_DestroyClient()
    //{
    //    Debug.Log("Client Des");
    //    Destroy(gameSet.Client);
    //    Debug.Log(gameSet.Client.tag.ToString() + "Destroyed");
    //}
    //public float speed;
    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, moveVertical);
    //    transform.position += movement * speed;
    //}
}