using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_4 : MonoBehaviour
{
    public Transform playerCamera;
    public float sensitivity = 200f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        // zak³adamy, ¿e komponent CharacterController jest ju¿ podpiêty pod obiekt
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // -----------------------------------------------------------------------------
        //                                  Chód
        // -----------------------------------------------------------------------------

        // wyci¹gamy wartoœci, aby mo¿liwe by³o ich efektywniejsze wykorzystanie w funkcji
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // dziêki parametrowi playerGrounded mo¿emy dodaæ zachowania, które bêd¹
        // mog³y byæ uruchomione dla ka¿dego z dwóch stanów
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // zmieniamy sposób poruszania siê postaci
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // transform.right odpowiada za ruch wzd³u¿ osi x (pamiêtajmy, ¿e wartoœci bêd¹ zarówno dodatnie
        // jak i ujemne, a punkt (0,0) jest na œrodku ekranu) a transform.forward za ruch wzd³u¿ osi z.
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // wzór na si³ê 
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // prêdkoœæ swobodnego opadania zgodnie ze wzorem y = (1/2 * g) * t-kwadrat 
        // okazuje siê, ¿e jest to zbyt wolne opadanie, wiêc zastosowano g * t-kwadrat
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // -----------------------------------------------------------------------------
        //                                  Obrót
        // -----------------------------------------------------------------------------

        // pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotacjê wokó³ osi Y
        transform.Rotate(Vector3.up * mouseXMove);

        // Pobieramy wartoœci obecnego obrotu obiektu kamery
        Vector3 currentCameraXRotation = playerCamera.transform.localEulerAngles;

        // Sprawdzamy, czy obrót przekroczy³ 90 stopni. Sprawdzamy `y`
        // dlatego, ¿e po przekroczeniu 90 stopni na osi X nastêpuje zmiana na `y` i `z` na 180 stopni,
        // a na `x` stopnie zaczynaj¹ maleæ.
        if (currentCameraXRotation.y >= 180 && currentCameraXRotation.x > 90.0f)
        {
            playerCamera.localEulerAngles = new Vector3(-90f, 0f, 0f);
        }
        else if (currentCameraXRotation.y >= 180 && currentCameraXRotation.x < 270.0f)
        {
            playerCamera.localEulerAngles = new Vector3(90f, 0f, 0f);
        }
        else
        {
            // Je¿eli obrót nie przekracza 90 stopni to po prostu obracamy.
            // Dzia³a bez Mathf.Clamp, ale dla zabezpieczenia lepiej to ustawiæ.
            // Nie mog³em tego zrobiæ bez tych if'ów, które zaprzeczaj¹ sensowi `Mathf.Clamp()`, bo musia³bym operowaæ na 
            // Quaternionach. Gdy ustawia³em po prostu Clamp, to wartoœci -/+ 90 stopni by³y przekraczane,
            // bo przy obrocie ponad 90 stopni otrzymywa³em wartoœci 89, 88, 87... wiêc Clamp ich nie ³apa³.
            // £apa³ natomiast wartoœci > 90 stopni, czyli patrzenie do góry by³o niemo¿liwe, bo by³y to wartoœci > 270st.
            // Mog³em po prostu u¿yæ z³ego podejœcia i operowanie na k¹tach Eulera by³o zbêdne, jednak nie mog³em znaleŸæ innego rozwi¹zania
            playerCamera.Rotate(new Vector3(Mathf.Clamp(-mouseYMove, -90, 90), 0f, 0f), Space.Self);
        }
    }

}
