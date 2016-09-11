using UnityEngine;
using System.Collections;

public class RotarConTouch : MonoBehaviour {

    public GameObject obj; //el objeto que se va a rotar

    public float tiempoInterpolacion = 1f; //el tiempo que va a tardar en rotar el cubo   
    private bool isRotating; //checar si esta rotando el cubo o no
    private float tiempoInicioInterpolacion; //el valor de Time.time cuando se inicio la interpolacion
    private Vector3 startRotation; //la rotacion cuando inicia la interpolacion
    private Vector3 endRotation; //la rotacion cuando terminara la interpolacion


    void IniciarInterpolacion(Vector3 _grados)
    {
        isRotating = true;
        tiempoInicioInterpolacion = Time.time;
        startRotation = transform.localEulerAngles;
        endRotation = transform.localEulerAngles + _grados;
    }

	// Update is called once per frame
	void Update () {

        //Si hay al menos un touch en la pantalla
        if(Input.touchCount > 0)
        {
            //Si ese touch se va mover, empezar la interpolacion 
           if( Input.GetTouch(0).phase == TouchPhase.Moved && isRotating == false)
            {
                if(Input.GetTouch(0).deltaPosition.x > Input.GetTouch(0).deltaPosition.y)
                {
                    if (Input.GetTouch(0).deltaPosition.x > 0) //derecha
                    {
                        IniciarInterpolacion(new Vector3(0, 90, 0));
                    }
                    else if (Input.GetTouch(0).deltaPosition.x < 0) //izquierda
                    {
                        IniciarInterpolacion(new Vector3(0, -90, 0));
                    }
                }
                else
                {
                    if (Input.GetTouch(0).deltaPosition.y > 0) //se esta moviendo para arriba
                    {
                        IniciarInterpolacion(new Vector3(90, 0, 0));
                    }
                    else if (Input.GetTouch(0).deltaPosition.y < 0) //para abajo
                    {
                        IniciarInterpolacion(new Vector3(-90, 0, 0));
                    }
                }               
            }
        }
	
       ///Para probar
       if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            IniciarInterpolacion(new Vector3(90, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            IniciarInterpolacion(new Vector3(-90, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            IniciarInterpolacion(new Vector3(0, -90, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            IniciarInterpolacion(new Vector3(0, 90, 0));
        }
    }

    void FixedUpdate()
    {
        if(isRotating)
        {
            //la interpolacion de unity funciona con porcentajes
            float timeSinceStarted = Time.time - tiempoInicioInterpolacion;
            float percentageComplete = timeSinceStarted / tiempoInterpolacion;

            obj.transform.localEulerAngles = Vector3.Lerp(startRotation, endRotation, percentageComplete);

            if(percentageComplete >= 1.0f)
            {
                isRotating = false;
            }
        }
    }
}
