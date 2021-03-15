using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
 public class cambg : MonoBehaviour {
	 public RawImage img;
     public void startCamera() {
         WebCamDevice[] devices = WebCamTexture.devices;
         string backCamName = devices[0].name;
         WebCamTexture CameraTexture = new WebCamTexture(backCamName,10000,10000,30);
		 img.texture = CameraTexture;
         img.material.mainTexture = CameraTexture;
         CameraTexture.Play();
     }
 }