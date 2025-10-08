using UnityEngine;

public class karakterKodlari : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    private float karakterHiz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
  
        void Update()
        {
            Hareket();
        }
        void Hareket()
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            anim.SetFloat("horizontal", yatay);
            anim.SetFloat("vertical", dikey);
            this.gameObject.transform.Translate(yatay* karakterHiz*Time.deltaTime,0,dikey* karakterHiz*Time.deltaTime);
        }
    

}
