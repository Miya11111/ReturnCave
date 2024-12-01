using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private enum WITHIN_CAMERA{
        None,
        Overlap,
    }
    [Header("ターゲットのプレイヤー")]
    public Transform player; // プレイヤーのTransform

    [Header("カメラの移動制限範囲")]
    public Collider2D[] cameraBounds; // コライダー配列で制限範囲を指定

    private Camera cam;
    private float halfHeight;
    private float halfWidth;
    private bool withinCamera;

    private Vector3 prevPosition;

    void Start()
    {
        cam = GetComponent<Camera>();

        // カメラの半分のサイズを計算
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        // プレイヤーの現在位置を基準にカメラの目標位置を計算
        Vector3 targetPosition = player.position;

        // 現在のカメラ位置を計算
        Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);

        bool withinCamera = false;

        // 範囲チェック
        foreach (var bounds in cameraBounds)
        {
            //プレイヤーが存在するカメラ範囲を見つける
            if (!bounds.OverlapPoint(player.position)) continue;

            //カメラ範囲が2つあったらカメラをプレイヤーの位置に
            if(withinCamera == true){
                Debug.Log("A");
                newPosition.x = targetPosition.x;
                newPosition.y = targetPosition.y;
                break;
            }

            // カメラの中心位置を制限
            float minX = bounds.bounds.min.x + halfWidth;
            float maxX = bounds.bounds.max.x - halfWidth;
            float minY = bounds.bounds.min.y + halfHeight;
            float maxY = bounds.bounds.max.y - halfHeight;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            withinCamera = true;
        }
        Debug.Log(withinCamera);
        
        // カメラの位置を更新
        if (withinCamera == true){
            transform.position = newPosition;
            prevPosition = newPosition;
        }
        //範囲外だったらカメラを動かさない
        else{
            transform.position = prevPosition;
        }
    }
}
