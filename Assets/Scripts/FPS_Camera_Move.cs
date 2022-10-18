using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPS_Camera_Move : MonoBehaviour
{
    /*VARIABLES*/
    [Header("Animacion")]
    private Animator animator;//Acceso al animato

    CharacterController characterController;
    // public GameObject Player;
    /************************** MOVIMIENTO *************************/
    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private bool Moved = false;
    float HorizontalMoved = 0.0f;
    float VerticalMoved = 0.0f;
    private Vector3 move = Vector3.zero;
    /************************** MOVIMIENTO *************************/
    /************************** CAMARA *************************/
    public Vector2 sensibility;//Sensibilidad de camara
    private new Transform camera;
    /************************** CAMARA *************************/
    /************************** RAYCAST *************************/
    public float rayDistance;
    public Texture2D puntero;//Puntero del centro
    public GameObject TextDetect;//Canvas de texto

    GameObject ultimoReconocido = null; //Color de material
    /************************** RAYCAST *************************/
    private bool cooked = false;
    LayerMask mask;
    private Transform ObjetoHijo = null;

    /************************** Libro Recetas *************************/
    GameObject LibroCocina;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        camera = transform.Find("Main Camera");//Buscar un hijo en la gerarquia
        Cursor.lockState = CursorLockMode.Locked;//Cursor no salga del juego

        mask = LayerMask.GetMask("RayCastDetect");
        TextDetect.SetActive(false);//Desactivar text al iniciar el juego

        LibroCocina = GameObject.Find("RecetasScript");//Objeto para enviar el ingrediente actual a la receta
    }

    // Update is called once per frame
    void Update()
    {
        /********************* MOVE **************************/
        Caminar();
        /********************* CAMARA **************************/
        MovimientoCamara();
        /********************* ANIMATION **************************/
        Animaciones();
        /********************* RAYCAST **************************/
        LaunchRayCast();
        /********************* SOLTAROBJETO **************************/
        Soltar();
    }


    private void Caminar()
    {
        if (characterController.isGrounded)//Detectar si esta en contacto con el suelo con el controller
        {
            HorizontalMoved = Input.GetAxis("Horizontal");
            VerticalMoved = Input.GetAxis("Vertical");
            move = new Vector3(HorizontalMoved, 0.0f, VerticalMoved);
            move = transform.TransformDirection(move) * walkSpeed;
            if (HorizontalMoved != 0 && VerticalMoved != 0)
            {
                Moved = true;
            }
            else
            {
                Moved = false;
            }
        }
        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
    }//FIN DE CAMINAR

    private void MovimientoCamara()
    {
        float Horizontal = Input.GetAxis("Mouse X");
        float Vertical = Input.GetAxis("Mouse Y");

        if (Horizontal != 0)
        {
            transform.Rotate(Vector3.up * Horizontal * sensibility.x);
        }
        if (Vertical != 0)
        {
            Moved = true;
            //camera.Rotate(Vector3.left * Vertical * sensibility.y);

            float angle = (camera.localEulerAngles.x - Vertical * sensibility.y + 360) % 360; //Angulo actual de la camara
            if (angle > 180)
            {
                angle -= 360;
            }
            angle = Mathf.Clamp(angle, -70, 50);
            camera.localEulerAngles = Vector3.right * angle;
        }
    }//FIN DE CAMARA

    private void Animaciones()
    {
        float cookedInput = Input.GetAxis("Jump");

        if (cookedInput != 0)
        {
            cooked = true;
        }
        else
        {
            cooked = false;
        }

        animator.SetBool("Caminar", Moved);
        animator.SetBool("Cooked", cooked);
    }

    private void LaunchRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, mask))//Si el rayo toca algo
        {
            Deselect();
            SelectedObject(hit.transform);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.tag == "Palanca")
                {
                    hit.collider.GetComponent<Palanca>().ActivarPalanca();
                }
                else
                {
                    ObjetoHijo = hit.transform;
                    ObjetoHijo.GetComponent<Rigidbody>().useGravity = false;
                    ObjetoHijo.GetComponent<Rigidbody>().isKinematic = true;
                    //hit.collider.transform.GetComponent<ObjInteractivo>().ActivarObjeto(); //Ejecuta Funcion destruir de otro script 
                    Apadrinar(ObjetoHijo.transform);
                }
            }
        }
        else
        {
            Deselect();//Desmarcar objetos 
        }
    }


    private void SelectedObject(Transform transform)//Pinta de color el objeto seleccionado
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
        ultimoReconocido = transform.gameObject;
    }

    void Deselect()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }


    private void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);

        GUI.DrawTexture(rect, puntero);

        if (ultimoReconocido)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
    }


    private void Apadrinar(Transform transformHijo)
    {


     

        if (transformHijo.tag != "Untagged" && camera.childCount == 0)
        {
            transformHijo.parent = null;

            if(transformHijo.name != "RecompensaActiva"){ 
            Instantiate(transformHijo);
            }
        }

        if (camera.childCount == 0)
        {
            transformHijo.SetParent(camera);//Asignar como hijo de player
            Vector3 newRotation = new Vector3(0, 0, 0);
            transformHijo.eulerAngles = newRotation;
            transformHijo.tag = "Untagged";

            LibroCocina.GetComponent<LibroRecetas>().IngredienteEnMano(transformHijo.name);
            //Debug.Log("ObjetoActual: " + transformHijo.name);
        }
    }

    private void Soltar()
    {
        if (Input.GetKeyUp(KeyCode.Space) && ObjetoHijo != null)
        {
            ObjetoHijo.GetComponent<Rigidbody>().useGravity = true;
            ObjetoHijo.GetComponent<Rigidbody>().isKinematic = false;
            ObjetoHijo.parent = null;
            ObjetoHijo = null;
        }
    }
}
