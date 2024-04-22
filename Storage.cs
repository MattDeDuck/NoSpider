using System;
using System.IO;
using UnityEngine;

namespace NoSpider
{
    class Storage
    {
        public static Texture2D flyWebTex;
        public static Sprite flyWebSprite;

        public static Texture2D LoadTextureFromFile(string filePath)
        {
            var data = File.ReadAllBytes(filePath);

            var tex = new Texture2D(0, 0, TextureFormat.ARGB32, false, false)
            {
                filterMode = FilterMode.Bilinear,
            };

            if (!tex.LoadImage(data))
            {
                throw new Exception($"Failed to load image from file at \"{filePath}\".");
            }

            return tex;
        }
    }
}
