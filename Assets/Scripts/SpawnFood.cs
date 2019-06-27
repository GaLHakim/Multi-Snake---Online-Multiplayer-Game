using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnFood : MonoBehaviour
{
    private PhotonView PV;
    public GameObject FoodPrefab;

    public Vector3 center;
    public Vector3 size;
    public Vector3 pos;

    public float spawnDelay;
    public float spawnTime;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        time = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            time -= spawnTime * Time.deltaTime;
            if (time <= 0)
            {
                GameObject temp = GameObject.Find("Food");
                PV.RPC("RPC_SpawnObjects", RpcTarget.All);
                time = spawnDelay;
                PhotonNetwork.Destroy(temp);
            }
        }
    }

    [PunRPC]
    void RPC_SpawnObjects()
    {
        pos = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
        GameObject temp = PhotonNetwork.Instantiate("Food", pos, Quaternion.identity);
        temp.name = "Food";
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
