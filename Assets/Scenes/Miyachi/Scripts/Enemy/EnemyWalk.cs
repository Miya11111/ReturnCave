using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class EnemyWalk : MonoBehaviour
{
    [Header("歩く速さ") , SerializeField]
    private Vector2 _horizontalMoveForce = new Vector2(11.0f, 2f);   //この値は丁度ブロックで反転する・坂を登れる・坂から落ちるとき過度に弾まない値

    [Header("通常移動時の限界速度"), SerializeField]
    private Vector2 _movementLimitVelocity = new Vector2(5.0f, 20.0f);
    
    private Rigidbody2D _rb2d ;
    private bool moveRight = true;
    private bool enableFlip = true;
    private bool isGrounded = true;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        if(_horizontalMoveForce.x >= 0){
            moveRight = true;
        }
        else{
            moveRight = false;
        }
    }

    //左右に動く
    void FixedUpdate()
    {
            _rb2d.AddForce(_horizontalMoveForce);
        
        // 進行方向にプレイヤーか他の敵以外があって止まった際に反転
        Vector2 checkPoint = (Vector2)transform.position + Vector2.right * (moveRight ? 0.1f : -0.1f) + Vector2.down;
        Collider2D hit = Physics2D.OverlapPoint(checkPoint);
        if(hit != null && hit.tag != "Player" && _rb2d.velocity.x == 0 && enableFlip == true){
                Debug.Log(hit);
                Flip();
                enableFlip = false;
                Invoke(nameof(waitFlip), 1f);
                Debug.Log("BlockFlip");
        }

        // 移動速度が既定値を超えている場合
        if (Mathf.Abs(_rb2d.velocity.x) >= _movementLimitVelocity.x)
        {
            // 移動速度を規定値に直す
            _rb2d.velocity = new Vector2(_movementLimitVelocity.x, _rb2d.velocity.y);
        }
    }

    //接地しているときfalse
    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        //敵にぶつかったら反転
        if(collision.gameObject.tag == "Enemy" && enableFlip == true){
            Flip();
            enableFlip = false;
            Invoke(nameof(waitFlip), 1f);
            Debug.Log("EnemyFlip : enableFlip = " + enableFlip);
        }
    }

    //空中にいるときtrue
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    //反転処理
    void waitFlip(){
        enableFlip = true;
    }

    //オブジェクトの向きを反転
    void Flip(){
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        _horizontalMoveForce.x = -_horizontalMoveForce.x;
        _movementLimitVelocity.x = -_movementLimitVelocity.x;
        moveRight = !moveRight;
    }
}
