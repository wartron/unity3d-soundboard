using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPlayer : MonoBehaviour {

    public AudioClip clip;

    public string label;


    void Awake()
    {
        Text txt = GetComponentInChildren<Text>();

        txt.text = label;
    }


	public void Play ()
    {
        Debug.Log("Another 1");

        Soundboard.instance.Play(clip);
	}
}
