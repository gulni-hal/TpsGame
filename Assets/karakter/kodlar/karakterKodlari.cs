using UnityEngine;

public class karakterKodlari : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    private float karakterHiz;

    private float saglik = 100f;
    private float maxSaglik;


    bool hayattaMi;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        hayattaMi = true;
        maxSaglik = saglik;
    }

    // Update is called once per frame

    void Update()
    {
        if (saglik <= 0)
        {
            hayattaMi = false;
            anim.SetBool("yasiyorMu", hayattaMi);
            GameOver();
        }
        if (hayattaMi == true)
        {
            Hareket();
        }

    }
    public float GetSaglik()
    { 
        return saglik; 
    }
    public float GetMaxSaglik() 
    { 
        return maxSaglik;
    }

    public bool yasiyorMu()
    {
        return hayattaMi;
    }

    public void HasarAl()
    {
        saglik -= Random.Range(5, 10);
        saglik = Mathf.Clamp(saglik, 0f, maxSaglik);
    }
    void Hareket()
    {
        float yatay = Input.GetAxis("Horizontal"); //bunlar project settings deki input managerdeki degiskenler
        float dikey = Input.GetAxis("Vertical");
        anim.SetFloat("horizontal", yatay); //bunlar karakterin animator undeki parametreler zaten anim verdik
        anim.SetFloat("vertical", dikey);
        this.gameObject.transform.Translate(yatay * karakterHiz * Time.deltaTime, 0, dikey * karakterHiz * Time.deltaTime);
    }

    public gameOver gameOver;
    public void GameOver()
    {
        if (saglik <= 0)
        {
            gameOver.Setup();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

}
