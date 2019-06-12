using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetup : MonoBehaviourPun
{
    //public GameSetup GS;
    //public PhotonView PV;

    //public Transform[] spawnPoints;
    public GameObject[] spawnPlayer;
    public GameObject[] objectPlayer;

    /*private void OnEnable()
    {
        if(GameSetup.GS == null)
        {
            GameSetup.GS = this;
        }
    }*/

    void Start()
    {
        // PV = GetComponent<PhotonView>();
        //int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);

        if (PhotonNetwork.IsMasterClient) {
            objectPlayer[0] = PhotonNetwork.Instantiate(objectPlayer[0].name, spawnPlayer[0].transform.position, Quaternion.identity, 0);
            Debug.Log("master");
        } else {
            objectPlayer[1] = PhotonNetwork.Instantiate(objectPlayer[1].name, spawnPlayer[1].transform.position, Quaternion.identity, 0);
            Debug.Log("client");
            //StartCoroutine(SingPentingIso());
        }
    }

    IEnumerator SingPentingIso()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(PhotonView.Find(1001).gameObject);

    }

}
