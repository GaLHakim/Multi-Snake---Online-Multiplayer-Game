using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonConnect : MonoBehaviour
{
    public string versionName = "0.1";
    public GameObject sectionConnect, sectionLostConnect;

    public void connectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);

        Debug.Log("Connecting to Photon . . .");
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("We are connected to master");
    }

    private void OnJoinedLobby()
    {
        sectionConnect.SetActive(false);
        keGame();
        Debug.Log("On Joined Lobby");
    }

    private void OnDisconnectedFromPhoton()
    {
        if (sectionConnect.active)
            sectionConnect.SetActive(false);

        sectionLostConnect.SetActive(true);
        Debug.Log("Dis From Photon Service");
    }

    public void keGame()
    {
        SceneManager.LoadScene(1);
    }
}
