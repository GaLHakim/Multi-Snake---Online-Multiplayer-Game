using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnFood : MonoBehaviour
{
    public GameObject FoodPrefab;

    public Vector3 center;
    public Vector3 size;

    public float spawnDelay;
    public float spawnTime;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
        time = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        time -= spawnTime * Time.deltaTime;
        if (time <= 0)
        {
            SpawnObjects();
            time = spawnDelay;

        }
    }

    public void SpawnObjects()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y));

        Instantiate(FoodPrefab, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
