using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ExplosionForce>().doExplosion(this.transform.position);    
    }

    
}
