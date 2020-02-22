using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sol_casser_scripto : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Repair(){
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.tag = "Ground";
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

    }
}
