using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_trig : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D col) // if collid with ground OnGround = true
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "GroundDetector")
        {
    SceneManager.LoadScene(1);
        }
    }
}
