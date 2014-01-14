using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Vector2 position;
	public Vector2 size;
	//public Texture btnTexture;
	void OnGUI() {
		//if (!btnTexture) {
		//	Debug.LogError("Please assign a texture on the inspector");
		//	return;
		//}
		//if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
		//	Debug.Log("Clicked the button with an image");
		
		if (GUI.Button(new Rect(position.x, position.y, size.x, size.y), "Reiniciar")){
			Application.LoadLevel("GamePlay");
			//Debug.Log("Clicked the button with text");
		}
		if (GUI.Button(new Rect(position.x, position.y+40, size.x, size.y), "Sair")){
			//Debug.Log("Clicked the button with text");
		}
	}
}
