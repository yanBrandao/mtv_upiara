using UnityEngine;
using System.Collections;

public class Companion : MonoBehaviour {

	public Transform meshEnemy;
	public float distanceToWalk = 6;
	public float distanceAttack = 0;
	public float speedWalk = 1;


	private Vector3 distanceDirection;
	private Vector3 rightDirection;
	private Vector3 leftDirection;
	private Vector3 startPosition;
	private Vector3 finalPosition;
	private bool inLeftDirection = false;
	private bool isBack = true;
	private Player player;

	// Use this for initialization
	void Start () {

		leftDirection = transform.localScale;
		rightDirection = leftDirection;
		rightDirection.x *= -1;
		player = FindObjectOfType(typeof(Player))as Player;
	}
	
	// Update is called once per frame
	void Update () {
		startPosition = player.transform.localPosition;
		distanceDirection.x = player.transform.position.x+distanceToWalk;
		finalPosition = player.transform.position;
		finalPosition.x -= distanceToWalk;
						
		if(inLeftDirection && isBack){
			transform.Translate(Vector3.left * Time.deltaTime * speedWalk);
			transform.localScale = rightDirection;
		}
		else{
			transform.Translate(Vector3.right * Time.deltaTime * speedWalk);
			transform.localScale = leftDirection;
		}
		

			if(transform.position.x >= finalPosition.x){
				inLeftDirection = true;
			}
			else {
				inLeftDirection = false;
				isBack = false;
			}

		if(transform.position.x > startPosition.x){
			isBack = true;

			}

		
		float distancePlayer = Vector3.Distance(transform.position,player.transform.position);
		if(distancePlayer <= distanceAttack){
			//Attack();
		}
		
	}

}
