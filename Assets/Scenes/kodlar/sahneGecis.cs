using UnityEngine;
using UnityEngine.SceneManagement;

public class sahneGecis : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("debug mesaji");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void oyunBaslama()
    {
        SceneManager.LoadScene(1);
    }

    public void yardimSahnesi()
    {
        SceneManager.LoadScene(2);
    }

    public void cikis()
    {
        Application.Quit();
    }

    public void anaMenüDonus()
    {
        SceneManager.LoadScene(0);
    }
}
