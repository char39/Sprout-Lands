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


}