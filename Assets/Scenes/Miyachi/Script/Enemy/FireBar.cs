using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBar : MonoBehaviour
{
    [SerializeField]
    private GameObject fire;

    public void yieldFire(){
        //炎を出す向きを変更
        Vector2 firePos = this.transform.position;
        float rotationZ = this.transform.rotation.eulerAngles.z;
        switch(rotationZ){
            case 90:
                firePos.x -= 1.8f;
                break;
            case 180:
                firePos.y -= 1.8f;
                break;
            case -90:
                firePos.x += 1.8f;
                break;
            default:
                firePos.y += 1.8f;
                break;
        }
        GameObject fireObj = Instantiate(fire,firePos, Quaternion.Euler(0 ,0, rotationZ));
        Collider2D fireCol = fireObj.GetComponent<BoxCollider2D>();
        fireCol.enabled = false;
    }
}
