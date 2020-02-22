using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Text.RegularExpressions;
using System.Text;

/*------------------------------------------
 * EChipType  : チップのタイプ
 -------------------------------------------*/
public enum EChipType
{
    eNone,
    eWall,
    eBed,
    eTissue,
    eSofa,
    eChair,
    eTable,
    eTrashCan,
    eShelf,
    eLightStand,
    eNewspaper,
    eFoliagePlant,
    eCalendar,
    eClock,
    eHangar,
    eWindow,
    eRefrigerator,
    eKitchen,
    eToilet,
    eBath,
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
        OutPutSpriteType();
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
            // ベッド
            case 0:
            case 1:
            case 2:
            case 8:
            case 9:
            case 10:
            case 16:
            case 17:
            case 24:
            case 25:
                return EChipType.eBed;

            // ティッシュ
            case 15:
                return EChipType.eTissue;
            
            // ソファー
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 26:
            case 27:
            case 28:
            case 29:
            case 30:
                return EChipType.eSofa;
            
            // 椅子
            case 23:
            case 31:
            case 38:
            case 39:
            case 47:
                return EChipType.eChair;

            // テーブル
            case 32:
            case 33:
            case 34:
            case 35:
            case 36:
            case 37:
            case 40:
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 48:
            case 49:
            case 50:
            case 60:
            case 61:
            case 62:
            case 68:
            case 69:
            case 70:
            case 86:
                return EChipType.eTable;

            // ごみ箱
            case 56:
                return EChipType.eTrashCan;

            // 棚
            case 57:
            case 58:
            case 59:
            case 65:
            case 66:
            case 73:
            case 74:
                return EChipType.eShelf;

            // 電気スタンド
            case 63:
            case 71:
                return EChipType.eLightStand;

            // 新聞
            case 64:
                return EChipType.eNewspaper;

            // 観葉植物
            case 67:
            case 75:
                return EChipType.eFoliagePlant;

            // カレンダー
            case 72:
                return EChipType.eCalendar;

            // 時計
            case 76:
                return EChipType.eClock;

            // ハンガー
            case 77:
                return EChipType.eHangar;

            // 窓
            case 78:
            case 79:
                return EChipType.eWindow;

            // 冷蔵庫
            case 80:
            case 88:
                return EChipType.eRefrigerator;

            // キッチン
            case 81:
            case 82:
            case 83:
            case 84:
            case 89:
            case 90:
            case 91:
            case 92:
                return EChipType.eKitchen;

            // トイレ
            case 85:
            case 87:
            case 93:
            case 94:
                return EChipType.eToilet;

            // 風呂
            case 116:
            case 117:
            case 118:
            case 119:
            case 124:
            case 125:
            case 126:
            case 127:
                return EChipType.eBath;

            // 壁(イベントなし)
            case 3:
            case 95:
                return EChipType.eWall;

            default:
                return EChipType.eNone;
        }
    }


    private void OutPutSpriteType()
    {
        // 使われているSpriteをリストアップ
        var bound = tileMap.cellBounds;
        var spriteList = new List<Sprite>();
        for (int y = bound.max.y - 1; y >= bound.min.y; --y)
        {
            for (int x = bound.min.x; x < bound.max.x; ++x)
            {
                var tile = tileMap.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (tile != null && !spriteList.Contains(tile.sprite))
                {
                    spriteList.Add(tile.sprite);
                }
            }
        }

        // どの場所でそのSpriteが使われているかを出力
        var builder = new StringBuilder();
        for (int y = bound.max.y - 1; y >= bound.min.y; --y)
        {
            for (int x = bound.min.x; x < bound.max.x; ++x)
            {
                var tile = tileMap.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (tile == null)
                {
                    builder.Append("_,");
                }
                else
                {
                    //var index = spriteList.IndexOf(tile.sprite);
                    string str = Regex.Replace(tile.sprite.name, @"[^0-9]", "");
                    int index = int.Parse(str);
                    builder.Append(index + ",");
                }
            }
            builder.Append("\n");
        }
        Debug.Log(builder.ToString());
    }

}
