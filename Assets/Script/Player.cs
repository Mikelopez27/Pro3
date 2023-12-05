using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private new Transform camera;

    public Vector2 sensibility;
    public TextMeshProUGUI textMesh, textAction;
    public TextMeshProUGUI textMesh_cubos;
    public Animator animator_Light,focus1,focus2,focus3,focus4,focus5,focus6,focus7;
    public Animator Door1,Door2,Door3,Door4,Door5,Door6,Door7,Door8, Door9, Door10, Door11,DoorE;
    public Animator animator_Gun;
    public Animator animator_Cube;
    public Button button;
    public GameObject key, kimg;

    CharacterController characterController;
    Vector3 moveInput = Vector3.zero;

    float walkSpeed = 5f;
    float runSpeed = 10f;
    float jumpHeight = 5f;
    float gravityScale = -20f;
    float rayDistace = 5f;
    float rayDistace_Gun = 45f;

    public static int zombies;

    bool zomkey;
    private List<Cube> zombieList = new List<Cube>();
    HandlerDoor puerta;

    Sounds ss;

    int opendoor;
    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Main Camera");
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        zombieList = new List<Cube>(FindObjectsOfType<Cube>());
        puerta = FindObjectOfType<HandlerDoor>();
        zomkey = false;
        zombies = 0;
        button.gameObject.SetActive(false);
        Time.timeScale = 1;
        ss = GameObject.FindGameObjectWithTag("sounds").GetComponent<Sounds>();
        opendoor = 1;
        textAction.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        textMesh_cubos.SetText("" + zombies);

        float horizontal_mouse = Input.GetAxis("Mouse X");
        float vertical_mouse = Input.GetAxis("Mouse Y");

        if (horizontal_mouse != 0)
        {
            transform.Rotate(Vector3.up * sensibility.x * horizontal_mouse);
        }


        if (vertical_mouse != 0)
        {
            float angle = (camera.localEulerAngles.x - vertical_mouse
                * sensibility.y + 360) % 360;
            if (angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -80, 80);

            camera.localEulerAngles = Vector3.right * angle;
        }

        if (characterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"),
            0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveInput = transform.TransformDirection(moveInput) * runSpeed;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            }

        }

        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            animator_Gun.SetInteger("estado", 1);
        }

        Debug.DrawRay(camera.position, camera.forward * rayDistace, Color.red);
        Debug.DrawRay(camera.position, camera.forward * rayDistace_Gun, Color.blue);

        RaycastHit hit_Gun;
        if (Physics.Raycast(camera.position, camera.forward, out hit_Gun, rayDistace_Gun,
            LayerMask.GetMask("RayCastGun")))
        {

            Cube enemy = hit_Gun.transform.GetComponent<Cube>();
            if (enemy != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    enemy.DamangeZombie();
                }
            }

        }
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistace,
            LayerMask.GetMask("RayCast")))
        {
            textAction.enabled = true;

            if (hit.transform.name == "DoorE")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor) && kimg.activeSelf)
                {
                    ss.DoorOpen();
                    kimg.SetActive(false);
                    DoorE.SetInteger("estado", 1);
                }
                else if (Input.GetMouseButtonDown(opendoor) && !kimg.activeSelf)
                {
                    textMesh.enabled = true;
                    textMesh.SetText("Necesitas la llave");
                    Invoke("HideText", 5f);
                }
            }

            if (hit.transform.name == "Door1")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door1.SetInteger("estado", 1);               
                }
            }
            if (hit.transform.name == "Door2")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door2.SetInteger("estado", 1);               
                }
            }
            if (hit.transform.name == "Door3")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door3.SetInteger("estado", 1);               
                }
            }
            if (hit.transform.name == "Door4")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door4.SetInteger("estado", 1);
                }
            }
            if (hit.transform.name == "Door5")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door5.SetInteger("estado", 1);
                }
            }
            if (hit.transform.name == "Door6")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door6.SetInteger("estado", 1);
                }
            }
            if (hit.transform.name == "Door7")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door7.SetInteger("estado", 1);
                }
            }
            if (hit.transform.name == "Door8")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door8.SetInteger("estado", 1);
                }
            }
            if (hit.transform.name == "Door9")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door9.SetInteger("estado", 1);
                }
            }
            if (hit.transform.name == "Door10")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door10.SetInteger("estado", 1);
                }
            }
            if (hit.transform.name == "Door11")
            {
                textAction.SetText("Abrir puerta");
                if (Input.GetMouseButtonDown(opendoor))
                {
                    ss.DoorOpen();
                    Door11.SetInteger("estado", 1);
                }
            }






            if (hit.transform.name == "Apagador")
            {
                textAction.SetText("Apagar luz");

                if (Input.GetMouseButtonDown(0))
                {
                    animator_Light.SetInteger("estado", 3);
                }
            }
            if (hit.transform.name == "Apagador1")
            {
                textAction.SetText("Apagar luz");

                if (Input.GetMouseButtonDown(0))
                {
                    focus1.SetInteger("estado", 3);
                }
            }
            if (hit.transform.name == "Apagador2")
            {
                textAction.SetText("Apagar luz");

                if (Input.GetMouseButtonDown(0))
                {
                    focus3.SetInteger("estado", 3);
                }
            }
            if (hit.transform.name == "Apagador3")
            {
                textAction.SetText("Apagar luz");
                if (Input.GetMouseButtonDown(0))
                {
                    focus4.SetInteger("estado", 3);
                }
            }
            if (hit.transform.name == "Apagador4" || hit.transform.name == "Apagador5")
            {
                textAction.SetText("Apagar luz");

                if (Input.GetMouseButtonDown(0))
                {
                    focus5.SetInteger("estado", 3);
                    focus6.SetInteger("estado", 3);
                    focus7.SetInteger("estado", 3);
                }
            }
            if (hit.transform.name == "Apagador6")
            {
                textAction.SetText("Apagar luz");

                if (Input.GetMouseButtonDown(0))
                {
                    focus2.SetInteger("estado", 3);
                }
            }


            if (hit.transform.name == "rust_key(Clone)")
            {
                textAction.SetText("Recoger llave");
                if (Input.GetMouseButtonDown(1))
                {
                    ss.keyCollect();
                    kimg.SetActive(true);
                    Destroy(hit.transform.gameObject);
                }

            }
        }
        else
        {
            textAction.enabled =false;
        }

        if (zombies == 10 && !zomkey)
        {
            RespawnKey();
            zomkey = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            button.gameObject.SetActive(true);
        }
    }

    private void RespawnKey()
    {
        textMesh.enabled = true;
        textMesh.SetText("La llave esta en una de las 5 habitaciones");
        Invoke("HideText", 5f);
        int keyint = Random.Range(1, 6);
        switch (keyint)
        {
            case 1: Instantiate(key, new Vector3(13.27f, 0.372f, 53.23f), transform.rotation); break;
            case 2: Instantiate(key, new Vector3(117.7f, 0.372f, -3.8f), transform.rotation); break;
            case 3: Instantiate(key, new Vector3(236.37f, 0.372f, -16.26f), transform.rotation); break;
            case 4: Instantiate(key, new Vector3(225.5f, 0.372f, 147.5f), transform.rotation); break;
            case 5: Instantiate(key, new Vector3(136.86f, 0.372f, 155.89f), transform.rotation); break;
        }
    }

    void HideText()
    {
        textMesh.enabled = false;
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
