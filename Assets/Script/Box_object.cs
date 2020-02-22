using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_object : MonoBehaviour
{
    public Sprite objet_repare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Repair(){
        gameObject.GetComponent<SpriteRenderer>().sprite = objet_repare;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.tag = "Ground";

    }

}
