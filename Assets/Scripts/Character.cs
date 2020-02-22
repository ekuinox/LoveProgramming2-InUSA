﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public enum TextureType
    {
        None = 0
    }

    [SerializeField]
    private Texture[] textures;

    public void setTexture(TextureType type)
    {
        if (type == TextureType.None)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        GetComponent<RawImage>().texture = textures[(int)type];
    }
}
