using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ArayuzKontrol : MonoBehaviour
{
    public Text mermiText;
    public Text saglikText;
    public GameObject sahteMenu;


    bool oyunDurdu;
    GameObject oyuncu;

        void Start()
    {
        oyuncu = GameObject.Find("anaKarakter");
    }

    void Update()
    {
        mermiText.text = oyuncu.GetComponent<atesetmeKodlari>().GetSarjor().ToString()+"/"+ oyuncu.GetComponent<atesetmeKodlari>().GetCephane().ToString();
        saglikText.text = "HP:" + oyuncu.GetComponent<karakterKodlari>().GetSaglik();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (oyunDurdu == true)
            {
                OyunuDevamEttir();
            }
            else if(oyunDurdu==false)
            {
                OyunuDurdur();
            }
                
        }
    }
    public void OyunuDevamEttir()
    {
        sahteMenu.SetActive(false);
        Time.timeScale = 1;
        oyunDurdu = false;


        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
    public void OyunuDurdur()
    {
        sahteMenu.SetActive(true);
        Time.timeScale = 0;
        oyunDurdu = true;

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }
    
}
