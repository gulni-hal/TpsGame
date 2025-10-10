using UnityEngine;

public class atesetmeKodlari : MonoBehaviour
{
    public Camera kamera;
    public LayerMask npcLayer;
    void Start()
    {
        kamera = Camera.main;
    }

    void Update()
    {
        if ( Input.GetMouseButton(0)) // sol click basildigi zaman
        {
             AtesEtme();
        }
       
    }

    private void AtesEtme() {
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//ekranin orta degerleri
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, npcLayer)) {
            hit.collider.gameObject.GetComponent<npc1Kod>().HasarAl(); //npckodlarindaki hasarAl function ina gidiyor layer da npc i layer i vermek lazim ama
        }
    }
}
 