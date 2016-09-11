using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointAdder : MonoBehaviour {

    public Text score;
    public int _score;

    void Start()
    {
        _score = 0;
    }

	// Update is called once per frame
	void Update () {
        score.text = "Puntos: " + _score;
	}
}
