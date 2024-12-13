using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Collider2D _collider;
    public bool rendered = false; //カメラに映っているか判定する変数
    public bool disableStamp = false;   //踏めるかどうか
    public bool ableRide = false;   //乗れるかどうか
    public bool isRotate = false;
    private float timer = 0;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void FixedUpdate(){
        //画面外に行ったときに時間差で停止
        if (!rendered){
            timer += Time.deltaTime;
            if(timer >= 5){
                if(_rb2d != null){
                _rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                timer = 0;
            }
        }
        else{
            if(_collider.enabled == true){
                if(isRotate){
                    if(_rb2d != null){
                    _rb2d.constraints = RigidbodyConstraints2D.None;
                    }
                }
                //回転する敵以外はz軸回転を停止
                else{
                    if(_rb2d != null){
                    _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                }
            }
        }
    }

    //敵が踏まれたときの処理
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "GroundCheck"){
            //踏める敵
            if(!disableStamp){
                transform.localScale = new Vector3(1f, 0.5f, 1);
                if(_rb2d != null){
                _rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                _collider.enabled = false;
                Destroy(gameObject,1f);
            }
            //踏めない敵
            else{
                //乗れる敵
                if(ableRide){
                    Transform player = collider.gameObject.transform.parent;
                    PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                    playerMovement.isDead = false;
                }
            }
        }

        //トロッコに当たったときの処理
        if(collider.gameObject.name == "trolley_collider"){
            transform.localScale = new Vector3(1f, 0.5f, 1);
            if(_rb2d != null){
            _rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            _collider.enabled = false;
            Destroy(gameObject,1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.name == "GroundCheck"){
            Transform player = collider.gameObject.transform.parent;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            playerMovement.isDead = true;
        }
    }

    //カメラに映っているときに呼ばれ続ける処理
    void OnWillRenderObject(){
        if(Camera.current.name == "Pixel Perfect Camera"){
            rendered = true;
        }
    }

    //常にrenderedを初期化
    private void LateUpdate(){
        rendered = false;
    }
}
