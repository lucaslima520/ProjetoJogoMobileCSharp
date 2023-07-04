using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    
    public float speed;
    public Rigidbody2D rig;
    

    
    // Start is called before the first frame update
    void Start()
    {
      
      speed = 2;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rig.MovePosition(transform.position + Vector3.down * speed * Time.deltaTime);
    }
}
