using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField]
    private float speed; 
    GameObject _player;
    Rigidbody2D _rbody; 
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _rbody = GetComponent<Rigidbody2D>();
        _rbody.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //プレイヤーの方向を調べる
        Vector3 dir = (_player.transform.position - this.transform.position).normalized;
        //その方向に進む
        float vx = dir.x * speed;
        float vy = dir.y * speed;
        _rbody.velocity = new Vector2(vx, vy);
        this.GetComponent<SpriteRenderer>().flipX = (vx > 0);
    }
}
