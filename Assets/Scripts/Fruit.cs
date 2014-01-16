using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {

	public bool right = true;
	public float fruitSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(right){
		transform.Translate(Vector3.right*fruitSpeed);
		}else{
			transform.Translate(Vector3.left*fruitSpeed);
		}
	}

	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}