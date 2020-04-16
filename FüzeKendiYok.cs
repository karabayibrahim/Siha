using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FüzeKendiYok : MonoBehaviour
{
    public Transform CarpismaNoktasi;
    public int secim;
    public AudioClip[] PatlamaSesiClip;
    public GameObject[] PatlamaSesObjeleri;

    private void Start()
    {
        PatlamaSesObjeleri[0] = GameObject.Find("Patlama-1");
        PatlamaSesObjeleri[1] = GameObject.Find("Patlama-2");
         secim = Random.Range(1, 3);
    }
    public bool Kontrol = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            
            FindObjectOfType<AnaMekanik>().Kontrol = false;
            FindObjectOfType<AnaMekanik>().HedefDurumDeğis.SetActive(true);
            Instantiate(FindObjectOfType<AnaMekanik>().AnaPros);
            Destroy(GameObject.Find("PostSiyahBeyaz(Clone)"));
            Destroy(GameObject.Find("PostVolme(Clone)"));

            Debug.Log(secim);
            if (secim == 1)
            {
                
                PatlamaSesObjeleri[0].GetComponent<AudioSource>().PlayOneShot(PatlamaSesiClip[0]);
            }
            else if (secim == 2)
            {
                
                PatlamaSesObjeleri[1].GetComponent<AudioSource>().PlayOneShot(PatlamaSesiClip[1]);
            }

            Kontrol = true;
            Instantiate(CarpismaNoktasi, transform.position, transform.rotation);
            CarpismaNoktasi.position = transform.position;
            FindObjectOfType<AnaMekanik>().GetComponent<Camera>().enabled = true;
            Destroy(gameObject);
        }
        
        
        
        
    }
    
}
