using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelKontrol : MonoBehaviour
{
    public GameObject levelTamamlandi;
    public Text kalanZombiText;
    private int kalanNpc;
    void Start()
    {
        kalanNpc = GameObject.FindGameObjectsWithTag("NPC").Length;
        
        
            kalanZombiText.text = "Kalan Zombi: " + kalanNpc;

    }

    public void npcOlduruldu()
    {
        kalanNpc--;

            kalanZombiText.text = "Kalan Zombi: " + kalanNpc;

        if (kalanNpc <= 0)
        {
            // Tüm zombiler öldüyse paneli açar
            levelTamamlandi.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f; // Oyunu durdurmak için
        }
    }

    public void sonrakiLeveleGec()
    {
        Time.timeScale = 1f;// Oyunu devam ettirmek için


        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;


        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Tüm level'lar tamamlandý!");
        }
    }
}
