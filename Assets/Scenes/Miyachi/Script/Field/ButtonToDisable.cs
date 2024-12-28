using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToDisable : MonoBehaviour
{
     [Header("非活性化するスクリプト"), SerializeField]
    private MonoBehaviour disableObjectType;

    [Header("押されたボタンスプライト"), SerializeField]
    private Sprite pushedButton;
    
    [SerializeField]
    private AudioSource audioSource;
    private SpriteRenderer buttonSprite;

    void Start (){
        buttonSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    
    //踏んだら実行
    private void OnTriggerEnter2D(Collider2D collider){

        if(collider.gameObject.name == "GroundCheck"){
            audioSource.Play();
            //スプライト変更
            buttonSprite.sprite = pushedButton;

            //指定する型に一致するオブジェクトを探す
            System.Type scriptType = disableObjectType.GetType();
            MonoBehaviour[] allObjects = FindObjectsOfType(scriptType) as MonoBehaviour[];

            // 対象スクリプトを非活性化
            foreach (MonoBehaviour target in allObjects)
            {
                target.enabled = false;
            }
        }
    }
}
