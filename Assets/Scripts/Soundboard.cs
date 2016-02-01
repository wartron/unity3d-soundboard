using UnityEngine;
using System.Collections;

public class Soundboard : MonoBehaviour {


    public static Soundboard instance;

    private AudioSource _audio;


    [System.Serializable]
    public class AudioItem{
        public AudioClip clip;
        public string label;
    }

    public AudioClip[] items;


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

    public void PitchSliderChange(float val)
    {
        Debug.Log("Pitch val " + val);

        _audio.pitch = val;
    }
}
