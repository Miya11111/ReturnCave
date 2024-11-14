using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCommon : MonoBehaviour
{
    private Rigidbody2D _rb2d ;
    private Collider2D _collider;
    // Start is called before the first frame update
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    //敵が踏まれたときの処理
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "GroundCheck"){
            transform.localScale = new Vector3(1f, 0.5f, 1);
            _rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            _collider.enabled = false;
            Destroy(gameObject,1f);
        }
    }
}
