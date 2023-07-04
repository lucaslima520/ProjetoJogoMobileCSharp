using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class Player1 : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public Vector3 facingleft;
    public Vector3 facingright;
    public int healthPalyer;
    // Start is called before the first frame update
    void Start()
    {
        facingleft = transform.localScale;
        facingleft.x = facingleft.x * -1;
        facingright = transform.localScale;
        healthPalyer = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        
        anim.SetFloat("Horizontal",movement.x);
        anim.SetFloat("Vertical",movement.y);
        anim.SetFloat("Speed",movement.magnitude);



        if(movement.x == 0.0f){
            movement.x = CrossPlatformInputManager.GetAxis("Horizontal");
            anim.SetFloat("Horizontal",movement.x);
            anim.SetFloat("Vertical",movement.y);
            anim.SetFloat("Speed",movement.magnitude);
        }

        if(movement.y == 0.0f){
            movement.y = CrossPlatformInputManager.GetAxis("Vertical");
            anim.SetFloat("Horizontal",movement.x);
            anim.SetFloat("Vertical",movement.y);
            anim.SetFloat("Speed",movement.magnitude);
        }

        if(movement.x > 0){
            transform.localScale = facingleft;
        }
        if(movement.x < 0){
            transform.localScale = facingright;
        }

        transform.position = transform.position + movement * speed * Time.deltaTime;

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {   

        if(healthPalyer > 0 && col.gameObject.CompareTag("Zombie")){
            healthPalyer -= 1;
            Destroy(col.gameObject);
            
        }
        if(healthPalyer == 0){
        SceneManager.LoadScene(1);
        //Debug.Log("OnCollisionEnter2D");
        }
         
        

    }
}
