using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float TimeLeft ,starttime;
    public GameObject Part1,Part2,Part3,PartEND;
    int AmmoRemaining = 3 , CurrentLVL = 1;
    public SpriteRenderer Icon1,Icon2,Icon3;
    public Sprite IconVide,IconPlein;
    public Text TimeUI;
    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(AmmoRemaining == 3 ){
            Icon1.sprite =IconPlein;
            Icon2.sprite =IconPlein;
            Icon3.sprite =IconPlein;
        }
         if(AmmoRemaining < 3 ){
             Icon1.sprite = IconVide;

        }
        if(AmmoRemaining < 2){
             Icon2.sprite = IconVide;
        }
        if(AmmoRemaining < 1){
             Icon3.sprite = IconVide;
        }

        TimeLeft = 20 + (starttime - Time.time);
        if(TimeLeft < 0 ) SceneManager.LoadScene(1);
        TimeUI.text =  (int)TimeLeft+"";
        
    }
    
    public void RemoveAmmo(){
             AmmoRemaining--;
    }

    public void NextLVL(){
        CurrentLVL++;
        AmmoRemaining = 3;
        if (CurrentLVL == 2){
            Part1.SetActive(false);
            Part2.SetActive(true);
            Part3.SetActive(false);
        }
        if (CurrentLVL == 4){
            Part1.SetActive(false);
            Part2.SetActive(false);
            Part3.SetActive(true);
        }
        if (CurrentLVL == 7){
            SceneManager.LoadScene(2);
        }


    }
}
