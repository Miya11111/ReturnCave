using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class IntervalFunction : MonoBehaviour
{
    [Header("最初の間隔（秒）") ,SerializeField]
    private float startTime;
    [Header("実行間隔（秒）") ,SerializeField]
    private float intervalTime;
    [Header("実行する関数")]
    public UnityEvent Event;
    private float Timer;

    void Start(){
        Timer = intervalTime - startTime;
    }

    //時間になると指定した関数を実行
    void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if(Timer > intervalTime){
            Timer = 0;
            Event.Invoke();
        }

    }
}
