using UnityEngine;
using System.Collections;
using Photon.Pun;
//using UnityStandardAssets;

public class MovePlayers : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController myCC;
    //private float speed;
    public float moveSpeed;
   

    void Start()
    {
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();

        //Booster b = FindObjectOfType<Booster>();
        //speed = b.speed;
    }
    //public VJHandler jsMovement;

    //private Vector3 direction;
    //private float xMin, xMax, yMin, yMax;

    void Update()
    {
        if (PV.IsMine)
        {
            BasicMovement();
        }
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        //transform.position += movement * moveSpeed;
        //direction = jsMovement.InputDirection;

        //if (direction.magnitude != 0)
        //{
        //    transform.position += direction* moveSpeed.speed;
        //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax),0f);
        //}
    }

    void BasicMovement()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        //transform.position += movement * moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            myCC.Move(transform.up * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.up * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * moveSpeed);
        }
    }

    //void Start(){

    //	xMax = 16.86f;
    //	xMin = -16.86f; 
    //	yMax = 16.86f;
    //	yMin = -16.86f;
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