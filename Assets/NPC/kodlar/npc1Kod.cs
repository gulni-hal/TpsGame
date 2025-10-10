using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class npc1Kod : MonoBehaviour
{
    public float npcHP = 100; // bu degiskeni ileride private yapilmasi gerekiyor simdilik arayuzden zombilerin cani kontrol edilebilsin diye public
    bool npcOlduMu;
    Animator npcAnim;
    public float kovalamaMesafesi;
    public float saldirmaMesafesi;
    float mesafe;
    NavMeshAgent npcNavmesh;

    GameObject hedefOyuncu;

    void Start()
    {
        npcAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("anaKarakter");
        npcNavmesh = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (npcHP <= 0)
        {
            npcOlduMu = true;
        }
        if (npcOlduMu == true)
        {
            npcAnim.SetBool("olum", true);
            StartCoroutine(Kaybolma());
        }
        else
        {
            mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if (mesafe < kovalamaMesafesi)
            {
                npcNavmesh.isStopped = false;
                npcNavmesh.SetDestination(hedefOyuncu.transform.position);
                npcAnim.SetBool("yurume", true);
                npcAnim.SetBool("saldirma", false);
                this.transform.LookAt(hedefOyuncu.transform.position);
            }
            else
            {
                npcNavmesh.isStopped = true;
                npcAnim.SetBool("yurume", false);
                npcAnim.SetBool("saldirma", false);
            }
            if (mesafe < saldirmaMesafesi)
            {
                this.transform.LookAt(hedefOyuncu.transform.position);
                npcNavmesh.isStopped = true;
                npcAnim.SetBool("yurume", false);
                npcAnim.SetBool("saldirma", true);
            }
        }
    }
    public void HasarVer()
    {
        //hedefOyuncu.GetComponent<karakterKodlari>().HasarAl();
    }
    IEnumerator Kaybolma()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);

    }
    public void HasarAl()
    {
        npcHP -= Random.Range(10, 15);
    }
}
