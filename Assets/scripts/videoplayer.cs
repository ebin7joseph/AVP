using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoplayer : MonoBehaviour
{
	public UnityEngine.Video.VideoPlayer vPlayer;
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