using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health = 3;
	public int fruit = 3; 
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float pdead = -10.0F;
	private Vector2 moveDirection = Vector2.zero;

	public AnimationClip idle;
	public AnimationClip walk;
	public AnimationClip run;
	public AnimationClip jump;
	public AnimationClip down;
	public AnimationClip attack;
	public AnimationClip die;

	public Transform Afruit;
	public float fruitRate = 0.5F;
	private float currentFruitRate = 0;
	private bool playerRight = true;

	public float noHitTime = 2 ;
	private float currentHitTime = 0;
	public float blinkTime = 0.05f;
	private float currentBlinkTime = 0;
	private bool invencivel = false;
	public Renderer playerRender;
	void Start(){

	}

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector2(CFInput.GetAxis("Horizontal"),0);
			//moveDirection = new Vector2(Input.GetAxis("Horizontal"),0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//if (Input.GetButton("Jump")){
				if (CFInput.GetButton("Tjump")){
				moveDirection.y = jumpSpeed;
				}

		}	//FINAL ISGROUNDED	

		if(moveDirection.x > 0){
			playerRight = true;
		}else if(moveDirection.x < 0){
			playerRight = false;
		}


		currentFruitRate += Time.deltaTime;
		if(CFInput.GetButton("Attack")){	
		//if (Input.GetButton("Fire3")){	
		if(currentFruitRate >= fruitRate){
				if(fruit>0){
					GameObject fruta = Instantiate(Afruit.gameObject,transform.position,transform.rotation)as GameObject;
					fruta.GetComponent<Fruit>().right = playerRight;
					currentFruitRate = 0;
					fruit--;
				}
			}
		}
			
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);


		if(transform.position.y <= pdead){
			CallGameOver();
		}

		if(invencivel){
			currentBlinkTime += Time.deltaTime;

			if(currentBlinkTime > blinkTime){
				currentBlinkTime = 0;
				playerRender.enabled = !playerRender.enabled;
			}

			currentHitTime += Time.deltaTime;
			if(currentHitTime > noHitTime){
				invencivel = false;
				playerRender.enabled = true;
				currentHitTime = 0;
			}
		}


	
	}

	void OnTriggerEnter(Collider hit){
		if((hit.transform.tag == "Fruit")&&(fruit <10)){
			fruit ++;
			Destroy(hit.gameObject);
		}else if((hit.transform.tag == "Fruit")&&(fruit>=10)){
			Destroy(hit.gameObject);
		}

		if((hit.transform.tag == "Health")&&(health <3)){
			health ++;
			Destroy(hit.gameObject);
		}else if((hit.transform.tag == "Health")&&(health>=3)){
			Destroy(hit.gameObject);
		}

		if(hit.transform.tag == "Enemy"){
			ApplyDamage();
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.transform.tag == "Enemy" && !invencivel){
			ApplyDamage();
		}	
	}

	void ApplyDamage(){
		if(!invencivel){
			health--;
			invencivel = true;
			if(health<1){
				CallGameOver();
			}
		}
	}

	void CallGameOver(){
		Application.LoadLevel("GameOver");
	}


	void Attack(){
			if(currentFruitRate >= fruitRate){
				if(fruit>0){
					GameObject fruta = Instantiate(Afruit.gameObject,transform.position,transform.rotation)as GameObject;
					fruta.GetComponent<Fruit>().right = playerRight;
					currentFruitRate = 0;
					fruit--;
				}
			}

	}//FIM ATTACK









}