using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO; 

// Python
//using IronPython.Hosting;
//using Microsoft.Scripting;
//using Microsoft.Scripting.Hosting;


public class WebCrawler : MonoBehaviour {

	public List<Texture> textures;
	public List<string> imgUrls;
	public List<string> urls;
	public string webpage;

	string fileName = "links.txt";

	public WWW data;

	void Start() {
		imgUrls = new List<string> ();
		textures = new List<Texture> ();
		urls = new List<string> ();
	}

	public void ReadPageTxt() {
		StreamReader theReader = new StreamReader(fileName, Encoding.Default);

	}

	// Read a Webpage, similar to urllib2.urlopen on python
	public void ReadPage() {
		data = new WWW(webpage);

		StartCoroutine(Wait(data));

		while (!data.isDone) {
			System.Threading.Thread.Sleep(10);
		}
	}

	IEnumerator Wait(WWW data) {
		
		yield return data;
		
		Debug.Log("Done");
	}

	// find images and relevant text
	public void Parser() {
		print (data.text);
		var result = data.text.Split(new [] { '\r', '\n' });
		// loop through htmlcode
		foreach (var line in result) {
			// find lines with images
			if (line.Contains("<img")) {
				// find <img src="URL OF IMAGE" ...
				int startIndex = line.IndexOf("src=\"") + 6;
				string imgsrc = line.Substring(startIndex);

				int endIndex = imgsrc.IndexOf("\"");
				
				// check if there is a .jpg
				if (!(endIndex == -1)) {
					// imgsrc contains the url to the image
					imgsrc = imgsrc.Remove(endIndex);
					imgUrls.Add(imgsrc);
				}
			}

			// find lines with urls
			if (line.Contains("<a href=")) {
				// get url
				int startIndex = line.IndexOf("<a href=") + 9;
				string ahref = line.Substring(startIndex);
				int endIndex = ahref.IndexOf("\"");
				ahref = ahref.Remove(endIndex);

				// check if local or global link
				if (ahref.Contains("http") || ahref.Contains("www")) {
					urls.Add(ahref);
				}
				else {
					urls.Add(CoreUrl(webpage) + ahref);
				}
			}
		}
		Debug.Log ("Done Parsing");
	}

	public void LoadImage(string url) {

		WWW www = new WWW("https:/" + url);

		StartCoroutine(Wait2(www));

		while (!www.isDone) {
			System.Threading.Thread.Sleep(10);
		}

		Debug.Log("Image Download Complete");

		// assign texture
		textures.Add(www.texture);
	}

	IEnumerator Wait2(WWW data) {

		// Wait for download to complete
		yield return data;
		
		Debug.Log("Done");
	}


	// If a given url is e.g. en.wikipedia.org/wiki/Frog
	// The core url is https://en.wikipedia.org
	// The http must be added and everything starting with / afterwards
	public string CoreUrl(string url) {
		// check if it starts with https
		if (!url.Contains ("http")) {
			url = "https://" + url;
		}
		// check ending
		int lind = url.LastIndexOf ("/");
		while (lind >  7) {
			url = url.Remove(lind);
			lind = url.LastIndexOf ("/");
		}

		return url;
	}
}
