using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float boostTime = 2.0f;
    public float currentBoostTime;
    public float boostDelayTime = 5.0f;
    public float currentBoostDelayTime;
    public bool boosting = false;
    public float time;

    public float baseSpeed = 1.0f;
    public float speedBoost = 2.0f;
    public float speed;

    // Use this for initialization
    void Start()
    {
        currentBoostTime = 0f;
        currentBoostDelayTime = 0f;
        speed = baseSpeed;
    }

    void movePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !boosting && Time.time > currentBoostDelayTime)
        {
            currentBoostTime = Time.time + boostTime;
            boosting = true;
        }

        if ((Time.time > currentBoostTime) && boosting)
        {
            boosting = false;
            currentBoostDelayTime = Time.time + boostDelayTime;
        }

        if (boosting)
        {
            speed = speedBoost;

        }

        if (!boosting)
        {
            speed = baseSpeed;

        }
    }


    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        movePlayer();
    }
}
