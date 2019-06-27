using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    public Transform[] spawnPoints;
    public GameObject[] spawnPlayer;
    public GameObject[] objectPlayer;

    public GameObject Master, Client;

    public int playerHealthMaster;
    public int playerDamageMaster;
    public int playerHealthClient;
    public int playerDamageClient;

    private void OnEnable()
    {
        if (GameSetup.GS == null)
        {
            GameSetup.GS = this;
        }
    }

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            objectPlayer[0] = PhotonNetwork.Instantiate(objectPlayer[0].name, spawnPlayer[0].transform.position, Quaternion.identity, 0);
            Debug.Log("master");
        }
        else
        {
            objectPlayer[1] = PhotonNetwork.Instantiate(objectPlayer[1].name, spawnPlayer[1].transform.position, Quaternion.identity, 0);
            Debug.Log("client");
            //StartCoroutine(SingPentingIso());
        }
    }

    //IEnumerator SingPentingIso()
    //{
    //    yield return new WaitForSeconds(0.01f);
    //    Destroy(PhotonView.Find(1001).gameObject);

    //}

}
