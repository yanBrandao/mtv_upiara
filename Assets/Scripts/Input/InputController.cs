using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	private Ray InputRay;
	private RaycastHit InputHit;
	private bool inClick = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0)){
			inClick = true;
		}

		InputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(InputRay,out InputHit,Mathf.Infinity)){
			if(InputHit.transform.tag == "Button"){
				InputHit.transform.SendMessage("OnMouseOver",SendMessageOptions.RequireReceiver);
			}
			if(InputHit.transform.tag == "Button" && inClick){
				InputHit.transform.SendMessage("OnClick",SendMessageOptions.RequireReceiver);
			}
			inClick = false;
		}

	}
}
