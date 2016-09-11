using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelMaker : MonoBehaviour {

    public GameObject[] PanelArray;
    int index;

	// Use this for initialization
	void Start () {
        index = Random.Range(0,6);
        PanelArray[index].SetActive(true);
        PanelArray[index].GetComponent<DragPanel>().enabled = true;
	}
	
}
