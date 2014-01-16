using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	

	public Transform meshEnemy;
	public float distanceToWalk = 6;
	public float speedWalk = 1;
	public int health = 1;
	public float distanceAttack;
	
	private Vector3 rightDirection;
	private Vector3 leftDirection;
	private Vector3 startPosition;
	private Vector3 finalPosition;
	private bool inLeftDirection = false;
	private bool isBack = true;

	public float stunTime = 2 ;
	private float currentStunTime = 0;
	private bool stun = false;
	public Fruit projetil;
	private Player player;
	private float currentAttackRate;
	public float attackRate;
	public bool canAttack;
	public Vector3 offsetAttack;

	// Use this for initialization
	void Start () {
		
		startPosition = transform.position;
		finalPosition = startPosition;
		finalPosition.x -= distanceToWalk;
		
		leftDirection = transform.localScale;
		rightDirection = leftDirection;
		rightDirection.x *= -1;

		player = FindObjectOfType(typeof(Player))as Player;
				
	}


	// Update is called once per frame
	void Update () {
		currentAttackRate += Time.deltaTime;
		   if(inLeftDirection && isBack){
			transform.Translate(Vector3.left * Time.deltaTime * speedWalk);
			transform.localScale = leftDirection;
		}
		else{
			transform.Translate(Vector3.right * Time.deltaTime * speedWalk);
			transform.localScale = rightDirection;
		}
		
		if(transform.position.x > finalPosition.x){
			inLeftDirection = true;
		}
		else {
			inLeftDirection = false;
			isBack = false;
		}
		
		if(transform.position.x > startPosition.x){
			isBack = true;
		}

		if(stun){
			currentStunTime += Time.deltaTime;
			if(currentStunTime > stunTime){
				stun = false;
				speedWalk = 1.5f;
				currentStunTime = 0;
			}
		}


		float distancePlayer = Vector3.Distance(transform.position,player.transform.position);
		if(distancePlayer <= distanceAttack && canAttack){
			Attack();
		}

	}



	void OnTriggerEnter(Collider hit){
		if(hit.transform.tag == "Attack"){
			health--;
			stun = true;
			speedWalk = 0;
			Destroy(hit.gameObject);
		}
		if(health<1){
			Destroy(gameObject);
		}

	}
	void Attack(){
	if(currentAttackRate >= attackRate){
			GameObject fruta = Instantiate(projetil.gameObject,transform.position+offsetAttack,transform.rotation)as GameObject;
			fruta.GetComponent<Fruit>().right = !isBack;
			currentAttackRate = 0;
		}
	}

	
}

