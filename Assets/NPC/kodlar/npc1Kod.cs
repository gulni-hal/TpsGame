using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class npc1Kod : MonoBehaviour
{
    public float npcHP = 100;
    bool npcOlduMu = false;
    bool coroutineBasladi = false;

    Animator npcAnim;
    public float kovalamaMesafesi;
    public float saldirmaMesafesi;
    float mesafe;
    NavMeshAgent npcNavmesh;
    GameObject hedefOyuncu;
    AudioSource sesKaynagi;
    public AudioClip saldirmaSesi;

    void Start()
    {
        npcAnim = GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("anaKarakter");
        npcNavmesh = GetComponent<NavMeshAgent>();
        sesKaynagi = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (npcHP <= 0 && !npcOlduMu)
        {
            npcOlduMu = true;
            npcAnim.SetBool("olum", true);
            npcNavmesh.isStopped = true;

            if (!coroutineBasladi)
            {
                coroutineBasladi = true;
                StartCoroutine(Kaybolma());
            }
            return; // Öldüyse geri kalan kodu çalýþtýrmasýn
        }

        if (!npcOlduMu)
        {
            mesafe = Vector3.Distance(transform.position, hedefOyuncu.transform.position);

            if (mesafe < kovalamaMesafesi)
            {
                npcNavmesh.isStopped = false;
                npcNavmesh.SetDestination(hedefOyuncu.transform.position);
                npcAnim.SetBool("yurume", true);
                transform.LookAt(hedefOyuncu.transform.position);
            }
            else
            {
                npcNavmesh.isStopped = true;
                npcAnim.SetBool("yurume", false);
                npcAnim.SetBool("saldirma", false);
            }

            if (mesafe < saldirmaMesafesi)
            {
                transform.LookAt(hedefOyuncu.transform.position);
                npcNavmesh.isStopped = true;
                npcAnim.SetBool("yurume", false);
                npcAnim.SetBool("saldirma", true);
            }
        }
    }

    public void HasarVer()
    {
        sesKaynagi.PlayOneShot(saldirmaSesi);
        hedefOyuncu.GetComponent<karakterKodlari>().HasarAl();
    }

    IEnumerator Kaybolma()
    {
        yield return new WaitForSeconds(4);
        FindFirstObjectByType<levelKontrol>().npcOlduruldu();
        Destroy(gameObject);
    }

    public void HasarAl()
    {
        npcHP -= Random.Range(20, 25);
    }
}
