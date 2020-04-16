using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;

public class AnaMekanik : MonoBehaviour
{
    public Transform Hedef;
    public Button FireBut;
    public GameObject Roket;
    public Transform Namlu;
    public Transform AtesHedefi;
    public RectTransform Hedefİcon;
    public GameObject HedefDurumDeğis;
    public TouchField TouchZone;
    public AudioSource PatlamaSes;
    public AudioClip Patlama;
    public bool Kontrol = false;
    public bool İsaretledinmiKontrol = false;
    public GameObject PostPros;
    public GameObject AnaPros;
    public float DönüsHizi = 1.0f;
    
   public bool KontrolKosma;


    //float Sayac = 0;

    

    private void Awake()
    {
        
        Instantiate(AnaPros, transform.position, Quaternion.identity);
        HedefDurumDeğis.SetActive(false);
    }
    void Update()
    {
        transform.Rotate(0, 0, DönüsHizi * Time.deltaTime);
        Destroy(GameObject.Find("Patlama-1(Clone)"), 6f);
        Destroy(GameObject.Find("Patlama-2(Clone)"), 6f);
        
        HedefTespit();
        HedefTespitİsaret();
        RoketAtesi();
    }
    
    void HedefTespit()
    {
        
        RaycastHit Temas;
        Ray Isik = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(Isik,out Temas))
        {
            Hedef.position = Temas.point;
        }

    }
    void HedefTespitİsaret()
    {
        if (TouchZone.Pressed&&Kontrol==false)
        {
            if (Time.time>=0)
            {
                
                HedefDurumDeğis.SetActive(true);
                İsaretledinmiKontrol = true;
                //Transform Yenipos = Instantiate(Hedef, Hedef.position, Hedef.rotation);
                //Transform Moupos = Input.mousePosition;
                AtesHedefi.position = Hedef.position;

                Hedefİcon.position = Input.mousePosition;
                Debug.Log("Basildi");
                
                
                //Kontrol = true;
                
                //GameObject YeniRoket = Instantiate(Roket, Namlu.position, Quaternion.identity);
                //YeniRoket.transform.LookAt(Hedef);
                //GetComponent<Camera>().enabled = false;
                //YeniRoket.GetComponent<Camera>().enabled = true;

                //YeniRoket.GetComponent<Rigidbody>().AddForce(Hedef.position-transform.position);
            }
            

        }
        else
        {
            //Kontrol = false;
        }
    }
    void RoketAtesi()
    {
        if (FireBut.Pressed&&Kontrol==false&&İsaretledinmiKontrol==true)
        {
            Kontrol = true;
            KontrolKosma = true;
            PatlamaSes.PlayOneShot(Patlama);
            HedefDurumDeğis.SetActive(false);
            GameObject YeniRoket = Instantiate(Roket, Namlu.position, Quaternion.identity);
            YeniRoket.transform.LookAt(AtesHedefi);
            GetComponent<Camera>().enabled = false;
            YeniRoket.GetComponent<Camera>().enabled = true;

            YeniRoket.GetComponent<Rigidbody>().AddForce(AtesHedefi.position - transform.position);
            //Kontrol = false;
            //Sayac = 0;
            Destroy(GameObject.Find("Hedef(Clone)"),2f);
            Destroy(GameObject.Find("PostVolme(Clone)"));
            Instantiate(PostPros, transform.position, Quaternion.identity);

           
            
            
        }
        
    }
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;//Burada Gizmos görülen büyüklüğü 1f bir Küre oluşturuyoruz.
    //    Gizmos.DrawSphere(GizAlan.position, 7.0f);
    //}

}
