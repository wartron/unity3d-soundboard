using UnityEngine;
using System.Collections;

public class Soundboard : MonoBehaviour {


    public static Soundboard instance;

    private AudioSource _audio;

	void Start () {
        instance = this;
	}

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
	
	public void Play (AudioClip clip) {
        _audio.clip = clip;
        _audio.Play();
	}
}
