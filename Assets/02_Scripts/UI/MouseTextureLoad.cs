using System.Collections.Generic;
using UnityEngine;

public partial class Mouse : MonoBehaviour
{
    public enum MouseType { Default = 0, Cat = 1, Triangle = 2, TriangleSmall = 3 }
    public MouseType Type
    {
        get { return Type_; }
        private set { Type_ = value; }
    }

    public enum MouseState { Drag = 0, Normal = 1, Pointing = 2 }
    public MouseState State
    {
        get { return State_; }
        private set { State_ = value; }
    }

    public enum MouseAlpha { Zero = 0, Half = 1, Full = 2 }
    public MouseAlpha Alpha
    {
        get { return Alpha_; }
        private set { Alpha_ = value; }
    }

    public Texture2D[] Default;
    public Texture2D[] Cat;
    public Texture2D[] Triangle;
    public Texture2D[] TriangleSmall;

    public List<Texture2D> ReSizeDefault = new();
    public List<Texture2D> ReSizeCat = new();
    public List<Texture2D> ReSizeTriangle = new();
    public List<Texture2D> ReSizeTriangleSmall = new();

    public List<Texture2D> ReSizeHalfDefault = new();
    public List<Texture2D> ReSizeHalfCat = new();
    public List<Texture2D> ReSizeHalfTriangle = new();
    public List<Texture2D> ReSizeHalfTriangleSmall = new();

    private void LoadTextureAll()
    {
        Default = LoadTextures("Mouse sprites/Default");
        Cat = LoadTextures("Mouse sprites/Cat");
        Triangle = LoadTextures("Mouse sprites/Triangle");
        TriangleSmall = LoadTextures("Mouse sprites/TriangleSmall");
    }

    private Texture2D[] LoadTextures(string path)
    {
        Texture2D[] textures = Resources.LoadAll<Texture2D>(path);
        return textures;
    }

    private void UpdateResizeTexture2D()
    {
        ReSizeDefault.Clear();
        ReSizeCat.Clear();
        ReSizeTriangle.Clear();
        ReSizeTriangleSmall.Clear();

        ReSizeHalfDefault.Clear();
        ReSizeHalfCat.Clear();
        ReSizeHalfTriangle.Clear();
        ReSizeHalfTriangleSmall.Clear();

        for (int i = 0; i < Default.Length; i++)
        {
            ReSizeDefault.Add(ResizeTexture(Default[i], MouseSize, MouseSize));
            ReSizeHalfDefault.Add(ChangeTextureColor(ReSizeDefault[i], new Color(1, 1, 1, GetAlpha(MouseAlpha.Half))));
        }

        for (int i = 0; i < Cat.Length; i++)
        {
            ReSizeCat.Add(ResizeTexture(Cat[i], MouseSize, MouseSize));
            ReSizeHalfCat.Add(ChangeTextureColor(ReSizeCat[i], new Color(1, 1, 1, GetAlpha(MouseAlpha.Half))));
        }

        for (int i = 0; i < Triangle.Length; i++)
        {
            ReSizeTriangle.Add(ResizeTexture(Triangle[i], MouseSize, MouseSize));
            ReSizeHalfTriangle.Add(ChangeTextureColor(ReSizeTriangle[i], new Color(1, 1, 1, GetAlpha(MouseAlpha.Half))));
        }

        for (int i = 0; i < TriangleSmall.Length; i++)
        {
            ReSizeTriangleSmall.Add(ResizeTexture(TriangleSmall[i], MouseSize, MouseSize));
            ReSizeHalfTriangleSmall.Add(ChangeTextureColor(ReSizeTriangleSmall[i], new Color(1, 1, 1, GetAlpha(MouseAlpha.Half))));
        }
    }

    private void SetMouseCursor(Texture2D[] textures, Vector2 pivot)
    {
        Texture2D texture = textures[(int)State];
        Cursor.SetCursor(texture, pivot, CursorMode.Auto);
    }

    private Texture2D ResizeTexture(Texture2D originalTexture, int width, int height)
    {
        Texture2D resizedTexture = new Texture2D(width, height, originalTexture.format, false);
        Color[] pixels = originalTexture.GetPixels(0, 0, originalTexture.width, originalTexture.height);
        Color[] resizedPixels = new Color[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float u = x / (float)width;
                float v = y / (float)height;
                resizedPixels[y * width + x] = originalTexture.GetPixelBilinear(u, v);
            }
        }

        resizedTexture.SetPixels(resizedPixels);
        resizedTexture.Apply();
        return resizedTexture;
    }

    private Texture2D ChangeTextureColor(Texture2D originalTexture, Color color)
    {
        Texture2D coloredTexture = new Texture2D(originalTexture.width, originalTexture.height, originalTexture.format, false);
        Color[] pixels = originalTexture.GetPixels();

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color * pixels[i];
        }

        coloredTexture.SetPixels(pixels);
        coloredTexture.Apply();
        return coloredTexture;
    }




}