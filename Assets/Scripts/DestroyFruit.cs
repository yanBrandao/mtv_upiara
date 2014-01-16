using UnityEngine;
using System.Collections;

public class DestroyFruit : MonoBehaviour {

	public float destroyTime = 2;
	private float currentTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		currentTime += Time.deltaTime;

		if(currentTime >= destroyTime){
			Destroy(gameObject);
		}
	}
}