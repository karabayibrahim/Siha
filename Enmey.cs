using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    public Collider MainCollider;
    public Collider[] AllCollider;
    public GameObject Ok;
    

    private void Awake()
    {
        MainCollider = GetComponent<Collider>();
        AllCollider = GetComponentsInChildren<Collider>(true);
        DoRagdoll(false);
        

    }
    private void Update()
    {
        //Ok.transform.LookAt(Main.transform);
    }

    public void DoRagdoll(bool isRagdoll)
    {
        foreach (var col in AllCollider)
        {
            col.enabled = isRagdoll;
            MainCollider.enabled = !isRagdoll;
            GetComponent<Rigidbody>().useGravity = !isRagdoll;
            GetComponent<Animator>().enabled = !isRagdoll;
        }
    }
}
