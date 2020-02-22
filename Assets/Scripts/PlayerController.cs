using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerDirection
{
    eLeft,
    eRight,
    eUp,
    eDown
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Field field;

    private float offsetX = 0.5f, offsetY = 0.5f;
    private int moveX = 0, moveY = 0;
    private EPlayerDirection direction;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの左右上下移動、画像の切り替え
        if (Input.GetButtonDown("Down Arrow"))
        {
            Debug.Log("下");
            direction = EPlayerDirection.eDown;

            if (field.GetNextChipType(moveX, moveY, direction) == EChipType.eNone)
            {
                moveY--;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (Input.GetButtonDown("Up Arrow"))
        {
            Debug.Log("上");
            direction = EPlayerDirection.eUp;

            if (field.GetNextChipType(moveX, moveY, direction) == EChipType.eNone)
            {
                moveY++;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (Input.GetButtonDown("Left Arrow"))
        {
            Debug.Log("左");
            direction = EPlayerDirection.eLeft;

            if (field.GetNextChipType(moveX, moveY, direction) == EChipType.eNone)
            {
                moveX--;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (Input.GetButtonDown("Right Arrow"))
        {
            Debug.Log("右");
            direction = EPlayerDirection.eRight;

            if (field.GetNextChipType(moveX, moveY, direction) == EChipType.eNone)
            {
                moveX++;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }

        // プレイヤーの位置を更新
        this.gameObject.transform.position = new Vector3(offsetX + moveX, offsetY + moveY, 0);


        // アクションを行う
        if (Input.GetButtonDown("Action") && field.GetNextChipType(moveX, moveY, direction) != EChipType.eNone)
        {
            Debug.Log("アクションをする");

            // 行うイベントのIDを設定
            if (SetTextID())
            {
                SceneController.LoadScene(ESceneState.eGalGame);
            }
        }
    }

    private bool SetTextID()
    {
        EChipType type = field.GetNextChipType(moveX, moveY, direction);

        switch (type)
        {
            case EChipType.eTissue:
                MessageText.textId = 1;
                return true;

            default:
                return false;
        }
    }
}
