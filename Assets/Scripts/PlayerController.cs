using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

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
            this.gameObject.transform.position += new Vector3(0, -1, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (Input.GetButtonDown("Up Arrow"))
        {
            Debug.Log("上");
            this.gameObject.transform.position += new Vector3(0, 1, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (Input.GetButtonDown("Left Arrow"))
        {
            Debug.Log("左");
            this.gameObject.transform.position += new Vector3(-1, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (Input.GetButtonDown("Right Arrow"))
        {
            Debug.Log("右");
            this.gameObject.transform.position += new Vector3(1, 0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
    }
}
