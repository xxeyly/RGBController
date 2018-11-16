using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MousePointerManager : MonoBehaviour
{
    #region 单例

    private static MousePointerManager _instance;

    public static MousePointerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MousePointerManager>();
            }

            return _instance;
        }
    }

    #endregion

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    [Header("鼠标选中样式")] [SerializeField] private Texture2D mouseSelectTexture;

    public void ChangeMouseStyleToSelect()
    {
        //更换鼠标的样式
        Cursor.SetCursor(this.mouseSelectTexture, Vector2.zero, CursorMode.Auto);
    }

    public void RecoveryMouseDefaultStyle()
    {
        //恢复回鼠标的样式
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}