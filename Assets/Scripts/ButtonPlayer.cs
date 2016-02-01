using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPlayer : MonoBehaviour {

    public AudioClip clip;

    public string label;

    Text txt;

    void Awake()
    {
        txt = GetComponentInChildren<Text>();

        txt.text = label;
    }

    public void setClip(AudioClip clip, string label)
    {
        this.clip = clip;


        txt.text = this.label = label;

    }

	public void Play ()
    {
        Debug.Log("Another 1");

        Soundboard.instance.Play(clip);
	}
}
