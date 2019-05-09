using UnityEngine;
using System.Collections;

public class MovePlayers : MonoBehaviour {

    public Booster moveSpeed;
	public VJHandler jsMovement;
	
	private Vector3 direction;
	private float xMin,xMax,yMin,yMax;
	
	void Update () {
		
		direction = jsMovement.InputDirection;
		
		if(direction.magnitude != 0){
		
			transform.position += direction * moveSpeed.speed;
			transform.position = new Vector3(Mathf.Clamp(transform.position.x,xMin,xMax),Mathf.Clamp(transform.position.y,yMin,yMax),0f);
		}	
	}	
	
	void Start(){
	
		xMax = Screen.width - 50;
		xMin = 50; 
		yMax = Screen.height - 50;
		yMin = 50;
	}
}