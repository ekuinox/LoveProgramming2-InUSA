using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Text.RegularExpressions;
using System.Text;

public enum EChipType
{
    eNone,
    eWall,
}

public class Field : MonoBehaviour
{
    private Tilemap tileMap;


    // Start is called before the first frame update
    void Start()
    {
        tileMap = this.gameObject.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*------------------------------------------
     * GetNextChipType  : 次のチップのタイプを取得
     * x,y              : 次に移動する座標値
     * 戻り値           : 次のチップのタイプ
     -------------------------------------------*/
    public EChipType GetNextChipType(int x, int y)
    {
        int type;
        Tile tile = tileMap.GetTile<Tile>(new Vector3Int(x, y, 0));

        OutPutSpriteType(-1, 0);

        if (tile != null)
        {
            string str = Regex.Replace(tile.sprite.name, @"[^0-9]", "");
            type = int.Parse(str);
        }
        else
        {
            return EChipType.eNone;
        }

        return GetChipType(type);
    }


    /*------------------------------------------
     * GetChipType  : チップのタイプを取得
     * type         : チップの種類
     * 戻り値       : チップのタイプ
     -------------------------------------------*/
    private EChipType GetChipType(int type)
    {
        switch(type)
        {
            // 壁(イベントなし)
            case 3:
                return EChipType.eWall;

            default:
                return EChipType.eNone;
        }
    }


    private void OutPutSpriteType(int x, int y)
    {
        // 使われているSpriteをリストアップ
        var bound = tileMap.cellBounds;
        var spriteList = new List<Sprite>();
        //for (int y = bound.max.y - 1; y >= bound.min.y; --y)
        //{
        //    for (int x = bound.min.x; x < bound.max.x; ++x)
        //    {
        //        var tile = tileMap.GetTile<Tile>(new Vector3Int(x, y, 0));
        //        if (tile != null && !spriteList.Contains(tile.sprite))
        //        {
        //            spriteList.Add(tile.sprite);
        //        }
        //    }
        //}

        var tile = tileMap.GetTile<Tile>(new Vector3Int(x, y, 0));
        if (tile != null && !spriteList.Contains(tile.sprite))
        {
            spriteList.Add(tile.sprite);
        }

        // どの場所でそのSpriteが使われているかを出力
        var builder = new StringBuilder();
        //for (int y = bound.max.y - 1; y >= bound.min.y; --y)
        //{
        //    for (int x = bound.min.x; x < bound.max.x; ++x)
        //    {
        //        var tile = tileMap.GetTile<Tile>(new Vector3Int(x, y, 0));
        //        if (tile == null)
        //        {
        //            builder.Append("_,");
        //        }
        //        else
        //        {
        //            //var index = spriteList.IndexOf(tile.sprite);
        //            string str = Regex.Replace(tile.sprite.name, @"[^0-9]", "");
        //            int index = int.Parse(str);
        //            builder.Append(index + ",");
        //        }
        //    }
        //    builder.Append("\n");
        //}

        var tile2 = tileMap.GetTile<Tile>(new Vector3Int(x, y, 0));
        if (tile2 == null)
        {
            builder.Append("_,");
        }
        else
        {
            //var index = spriteList.IndexOf(tile.sprite);
            string str = Regex.Replace(tile2.sprite.name, @"[^0-9]", "");
            int index = int.Parse(str);
            builder.Append(index + ",");
        }

        Debug.Log(builder.ToString());
    }

}
