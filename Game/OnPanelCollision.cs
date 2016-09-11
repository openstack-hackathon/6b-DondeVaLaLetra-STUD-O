using UnityEngine;
using System.Collections;

public class OnPanelCollision : MonoBehaviour {

    int index;

    void OnCollisionEnter(Collision other)
    {
        //print("I hit something");
        if(other.collider.CompareTag("Panel"))
        {
            Debug.Log("El panel " + other.collider.name + " choco conmigo el lado " + this.name);
            if (other.collider.name == this.name)
            {
                Destroy(other.gameObject);
                FindObjectOfType<PointAdder>()._score++;
                
                do
                {
                    index = Random.Range(0, 5);
                }
                while (FindObjectOfType<PanelMaker>().PanelArray[index] == null);

                FindObjectOfType<PanelMaker>().PanelArray[index].SetActive(true);
                GameObject.Find("Cube").GetComponent<RotarConTouch>().enabled = true;


            }

            else
            {

            }
        }
    }
}
