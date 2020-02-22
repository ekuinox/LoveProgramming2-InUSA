using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField]
    private Texture[] textures;
    
    public void setTexture(int type)
    {
        GetComponent<RawImage>().texture = textures[type];
    }
}
