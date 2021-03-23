using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoplayer : MonoBehaviour
{
	public UnityEngine.Video.VideoPlayer vPlayer;
    public Light directionalLight;
    float deltaIntensity = 0.2f;
    public bool shouldPlay = false;
    void Update()
    {
        if(shouldPlay) {
            if (Input.GetKey(KeyCode.Space)){
                if (vPlayer.isPlaying)
                {
                    vPlayer.Pause();
                }
                else
                {
                    vPlayer.Play();
                }
            }
        }
        if (Input.GetKey("v"))
        {
            if(directionalLight.intensity < 8)  
            {
                directionalLight.intensity += deltaIntensity;
            }
        }
        if (Input.GetKey("c"))
        {
            if(directionalLight.intensity > 0.2f)  
            {
                directionalLight.intensity -= deltaIntensity;
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

		if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                vPlayer.Stop();
            }
        }
 
    }
    public void assign(string path)
    {
        vPlayer.url = path;
    }
}