using UnityEngine;
using UnityEngine.SceneManagement;

public class levelKontrol : MonoBehaviour
{
    public GameObject levelTamamlandi;
    private int kalanNpc;

    void Start()
    {
        kalanNpc = GameObject.FindGameObjectsWithTag("NPC").Length;
    }

    public void npcOlduruldu()
    {
        kalanNpc--;

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
