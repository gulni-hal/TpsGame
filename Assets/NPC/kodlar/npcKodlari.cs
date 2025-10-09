using UnityEngine;
using System.Collections;

public class npcKodlari : MonoBehaviour
{
    public float npcHP = 100; // bu degiskeni ileride private yapilmasi gerekiyor simdilik arayuzden zombilerin cani kontrol edilebilsin diye public
    bool npcOlduMu; 
    Animator npcAnim;
   
    void Start()
    {
        npcAnim = this.GetComponent<Animator>();
        
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
        else { }
    }
    IEnumerator Kaybolma() {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    
    }
    public void HasarAl() { 
    npcHP-=Random.Range(10, 15);
    }
}
