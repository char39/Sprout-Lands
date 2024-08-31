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

    public Texture2D[] Default;
    public Texture2D[] Cat;
    public Texture2D[] Triangle;
    public Texture2D[] TriangleSmall;

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

    private void SetMouse()
    {
        switch (Type)
        {
            case MouseType.Default:
                SetMouseSprite(Default, new Vector2(0.25f, 0.875f));
                break;
            case MouseType.Cat:
                SetMouseSprite(Cat, new Vector2(0.3125f, 0.75f));
                break;
            case MouseType.Triangle:
                SetMouseSprite(Triangle, new Vector2(0.1875f, 0.8125f));
                break;
            case MouseType.TriangleSmall:
                SetMouseSprite(TriangleSmall, new Vector2(0.125f, 0.875f));
                break;
        }
    }
    private void SetMouseSprite(Texture2D[] textures, Vector2 pivot)
    {
        Texture2D texture = textures[(int)State];
        sprite.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot, 16);
    }
}