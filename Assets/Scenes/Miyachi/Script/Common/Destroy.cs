using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;  //消える時間

    //destroyTime秒後に消滅
    void Start()
    {
        Destroy(this.gameObject,destroyTime);
    }
}
