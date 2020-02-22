using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampo_scripto : MonoBehaviour
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
        gameObject.tag = "Trampo";
    }
}
