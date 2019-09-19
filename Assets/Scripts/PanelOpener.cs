using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public float SecondsToClosePanel = 3f;
    public void OpenPanel()
    {
        if(Panel != null)
        {
            Panel.SetActive(true);
            StartCoroutine(ClosePanel());
        }
    }

	IEnumerator ClosePanel()
	{
		yield return new WaitForSeconds(SecondsToClosePanel);
		Panel.SetActive(false);
	}

}
