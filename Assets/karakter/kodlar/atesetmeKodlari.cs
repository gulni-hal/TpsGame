using UnityEngine;

public class atesetmeKodlari : MonoBehaviour
{
    public Camera kamera;
    public LayerMask npcLayer;
    karakterKodlari canKontrol;
    Animator animator;
    public ParticleSystem muzzleAtes;

    private float sarjor = 5;
    private float cephane = 10;
    private float sarjorKapasitesi = 5;
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
                if(sarjor > 0)
                {
                    animator.SetBool("atesEt", true);
                }
                if (sarjor <= 0)
                {
                    animator.SetBool("atesEt", false);
                }
                if(sarjor <= 0 && cephane > 0)
                {
                    animator.SetBool("sarjorDegistirme", true);
                    
                }
                
            }
            else if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("atesEt", false);
            }
        }
    }
    public void SarjorDegistirme()
    {
        cephane -= sarjorKapasitesi - sarjor;
        sarjor = sarjorKapasitesi;
        animator.SetBool("sarjorDegistirme", false);
    }

    public void AtesEtme()
    {
        if (sarjor > 0)
        {
            
            muzzleAtes.Play();
            Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//ekranin orta degerleri
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, npcLayer))
            {
                hit.collider.gameObject.GetComponent<npc1Kod>().HasarAl(); //npckodlarindaki hasarAl function ina gidiyor layer da npc i layer i vermek lazim ama
            }
            sarjor--;
        }
       
    }

    public float GetSarjor()
    {
        return sarjor;
    }
    public float GetCephane()
    {
        return cephane;
    }

}
