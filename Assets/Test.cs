using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public InputField addItemInputField;

    public void AddItem()
    {
        if (addItemInputField.text != "")
        {
            FindObjectOfType<Backpack>().AddItem(int.Parse(addItemInputField.text));
        }
    }
}