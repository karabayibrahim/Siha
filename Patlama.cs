using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patlama : MonoBehaviour
{
    public GameObject PatlamaPar;
    float Force = 70.0f;
    float Radius = 7.0f;
    
    
    void Start()
    {
        if (FindObjectOfType<FüzeKendiYok>().Kontrol== true)
        {
            Transform Nok = FindObjectOfType<FüzeKendiYok>().CarpismaNoktasi;
            GameObject Yenipat = Instantiate(PatlamaPar, Nok.position, Nok.rotation);
            Destroy(Yenipat, 5f);
            Destroy(gameObject, 5f);
            Vector3 Pozisyon = transform.position;
            Collider[] Küre = Physics.OverlapSphere(Pozisyon, Radius);
            foreach (Collider CarpilanNesne in Küre)
            {

                if (CarpilanNesne.gameObject.CompareTag("Düsman"))
                {
                    CarpilanNesne.gameObject.GetComponent<Enmey>().DoRagdoll(true);
                    FindObjectOfType<LevelKontrol>().Düssay++;
                    Destroy(CarpilanNesne.gameObject.GetComponent<Enmey>().Ok);
                    
                }
                if (CarpilanNesne.gameObject.CompareTag("DüsmanKosan"))
                {
                    CarpilanNesne.gameObject.GetComponent<EnemyKosan>().DoRagdoll(true);
                    FindObjectOfType<LevelKontrol>().KosanDüssay++;


                }
                if (CarpilanNesne.gameObject.CompareTag("Bina"))
                {
                    CarpilanNesne.gameObject.GetComponent<BinaPatlama>().BinaPAT();

                }
                
                Rigidbody Rb = CarpilanNesne.GetComponent<Rigidbody>();
                if (Rb != null)
                {
                    Rb.AddExplosionForce(Force, transform.position, Radius);
                }
            }

        }

    }

    // Update is called once per frame
}
        
