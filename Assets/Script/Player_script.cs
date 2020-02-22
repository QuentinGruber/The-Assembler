using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_script : MonoBehaviour
{
    public Animator anim;
    int AmmoRemaining = 3 ;
    public int runSpeed = 10 ,JumpPower = 15 , TrampoJumpPower = 30;
    public bool IsGoingRight = false;
    private bool IsGoingLeft = false,OnGround = true,PlayerLookRight = true,CanClimb = false , isGoingUP = false;
    private float angle;
    public float ClimbSpeed = 10;
    public Rigidbody2D Player_rb;
    public Transform FirePoint,Arm_Bone,Gun_trans;
    public GameObject Repair_projectile,GameManager;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Arm_Orientation();
        CheckKeyDown();
        Player_Orientation();
        Movement();
    }

     void Movement(){

        if(IsGoingLeft){
            anim.SetBool("IsRunning", true);
            transform.Translate(((runSpeed/5)*Time.deltaTime)*-1,0,0);
        }
        else if(IsGoingRight){
            anim.SetBool("IsRunning", true);
            transform.Translate(((runSpeed/5)*Time.deltaTime)*1,0,0);            
        }
        else{
            anim.SetBool("IsRunning", false);
        }

        if(isGoingUP){
            transform.Translate(0,ClimbSpeed*Time.deltaTime,0);
        }
    }

    void CheckKeyDown(){


        if (Input.GetKeyDown(KeyCode.R)) // Restart
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Exit game
        {
            Application.Quit();
        }


        //check key for basic move
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A) )
        {
            if(IsGoingRight){
                IsGoingRight = false;
            }
            IsGoingLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(IsGoingLeft){
                IsGoingLeft = false;
            }
            IsGoingRight = true;
        }

        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.A) )
        {
            IsGoingLeft = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            IsGoingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&(OnGround)) // To avoid double jump and air jump
        {
           OnGround = false; 
            Player_rb.AddForce(new Vector2(0f, (JumpPower*10)));
        }

         if (Input.GetMouseButtonDown(0)) { // If Mouse left is pressed
            FireProjectile();
        }

        // Climb

        if (Input.GetKeyDown(KeyCode.Z) && CanClimb  || Input.GetKeyDown(KeyCode.W) && CanClimb)
        {
            isGoingUP = true;
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.W))
        {
            isGoingUP = false;
        }
        
    }




    void FireProjectile(){
        if (AmmoRemaining>0){
        Vector3 arm_pos = (FirePoint.position); // Player pos
        var mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Cursor pos
        angle = Mathf.Atan2(mouse_pos.y - Arm_Bone.position.y, mouse_pos.x - Arm_Bone.position.x) * Mathf.Rad2Deg; // Angle calculation
        Instantiate(Repair_projectile, arm_pos, Quaternion.Euler(new Vector3(0, 0, angle))); // Create the projectile
        AmmoRemaining--;
        GameManager.SendMessage("RemoveAmmo");
        }

    }   





    void Player_Orientation() // check if player has to face left or rigth
    {
        var player_x = transform.position.x;
        var cursor_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (PlayerLookRight) {
            if(player_x >= cursor_pos.x) {
                PlayerLookRight = false;
                Flip();
            }
        }
        else{
            if(player_x <= cursor_pos.x) {
                PlayerLookRight = true;
                Flip();
            }
        }
    }

    void Arm_Orientation(){
        var mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Cursor pos
        angle = Mathf.Atan2(mouse_pos.y - Arm_Bone.position.y, mouse_pos.x - Arm_Bone.position.x) * Mathf.Rad2Deg;
        Arm_Bone.eulerAngles = new Vector3 (0, 0, angle);
    }

     private void Flip() // flip player sprite
	{
            // Body
            Vector3 BodyScale = transform.localScale;
            BodyScale.x *= -1;
            transform.localScale = BodyScale;
            // Arm
            Vector3 ArmScale = Arm_Bone.localScale;
            ArmScale.x *= -1;
            ArmScale.y *= -1;
            Arm_Bone.localScale = ArmScale;

    }

    void OnTriggerEnter2D(Collider2D col) // if collid with ground OnGround = true
    {
        if (col.gameObject.tag == "Ground")
        {
            OnGround = true;
        }

        if (col.gameObject.tag == "Trampo")
        {
            OnGround = false;
            Player_rb.velocity = new Vector3(0, 0, 0);
            Player_rb.AddForce(new Vector2(0f, (TrampoJumpPower*10)));
        }

        if (col.gameObject.tag == "Tp")
        {
          GameManager.SendMessage("NextLVL");
        }

        if (col.gameObject.tag == "Ladder")
        {
            OnGround = false;
            Player_rb.velocity = new Vector3(0, 0, 0);
            CanClimb = true;
        }
        

    }
    void OnTriggerExit2D(Collider2D col) // if collid with ground OnGround = true
    {
        if (col.gameObject.tag == "Ground")
        {
            OnGround = false;
        }
         if (col.gameObject.tag == "Ladder")
        {
            //OnGround = true;
            CanClimb = false;
        }
    }
}
