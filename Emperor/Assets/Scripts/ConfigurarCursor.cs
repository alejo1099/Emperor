using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurarCursor : MonoBehaviour
{
    public Texture2D texture;
    void Start()
    {
        Cursor.SetCursor(texture, Vector3.zero, CursorMode.Auto);
    }
}
