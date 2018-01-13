using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {
	Renderer renderer;

	Texture standRight;
	Texture standLeft;
	Texture jumpRight;
	Texture jumpLeft;

	string pos;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		renderer.material.shader = Shader.Find ("Transparent/VertexLit");
		renderer.material.SetColor("_Emission",Color.white);

		//standRight = Resources.Load("Stand_right_small") as Texture;
		standRight = Resources.Load("Stand_right_small_t") as Texture;
		standLeft = Resources.Load("Stand_left_small_t") as Texture;
		jumpRight = Resources.Load("jump_t") as Texture;
		jumpLeft = Resources.Load("jump_left_t") as Texture;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Y)) {
			print("Funktioniert das?");
			StandRight();
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			print("Funktioniert das?");
			StandLeft();
		}

	}

	public void StandRight () {
		if (pos != "SR") {
			renderer.material.mainTexture = standRight;
			pos = "SR";
		}
	}

	public void StandLeft () {
		if (pos != "SL") {
			renderer.material.mainTexture = standLeft;
			pos = "SL";
		}
	}

	public void JumpRight () {
		if (pos != "JR") {
			renderer.material.mainTexture = jumpRight;
			pos = "JR";
		}
	}

	public void JumpLeft () {
		if (pos != "JL") {
			renderer.material.mainTexture = jumpLeft;
			pos = "JL";
		}
	}
}
