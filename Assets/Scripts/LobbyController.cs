using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    public static LobbyController Lobby;
    RoomInfo[] rooms;

    public GameObject PlayButton;

    private void Awake()
    {
        Lobby = this;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PlayButton.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player Connect . . .");
        PhotonNetwork.AutomaticallySyncScene = true;
        PlayButton.SetActive(true);
    }

    public void OnPlayButtonClicked()
    {
        Debug.Log("Click To Play");
        PhotonNetwork.JoinRandomRoom();

        //StartCoroutine(CreateRoom());
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed Join Room");
        CreateRoom();
    }

    /*IEnumerator*/ void CreateRoom()
    {
        Debug.Log("Create Room");

        //yield return new WaitForSeconds(2f);

        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Join Room");
        //PhotonNetwork.LoadLevel(1);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed Create New Room");
        CreateRoom();
    }
}
