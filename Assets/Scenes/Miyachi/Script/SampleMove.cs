using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMove : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            this.transform.Translate(moveSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            this.transform.Translate(-moveSpeed,0,0);
        }
        if(Input.GetKey(KeyCode.Space)){
            this.transform.rotation = Quaternion.Euler(0,0,20);
            this.transform.Translate(0,moveSpeed,0);
        }
    }
}
