using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Tiles))]
[RequireComponent (typeof(WebCrawler))]
[RequireComponent (typeof(FillWithContent))]
public class LevelCreater : MonoBehaviour {

	WebCrawler crawler;
	FillWithContent filler;
	Tiles tiles;

	public int nofTilesPerLevel = 5;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	// When Scene 1 is loaded, this method will create a level
	public void OnLevelWasLoaded(int level) {
		if (level == 1) {
			// Create new level
			CreateLevel();
			CreateBackground();

			print (crawler.webpage);
			// Read webpage/Download html code
			crawler.ReadPage();

			// Parse html
			crawler.Parser();

			// Load images
			foreach (string url in crawler.imgUrls) {
				print (url);
				crawler.LoadImage(url);
			}

			filler.FillWithImages(ref crawler.textures, crawler.textures.Count);
		}
	}

	void Start () {
		crawler = GetComponent<WebCrawler> ();
		filler = GetComponent<FillWithContent> ();
		tiles = GetComponent<Tiles> ();
	}

	// This is for testing
	void Update() {
		if (Input.GetKeyDown (KeyCode.E)) {
			
		}


		if (Input.GetKeyDown (KeyCode.E)) {		
			print(tiles.quads.Count);
			Destroy(this);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			// Remove old level
			DestroyLevel();
			Destroy(this);

			Application.LoadLevel(0);
		}


		if (Input.GetKeyDown (KeyCode.N)) {	
			int rnd = Random.Range(1,crawler.urls.Count);

			print (crawler.urls[rnd]);

			crawler.webpage = crawler.urls[rnd];
		}
	}

	public void DestroyLevel() {
		filler.RemoveImages();
		crawler.textures.Clear ();
		crawler.imgUrls.Clear ();
		crawler.urls.Clear ();
		tiles.RemoveQuads ();
	}

	public void CreateLevel() {
		float next;
		next = tiles.CreateTile1 (0);
		next = tiles.CreateTile(0);

		for (int i = 0; i < nofTilesPerLevel; i++) {
			next = tiles.CreateTile(next);
		}
		tiles.CreateEndTile (next);
	}

	void CreateBackground() {
		// Create Background Quads
		GameObject quad1 = GameObject.CreatePrimitive (PrimitiveType.Quad);
		GameObject quad2 = GameObject.CreatePrimitive (PrimitiveType.Quad);
		GameObject quad3 = GameObject.CreatePrimitive (PrimitiveType.Quad);
		GameObject quad4 = GameObject.CreatePrimitive (PrimitiveType.Quad);
		GameObject quad5 = GameObject.CreatePrimitive (PrimitiveType.Quad);
		GameObject quad6 = GameObject.CreatePrimitive (PrimitiveType.Quad);
		
		// Position Quads
		quad1.transform.position = new Vector3(-0.2221918f, 7.3183f, 5);
		quad1.transform.localScale = new Vector3 (44.70375f, 39.00488f, 1);
		quad2.transform.position = new Vector3(-0.2221918f + 2 * quad1.collider.bounds.max.x, 7.3183f, 5);
		quad2.transform.localScale = new Vector3 (44.70375f, 39.00488f, 1);
		quad3.transform.position = new Vector3(-0.2221918f + quad2.collider.bounds.max.x + quad1.collider.bounds.max.x, 7.3183f, 5);
		quad3.transform.localScale = new Vector3 (44.70375f, 39.00488f, 1);
		quad4.transform.position = new Vector3(-0.2221918f + quad3.collider.bounds.max.x + quad1.collider.bounds.max.x, 7.3183f, 5);
		quad4.transform.localScale = new Vector3 (44.70375f, 39.00488f, 1);
		quad5.transform.position = new Vector3(-0.2221918f + quad4.collider.bounds.max.x + quad1.collider.bounds.max.x, 7.3183f, 5);
		quad5.transform.localScale = new Vector3 (44.70375f, 39.00488f, 1);
		quad6.transform.position = new Vector3(-0.2221918f + quad5.collider.bounds.max.x + quad1.collider.bounds.max.x, 7.3183f, 5);
		quad6.transform.localScale = new Vector3 (44.70375f, 39.00488f, 1);

		// Load Textures 
		Texture tex = Resources.Load("m-018") as Texture;
		
		// Apply Textures
		quad1.renderer.material.shader = Shader.Find ("Self-Illumin/Diffuse");
		quad1.renderer.material.mainTexture = tex;
		quad2.renderer.material.shader = Shader.Find ("Self-Illumin/Diffuse");
		quad2.renderer.material.mainTexture = tex;
		quad3.renderer.material.shader = Shader.Find ("Self-Illumin/Diffuse");
		quad3.renderer.material.mainTexture = tex;
		quad4.renderer.material.shader = Shader.Find ("Self-Illumin/Diffuse");
		quad4.renderer.material.mainTexture = tex;
		quad5.renderer.material.shader = Shader.Find ("Self-Illumin/Diffuse");
		quad5.renderer.material.mainTexture = tex;
		quad6.renderer.material.shader = Shader.Find ("Self-Illumin/Diffuse");
		quad6.renderer.material.mainTexture = tex;
	}
}
