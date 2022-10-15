using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamara : MonoBehaviour
{
    public Vector2 sensibility;//Sensibilidad de camara
    private new Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Main Camera");//Buscar un hijo en la gerarquia
        Cursor.lockState = CursorLockMode.Locked;//Cursor no salga del juego
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Mouse X");
        float Vertical = Input.GetAxis("Mouse Y");

        if(Horizontal != 0){
            transform.Rotate(Vector3.up * Horizontal * sensibility.x);
        }
        if(Vertical != 0){
            //camera.Rotate(Vector3.left * Vertical * sensibility.y);

            float angle = (camera.localEulerAngles.x - Vertical *sensibility.y + 360)%360; //Angulo actual de la camara
            if(angle > 180){
                angle -= 360;
            }
            angle = Mathf.Clamp(angle, -70,50);
            camera.localEulerAngles = Vector3.right * angle;
        }
    }
}
