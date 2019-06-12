using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;

public class RoomController : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //Room Info
    public static RoomController Room;
    private PhotonView PV;

    public int currentScene;
    public int multiplayerScene;

    private void Awake()
    {
        if(RoomController.Room == null)
        {
            RoomController.Room = this;
        }
        else
        {
            if(RoomController.Room != this)
            {
                Destroy(RoomController.Room.gameObject);
                RoomController.Room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
        PV = GetComponent<PhotonView>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("In Room");
        if (!PhotonNetwork.IsMasterClient)
            return;

        StartGame();
    }

    private void StartGame()
    {
        Debug.Log("Loading Level");
        PhotonNetwork.LoadLevel(multiplayerScene);
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode arg1)
    {
        currentScene = scene.buildIndex;
        if(currentScene == multiplayerScene)
        {
            //CreatePlayer();
        }
    }

    /*private void CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("PrefabController", "Player"),
            transform.position, Quaternion.identity, 0);
    }*/
}
