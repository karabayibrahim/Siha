using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaPatlama : MonoBehaviour
{
   // public MeshRenderer Mr;
   //public  MeshRenderer Cmr;
    public GameObject Yikinti;
    void Start()
    {
        // Mr = GetComponent<MeshRenderer>();
        //Cmr= Yikinti.GetComponent<MeshRenderer>();
        // Cmr.enabled = false;
        
        
        
        //Mr.enabled = true;
    }
    public void BinaPAT()
    {
        Instantiate(Yikinti, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
