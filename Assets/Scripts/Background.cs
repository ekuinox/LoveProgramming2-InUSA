using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public enum TextureType
    {
        Normal = 0
    }

    [SerializeField]
    private Texture[] textures;
    
    public void setTexture(TextureType type)
    {
        GetComponent<RawImage>().texture = textures[(int)type];
    }
}
