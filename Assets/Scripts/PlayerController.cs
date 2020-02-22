﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Field field;
    //[SerializeField] private Tilemap tilemap; 

    private float offsetX = 0.5f, offsetY = 0.5f;
    private int moveX = 0, moveY = 0;


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

            if (field.GetNextChipType(moveX, moveY - 1) == EChipType.eNone)
            {
                moveY--;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (Input.GetButtonDown("Up Arrow"))
        {
            Debug.Log("上");
            if (field.GetNextChipType(moveX, moveY + 1) == EChipType.eNone)
            {
                moveY++;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (Input.GetButtonDown("Left Arrow"))
        {
            Debug.Log("左");
            if (field.GetNextChipType(moveX - 1, moveY) == EChipType.eNone)
            {
                moveX--;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (Input.GetButtonDown("Right Arrow"))
        {
            Debug.Log("右");
            if (field.GetNextChipType(moveX + 1, moveY) == EChipType.eNone)
            {
                moveX++;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }

        // プレイヤーの位置を更新
        this.gameObject.transform.position = new Vector3(offsetX + moveX, offsetY + moveY, 0);
    }
}
