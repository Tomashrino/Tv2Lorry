using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUp : MonoBehaviour
{
    public bool autoHide = false;

    private Text popupText;
    //private Animator anim;

    private float hideDelay = 3f;

    void Start()
    {
        popupText = GetComponentInChildren<Text>();
        //anim = GetComponent<Animator>();
    }

    public void ShowPopUp(string msg)
    {
        popupText.text = msg;
        //anim.SetTrigger("ShowPopUp");
        if (autoHide)
            StartCoroutine(DelayHide());
    }

    private IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(hideDelay);
        //anim.SetTrigger("HidePopUp");
    }
}
