using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair_projectile : MonoBehaviour
{
    GameObject player;
    public int Bullet_Speed = 10;
    public float Volume_effect = 1f;
    private AudioSource OdioSource;
    public AudioClip Fire,Shot_miss,Shot_succeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        player.GetComponent<AudioSource>().PlayOneShot(Fire, Volume_effect);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Bullet_Speed / 10 ) * Time.deltaTime,0,0);
    }

    void OnTriggerEnter2D(Collider2D col) // if collid with ground OnGround = true
    {
        if (col.gameObject.tag == "Repairable_Object")
        {
              player.GetComponent<AudioSource>().PlayOneShot(Shot_succeed, Volume_effect);
            // exécute la fonction réparer chez l'objet
            col.SendMessage("Repair");

        }
        if (col.gameObject.tag != "Player" && col.gameObject.tag != "GroundDetector")
        {
             player.GetComponent<AudioSource>().PlayOneShot(Shot_miss, Volume_effect);
            Destroy(gameObject);
        }
    }
}
