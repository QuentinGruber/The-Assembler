using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Presentation_script : MonoBehaviour
{
    public GameObject Step1,Step2,Step3;
    int step = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       if (Input.GetKeyDown(KeyCode.Space)){
           if(step == 1){
               Step1.SetActive(false);
               Step2.SetActive(true);
               
           }
           if(step == 2){
               Step2.SetActive(false);
               Step3.SetActive(true);
           }
            if(step == 3){
                SceneManager.LoadScene(1);
            }
           step += 1 ;

       }
        
    }
}
