using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Text;
using System.Text.RegularExpressions;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Field field;
    //[SerializeField] private Tilemap tilemap; 

    private float moveX = 0, moveY = 0;


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
            //this.gameObject.transform.position += new Vector3(0, -1, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (Input.GetButtonDown("Up Arrow"))
        {
            Debug.Log("上");
            //this.gameObject.transform.position += new Vector3(0, 1, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (Input.GetButtonDown("Left Arrow"))
        {
            Debug.Log("左");
            //this.gameObject.transform.position += new Vector3(-1, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (Input.GetButtonDown("Right Arrow"))
        {
            Debug.Log("右");
            //this.gameObject.transform.position += new Vector3(1, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }

        //OutPutSpriteType();
    }

    //private void OutPutSpriteType()
    //{
    //    // 使われているSpriteをリストアップ
    //    var bound = tilemap.cellBounds;
    //    var spriteList = new List<Sprite>();
    //    for (int y = bound.max.y - 1; y >= bound.min.y; --y)
    //    {
    //        for (int x = bound.min.x; x < bound.max.x; ++x)
    //        {
    //            var tile = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0));
    //            if (tile != null && !spriteList.Contains(tile.sprite))
    //            {
    //                spriteList.Add(tile.sprite);
    //            }
    //        }
    //    }
    //    // どの場所でそのSpriteが使われているかを出力
    //    var builder = new StringBuilder();
    //    for (int y = bound.max.y - 1; y >= bound.min.y; --y)
    //    {
    //        for (int x = bound.min.x; x < bound.max.x; ++x)
    //        {
    //            var tile = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0));
    //            if (tile == null)
    //            {
    //                builder.Append("_,");
    //            }
    //            else
    //            {
    //                //var index = spriteList.IndexOf(tile.sprite);
    //                string str = Regex.Replace(tile.sprite.name, @"[^0-9]", "");
    //                int index = int.Parse(str);
    //                builder.Append(index + ",");
    //            }
    //        }
    //        builder.Append("\n");
    //    }
    //    Debug.Log(builder.ToString());
    //}
}
