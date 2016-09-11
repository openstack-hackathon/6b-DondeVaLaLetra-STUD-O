using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    
    void Awake()
    {
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    public void StartGame()
    {
        GameObject.Find("Cube").GetComponent<RotarConTouch>().enabled = true;
        GameObject.Find("Cube").GetComponent<Animation>().Stop();
        GameObject.Find("Cube").transform.position = Vector3.zero;
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("GameCanvas").GetComponent<Canvas>().enabled = true;
    }

    public void BackButtonAction()
    {
        GameObject.Find("Cube").GetComponent<RotarConTouch>().enabled = false;
        GameObject.Find("Cube").GetComponent<Animation>().Play("UpandDownCube");
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = true;
        GameObject.Find("GameCanvas").GetComponent<Canvas>().enabled = false;
    }

    public void EndGame()
    {
        Debug.Log("I QUIT, BYE");
        Application.Quit();
    }
}
