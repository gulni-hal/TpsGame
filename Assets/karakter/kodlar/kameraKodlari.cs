using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class kameraKodlari : MonoBehaviour
{

    public Transform hedef;
    public Vector3 hedefMesafe;

    [SerializeField]
    private float fareSensivity; //BU DEGERLERI ARAYUZDEN 3 VE 15 YAPTIM EN PURUZSUZ CALISAN DEGERLER BUNLARDI
    [SerializeField]
    private float orbitDamping;

    Vector3 objRot;
    public Transform karakterSpine;




    //[SerializeField]
    //private float fareSensivity;
    //float fareX;
    //float fareY;



    void Start()
    {
        Cursor.visible = false;
    }
    private void Awake() //cursor un gizlenmesi ile ilgili alan. esc ile cikiliyor
    {
#if UNITY_EDITOR
        var gameWindow = EditorWindow
            .GetWindow(typeof(EditorWindow).Assembly.GetType("UnityEditor.GameView"));
        gameWindow.Focus();
        gameWindow.SendEvent(new Event
        {
            button = 0,
            clickCount = 1,
            type = EventType.MouseDown,
            mousePosition = gameWindow.rootVisualElement.contentRect.center
        });
#endif

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {

    }
    private void LateUpdate()
    {
        //this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
        //fareX = Input.GetAxis("Mouse X") * fareSensivity;
        //fareY = Input.GetAxis("Mouse Y") * fareSensivity;
        //this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
        //hedef.transform.eulerAngles = new Vector3(0, fareX, 0);


        transform.position = hedef.position;

        hedefMesafe.x += Input.GetAxis("Mouse X") * fareSensivity;
        hedefMesafe.y -= Input.GetAxis("Mouse Y") * fareSensivity;

        hedefMesafe.y = Mathf.Clamp(hedefMesafe.y, 0f, 80f);
        Quaternion QT = Quaternion.Euler(hedefMesafe.y, hedefMesafe.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
        Vector3 karakterRot = hedef.transform.eulerAngles; //kameranin rotate etmesi icin ayrica karakterin de ayni yonde rotate etmesi icin rigidbody ver once!!
        karakterRot.y = QT.eulerAngles.y;  //BUNU YAPMADIGIM ZAMAN KARAKTER ZEMININ ICINE GIRIYORDU X NIN 0 OLMASI LAZIM
        hedef.transform.eulerAngles = karakterRot;

        Vector3 temp = this.transform.localEulerAngles;
        temp.z = 0;
        temp.y = 0;
        temp.x = this.transform.localEulerAngles.x+8;
        objRot = temp;
        karakterSpine.transform.localEulerAngles = objRot ; //yukari ve asagi baktiginda spine inda o yonde hareketi icin spine2 kullandim

    }
}

