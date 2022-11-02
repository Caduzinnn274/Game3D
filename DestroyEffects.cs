using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffects : MonoBehaviour
{

    public float tempo = 0;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,tempo);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
