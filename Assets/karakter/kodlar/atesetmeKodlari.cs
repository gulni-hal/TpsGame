using UnityEngine;

public class atesetmeKodlari : MonoBehaviour
{
    public Camera kamera;
    public LayerMask npcLayer;
    karakterKodlari canKontrol;
    Animator animator;
    public ParticleSystem muzzleAtes;
    void Start()
    {
        kamera = Camera.main;
        canKontrol = this.gameObject.GetComponent<karakterKodlari>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canKontrol.yasiyorMu() == true)
        {
            if (Input.GetMouseButton(0)) // sol click basildigi zaman
            {
                animator.SetBool("atesEt", true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("atesEt", false);
            }
        }
    }

    public void AtesEtme()
    {
        muzzleAtes.Play();
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//ekranin orta degerleri
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, npcLayer))
        {
            hit.collider.gameObject.GetComponent<npc1Kod>().HasarAl(); //npckodlarindaki hasarAl function ina gidiyor layer da npc i layer i vermek lazim ama
        }
    }
}
