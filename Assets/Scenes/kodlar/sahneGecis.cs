using UnityEngine;
using UnityEngine.SceneManagement;

public class sahneGecis : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void oyunBaslama()
    {
        Time.timeScale = 1f; // bu olmayinca level 1 den tekrar basladigi zaman kamera ve karakter donuyordu
        SceneManager.LoadScene(1);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void cikis()
    {
        Application.Quit();
    }
}
