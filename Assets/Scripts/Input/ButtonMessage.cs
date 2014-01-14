using UnityEngine;
using System.Collections;

public class ButtonMessage : MonoBehaviour {

	public string nameMessageMethod;
	public GameObject target;
	// Use this for initialization
	void Start () {

	}

	void OnClick () {
		target.SendMessage(nameMessageMethod,SendMessageOptions.DontRequireReceiver);
	}

	void OnMouseOver () {

				
	}
}
