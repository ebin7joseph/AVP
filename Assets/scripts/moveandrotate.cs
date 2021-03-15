using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveandrotate : MonoBehaviour
{
    float speed = 0.8f;
	float scale = 0.01f;
	int anglespeed = 30;
    public bool shouldMove = false;

    Vector3 startingPosition;
    Quaternion startingRotation;
    Vector3 startingLocalScale;

    Vector3 scaleChange;
    void Start() {
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        startingLocalScale = transform.localScale;
    }
    
    void Update()
    {
        Vector3 pos = transform.position;

        if(shouldMove)  {
            if (Input.GetKey ("d")) {
                pos.x += speed * Time.deltaTime;
                transform.position = pos;
                SavePosition();
            }
            if (Input.GetKey ("a")) {
                pos.x -= speed * Time.deltaTime;
                transform.position = pos;
                SavePosition();
            }
            if (Input.GetKey ("w")) {
                pos.y += speed * Time.deltaTime;
                transform.position = pos;
                SavePosition();
            }
            if (Input.GetKey ("s")) {
                pos.y -= speed * Time.deltaTime;
                transform.position = pos;
                SavePosition();
            }
            
                    
            if (Input.GetKey("e")) {
                gameObject.transform.localScale += gameObject.transform.localScale * scale;
                SavePosition();
            }
            if (Input.GetKey("q")) {
                gameObject.transform.localScale -= gameObject.transform.localScale * scale;
                SavePosition();
            }
            
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(Vector3.up * anglespeed * Time.deltaTime);
                SavePosition();
            }
                
            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(-Vector3.up * anglespeed * Time.deltaTime);
                SavePosition();
            }
            
            if (Input.GetKey(KeyCode.DownArrow)) {
                transform.Rotate(Vector3.right * anglespeed * Time.deltaTime);
                SavePosition();
            }
                
            if (Input.GetKey(KeyCode.UpArrow)) {
                transform.Rotate(-Vector3.right * anglespeed * Time.deltaTime);
                SavePosition();
            }
            
            
            // if (Input.GetKey(KeyCode.LeftCurlyBracket)) {
            //     if(speed > 0.2f) {
            //         speed -= 0.2f;
            //     }
            // }
            // if (Input.GetKey(KeyCode.RightCurlyBracket)) {
            //     speed += 0.2f;
            // }
            // if (Input.GetKey(KeyCode.Less)) {
            //     if( scale > 0.02f) {
            //     scale -= 0.02f;
            //     }
            // }
            // if (Input.GetKey(KeyCode.Greater)) {
            //     scale += 0.02f;
            // }

            if (Input.GetKey("r")) {
                transform.position = startingPosition;
                transform.rotation = startingRotation;
                transform.localScale = startingLocalScale;
                speed = 3f;
                scale = 0.1f;
                anglespeed = 30;
                SavePosition();
            }

            if(Input.GetKey("m")) {
                scaleChange = new Vector3(0.01f, 0f, 0f);
                gameObject.transform.localScale += scaleChange;
                SavePosition();
            }
            if(Input.GetKey("n")) {
                scaleChange = new Vector3(-0.01f, 0f, 0f);
                if( gameObject.transform.localScale.x > 0.02f) {
                    gameObject.transform.localScale += scaleChange;
                    SavePosition();
                }
            }


        }
    }

    void SavePosition()
     {
         PlayerPrefs.SetString("position", "Loaded");
         PlayerPrefs.SetFloat ("posX", this.transform.position.x);
         PlayerPrefs.SetFloat ("posY", this.transform.position.y);
         PlayerPrefs.SetFloat ("posZ", this.transform.position.z);
         PlayerPrefs.SetFloat ("rotX", this.transform.eulerAngles.x);
         PlayerPrefs.SetFloat ("rotY", this.transform.eulerAngles.y);
         PlayerPrefs.SetFloat ("rotZ", this.transform.eulerAngles.z);
         PlayerPrefs.SetFloat ("scaleX", this.transform.localScale.x);
         PlayerPrefs.SetFloat ("scaleY", this.transform.localScale.y);
         PlayerPrefs.SetFloat ("scaleZ", this.transform.localScale.z);
     }
}
