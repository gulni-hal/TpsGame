using UnityEngine;

public class atesetmeKodlari : MonoBehaviour
{
    public Camera kamera;
    public LayerMask npcLayer;
    karakterKodlari canKontrol;
    Animator animator;
    public ParticleSystem muzzleAtes;

    private float sarjor = 20   ;
    private float cephane = 120;
    private float sarjorKapasitesi = 20;

    AudioSource sesKaynagi;
    public AudioClip atesSes;
    public AudioClip reloadSes;



    void Start()
    {
        kamera = Camera.main;
        canKontrol = this.gameObject.GetComponent<karakterKodlari>();
        animator = GetComponent<Animator>();
        sesKaynagi = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canKontrol.yasiyorMu() == true)
        {
            if(Input.GetKeyDown(KeyCode.R)&&sarjor < sarjorKapasitesi && cephane > 0)
            {
                animator.SetBool("sarjorDegistirme", true);
                return; // reload sýrasýnda ateþ etme iþlemi yapýlmasýn diye
            }


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
            else if (sarjor == 0 && cephane == 0)
            {

                GameOverMermi();

            }
        }
    }

    public void SarjorDegistirmeSes()
    {
        sesKaynagi.PlayOneShot(reloadSes);
        sesKaynagi.volume = 0.6f;
    }
    public void SarjorDegistirme()
    {
        sesKaynagi.volume = 1f;
        if (cephane > 20)
        {
            cephane -= sarjorKapasitesi - sarjor;
            sarjor = sarjorKapasitesi;
            animator.SetBool("sarjorDegistirme", false);
        }
        else
        {//r ile mermi deðiþtirildiðinde oluþan cephanenin eksiye düþmesini engelleyen kýsým
            sarjor += cephane;
            cephane = 0;
            animator.SetBool("sarjorDegistirme", false);
        }
    }


    public void AtesEtme()
    {
        if (sarjor > 0)
        {

            muzzleAtes.Play();
            sesKaynagi.PlayOneShot(atesSes);
            Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//ekranin orta degerleri
            RaycastHit hit;
            int layerMask = LayerMask.GetMask("Default", "npc");
            //if (Physics.Raycast(ray, out hit, Mathf.Infinity, npcLayer)) //tum engeller default layer inda oldugu icin raycast onlari tanimiyordu
            if (Physics.Raycast(ray, out hit, 100f, layerMask)) //yeni tanimladigimiz mask kullanildi
            {
                //hit.collider.gameObject.GetComponent<npc1Kod>().HasarAl(); //npckodlarindaki hasarAl function ina gidiyor layer da npc i layer i vermek lazim ama
                if (hit.collider.CompareTag("NPC"))
                {
                    npc1Kod npc = hit.collider.GetComponent<npc1Kod>();
                    if (npc != null) // npc ise vur
                    {
                        npc.HasarAl();
                    }
                }
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


    public gameOverMermi gameOverMermi;
    public void GameOverMermi()
    {
        if (sarjor == 0 && cephane == 0)
        {
            gameOverMermi.Setup();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
