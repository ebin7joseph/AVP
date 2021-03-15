using System;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;


public class ui : MonoBehaviour
{
    public cambg cameraScript;
    public GameObject uicanvas;
    public moveandrotate mover;
    public videoplayer vplayer;
    public Text videoText;
    public Text posText;
    bool shouldStart = false;
    public GameObject playerPlane;
    void Start()
    {

        FileBrowser.SetFilters(true, new FileBrowser.Filter("Videos", ".webm"), new FileBrowser.Filter("Text Files", ".txt"));
        FileBrowser.SetDefaultFilter(".webm");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);

        String videoPath = PlayerPrefs.GetString("path", "Not Loaded");
        String positionLoadInfo = PlayerPrefs.GetString("position", "Not loaded");

        videoText.text = "Video: " + videoPath;
        posText.text = "Previous Position : " + positionLoadInfo;
        if(positionLoadInfo != "Not loaded") {
            LoadPosition();
        }
        if(videoPath != "Not loaded") {
            shouldStart = true;
            vplayer.assign(videoPath);
        }

    }
    public void onSubmit() {
        if(shouldStart) {
            cameraScript.startCamera();
            uicanvas.SetActive(false);
            mover.shouldMove = true;
            vplayer.shouldPlay = true;
        }
    }

    public void onLoad() {
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    IEnumerator ShowLoadDialogCoroutine()
    {

        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, true, null, null, "Load Files", "Load");
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
        {
            for (int i = 0; i < FileBrowser.Result.Length; i++)
            {

                Debug.Log(FileBrowser.Result[i]);
                vplayer.assign(FileBrowser.Result[i]);
                videoText.text = "Video: " + FileBrowser.Result[i];
                PlayerPrefs.SetString("path",FileBrowser.Result[i]);
                shouldStart = true;
            }
        }
    }

    void LoadPosition()
     {
         playerPlane.transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));
         playerPlane.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("rotX"), PlayerPrefs.GetFloat("rotY"), PlayerPrefs.GetFloat("rotZ"));
         playerPlane.transform.localScale= new Vector3(PlayerPrefs.GetFloat("scaleX"), PlayerPrefs.GetFloat("scaleY"), PlayerPrefs.GetFloat("scaleZ"));
     }
}
