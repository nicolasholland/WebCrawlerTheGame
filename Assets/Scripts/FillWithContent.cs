using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FillWithContent : MonoBehaviour {

	List<GameObject> quads;

	void Start() {
		quads = new List<GameObject> ();
	}

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public void FillWithImages(ref List<Texture> textures, int count) {
		int xPos = 0;
		int yPos = 5;
		int alt = 1;
		
		for (int imageCount = 0; imageCount < count; imageCount++) {
			
			//Texture tex = Resources.Load ("example") as Texture;
			//Texture tex = crawler.textures[imageCount];
			Texture tex = textures[imageCount];
			
			CreateImage(tex, xPos, yPos);
			
			xPos += 5;
			yPos += alt * 7;
			alt *= -1;
		}
	}

	public void RemoveImages() {
		foreach (GameObject quad in quads) {
			Destroy(quad);
		}
	}

	IEnumerator TestImageDownload() {
		string url = "https://upload.wikimedia.org/wikipedia/en/thumb/e/e7/Cscr-featured.svg/20px-Cscr-featured.svg.png";

		// Start a download of the given URL
		WWW www = new WWW(url);
		
		// Wait for download to complete
		yield return www;
		
		// assign texture
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = www.texture;
	}

	void CreateImage(Texture image, int xPos, int yPos) {
		GameObject quad = GameObject.CreatePrimitive (PrimitiveType.Quad);
		quad.transform.position = new Vector3(xPos, yPos, 1);
		quad.transform.localScale = new Vector3 (5, 4, 1);

		quad.renderer.material.shader = Shader.Find ("Self-Illumin/Diffuse");
		quad.renderer.material.mainTexture = image;

		quads.Add (quad);
	}

	// create door to next level
	public void CreateDoor(int xPos, int yPos)  {

	}
}
