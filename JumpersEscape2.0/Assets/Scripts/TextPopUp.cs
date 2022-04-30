using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{
    public Text referencetotext;

    void OnTriggerEnter(Collider hit)
    {
        referencetotext.text = "Choose A Path";
    }

    void OnTriggerExit(Collider hit)
    {
        referencetotext.text = "";
    }

}
