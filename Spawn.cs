using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public float spawnTime;
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreLayerCollision(3,9);
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        Physics2D.IgnoreLayerCollision(3,9);

        if(timeCount >= spawnTime){
            
            GameObject zombies = Instantiate(prefab, transform.position, transform.rotation);
            Destroy(zombies, 13f);
            timeCount = 0f;

        }
        
    }
}
