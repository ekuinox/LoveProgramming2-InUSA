using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Text.RegularExpressions;

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
    public int GetNextChipType(int x, int y)
    {
        Tile tile = tileMap.GetTile<Tile>(new Vector3Int(x, y, 0));
        string str = Regex.Replace(tile.sprite.name, @"[^0-9]", "");
        int type = int.Parse(str);

        return (int)GetChipType(type);
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
}
