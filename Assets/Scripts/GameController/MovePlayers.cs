using UnityEngine;
using System.Collections;
using Photon.Pun;
//using UnityStandardAssets;

public class MovePlayers : MonoBehaviour
{
    private PhotonView PV;
    private float xScale = 6f, yScale = 6f;
    public SpawnFood spawnFood;
    Joystick joy;
    Booster boost;
    private float moveSpeed;

    WinPlayer1 win1;
    WinPlayer2 win2;

    public GameSetup gameSet;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        spawnFood = GetComponent<SpawnFood>();
        joy = FindObjectOfType<Joystick>();
        boost = FindObjectOfType<Booster>();
        gameSet = FindObjectOfType<GameSetup>();
        win1 = FindObjectOfType<WinPlayer1>();
        win2 = FindObjectOfType<WinPlayer2>();

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
                    win1.panel1.SetActive(true);
                }
                else if (gameSet.playerHealthMaster < gameSet.playerHealthClient)
                {
                    Debug.Log("Client Menang");
                    win2.panel2.SetActive(true);
                }
            }

           
        }
        else {

            if (e.gameObject.tag == "Master") {

                if (gameSet.playerHealthClient > gameSet.playerHealthMaster)
                {
                    Debug.Log("Client Menang");
                    win2.panel2.SetActive(true);
                }
                else if (gameSet.playerHealthClient < gameSet.playerHealthMaster)
                {
                    Debug.Log("Master Menang");
                    win1.panel1.SetActive(true);
                }
            }
        }
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