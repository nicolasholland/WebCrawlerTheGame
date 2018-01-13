using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tiles : MonoBehaviour {
	public List<GameObject> quads;

	int nofTiles = 8; // WHEN ADDING NEW TILES, THIS INT MUST BE UPDATED
	Texture tex1;
	Texture tex2;
	Texture tex3;
	Texture tex4;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	void Start() {
		quads = new List<GameObject> ();
		tex1 = Resources.Load("set6_example1") as Texture;
		tex2 = Resources.Load("m-012") as Texture;
		tex3 = Resources.Load("m-018") as Texture;
		tex4 = Resources.Load("m-019") as Texture;
	}


	public float CreateTile(float pushRight) { // WHEN ADDING NEW TILES, THIS METHOD MUST BE UPDATED
		int a = Random.Range(2,nofTiles);
		
		switch (a) {
		case 2:
			return CreateTile2(pushRight);
		case 3:
			return CreateTile3(pushRight);
		case 4:
			return CreateTile4(pushRight);
		case 5:
			return CreateTile5(pushRight);
		case 6:
			return CreateTile6(pushRight);
		case 7:
			return CreateTile7(pushRight);
		}
		return pushRight;
	}

	public float CreateEndTile(float pushRight) {
		CreateQuad (1.279331f + pushRight, 0, 6.608122f, 0.611719f, 0, tex1, 5, 1);
		return CreateQuad (4.797293f + pushRight, 3.018639f, 6.608122f, 0.611719f, 90, tex1, 5, 1);
	}

	public void RemoveQuads() {
		foreach (GameObject quad in quads) {
			Destroy(quad);
		}
	}

	public float CreateTile1 (float pushRight) {
		return CreateQuad (-3.158899f + pushRight, 3.021443f, 6.608122f, 0.611719f, 90, tex1, 5, 1);
	}

	
	// 2 Platforms to get across
	float CreateTile2 (float pushRight) {
		CreateQuad (-0.1018927f + pushRight, 0, 9.672381f, 0.611719f, 0, tex1, 15, 1);
		CreateQuad (6.217007f + pushRight, 0.3555756f, 2.959224f, 4.879398f, 0, tex2, 1, 1);
		CreateQuad (9.736044f + pushRight, 0.1544112f, 6.637933f, 0.611719f, 312.8848f, tex1, 5, 1);
		CreateQuad (17.3499f + pushRight, -2.329844f, 11.24717f, 0.611719f, 0, tex1, 15, 1);
		CreateQuad (11.50305f + pushRight, 4.221287f, 1.981393f, 0.5018996f, 0, tex1, 5, 1);
		CreateQuad (16.41576f + pushRight, 6.044702f, 1.981393f, 0.5018996f, 0, tex1, 5, 1);
		CreateQuad (23.05649f + pushRight, 1.396568f, 2.05859f, 6.982877f, 0, tex2, 1, 2);
		return CreateQuad (27.56157f + pushRight, 0, 7.737907f, 0.611719f, 0, tex1, 15, 1);
	}
	
	// 4 platforms to get up before jumping over the obstacle 
	float CreateTile3 (float pushRight) {
		CreateQuad (2.909257f + pushRight, 3.388084f, 2.208272f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (-1.440975f + pushRight, 6.868273f, 2.208272f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (2.909257f + pushRight, 10.30703f, 2.208272f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (-1.440975f + pushRight, 14.12268f, 2.208272f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (10.88306f + pushRight, 15.38894f, 14.35374f, 0.611719f, 0, tex4, 15, 1);
		CreateQuad (24.5727f + pushRight, 4.117167f, 8.753485f, 0.611719f, 90, tex1, 5, 1);
		return CreateQuad (13.11304f + pushRight, 0, 38.48837f, 0.611719f, 0, tex1, 30, 1);
	}
	
	// 2 platforms to over a obstacle that you cant get out of
	float CreateTile4 (float pushRight) {
		CreateQuad (1.279331f + pushRight, 0, 10.78877f, 0.611719f, 0, tex1, 15, 1);
		CreateQuad (10.08678f + pushRight, 2.710249f, 10.78877f, 0.611719f, 31.26487f, tex1, 5, 1);
		CreateQuad (17.2229f + pushRight, 5.450396f, 5.394385f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (19.6018f + pushRight, 2.616403f, 5.798965f, 0.611719f, 90, tex1, 5, 1);
		CreateQuad (24.85879f + pushRight, 0, 10.78877f, 0.611719f, 0, tex1, 15, 1);
		CreateQuad (23.08327f + pushRight, 7.526335f, 2.199892f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (27.78512f + pushRight, 7.526335f, 2.199892f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (32.97795f + pushRight, 2.616405f, 5.798965f, 0.611719f, 90, tex1, 5, 1);
		return CreateQuad (35.24169f + pushRight, 0, 10.08918f, 0.611719f, 0, tex1, 15, 1);
	}
	
	// walk under an L
	float CreateTile5 (float pushRight) {
		CreateQuad (1.279331f + pushRight, 0, 10.78877f, 0.611719f, 0, tex1, 15, 1);
		CreateQuad (19.8735f + pushRight, 0, 13.62757f, 0.611719f, 0, tex1, 15, 1);
		CreateQuad (13.35836f + pushRight, 2.949811f, 5.984398f, 0.611719f, 90, tex1, 5, 1);
		CreateQuad (9.794806f + pushRight, 2.78983f, 9.035595f, 0.611719f, 40, tex1, 5, 1);
		CreateQuad (19.83938f + pushRight, 6.80408f, 5.984398f, 0.611719f, 90, tex1, 5, 1);
		CreateQuad (21.30868f + pushRight, 3.5919f, 3.577237f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (26.37995f + pushRight, 2.949813f, 5.984398f, 0.611719f, 90, tex1, 5, 1);
		return CreateQuad (29.34095f + pushRight, 0, 5.451026f, 0.611719f, 0, tex1, 5, 1);
	}
	
	// walk under a backwards F
	float CreateTile6 (float pushRight) {
		CreateQuad (0.4413492f + pushRight, 0, 6.608122f, 0.611719f, 0, tex1, 15, 1);
		CreateQuad (4.980427f + pushRight, 1.360697f, 2.478042f, 3.333869f, 0, tex2, 1, 1);
		CreateQuad (10.67938f + pushRight, 7.950505f, 9.670589f, 0.611719f, 90, tex1, 5, 1);
		CreateQuad (9.357337f + pushRight, 5.867234f, 2.072247f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (4.61437f + pushRight, 9.099481f, 2.072247f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (9.392473f + pushRight, 12.47584f, 2.072247f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (15.11918f + pushRight, 9.064346f, 2.072247f, 0.611719f, 0, tex1, 5, 1);
		CreateQuad (19.65549f + pushRight, 4.668916f, 9.670589f, 0.611719f, 90, tex1, 5, 1);
		return CreateQuad (17.48783f + pushRight, 0, 24.11313f, 0.611719f, 0, tex1, 40, 1);
	}
	
	// Half Pyramid with whole
	float CreateTile7 (float pushRight) {
		CreateQuad (1.279331f + pushRight, 0, 6.608122f, 0.611719f, 0, tex1, 15, 1);
		CreateQuad (6.477248f + pushRight, 2.452379f, 6.608122f, 0.611719f, 50, tex1, 5, 1);
		CreateQuad (12.90338f + pushRight, 10.11075f, 6.608122f, 0.611719f, 50, tex1, 5, 1);
		CreateQuad (20.19374f + pushRight, 11.34825f, 2.100159f, 0.611719f, 0, tex1, 5, 1);
		return CreateQuad (16.52033f + pushRight, 0, 24.00181f, 0.611719f, 0, tex1, 40, 1);
	}
	
	float CreateQuad(float posX, float posY, float scaleX, float scaleY, float rotation, Texture image, float texX, float texY) {
		GameObject quad = GameObject.CreatePrimitive (PrimitiveType.Quad);

		DestroyImmediate (quad.collider); // Remove meshcolider
		var collider = quad.AddComponent<BoxCollider2D>(); // Add BoxCollider2D
		quad.layer = LayerMask.NameToLayer("Obstacle");
		quad.transform.position = new Vector3(posX, posY, 0);
		quad.transform.localScale = new Vector3 (scaleX, scaleY, 1);
		quad.transform.Rotate (new Vector3 (0, 0, rotation));


		
		quad.renderer.material.shader = Shader.Find ("Self-Illumin/Diffuse");
		quad.renderer.material.mainTexture = image;
		quad.renderer.material.SetTextureScale("_MainTex", new Vector2(texX, texY));


		quads.Add (quad);
		
		return collider.bounds.max.x;
	}
}
