using UnityEngine;
using System.Collections;

public class DisPlayView : MonoBehaviour
{

    private GameObject window;

    void Start()
    {
        window = transform.FindChild("Window").gameObject;
    }
    public void ShowOrHideView(bool display)
    {
        window.SetActive(display);
    }
}
