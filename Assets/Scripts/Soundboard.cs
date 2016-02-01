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


    public int gridCols = 3;
    public int gridRows = 4;

    public GameObject mainPanel;
    public GameObject prefabRow;
    public GameObject prefabPlayBtn;
    public GameObject prefabSpacer;


	void Start () {
        instance = this;
	}

    void Awake()
    {
        _audio = GetComponent<AudioSource>();


        int clipIndex = 0;

        for (int row = 0; row < gridRows; row++)
        {
            //init new vert layout panel
            GameObject panelRow = Instantiate(prefabRow);
            panelRow.transform.SetParent(mainPanel.transform,false);

            for (int col = 0; col < gridCols; col++)
            {
                //init new button in panel


                if (clipIndex < items.Length)
                {
                    Debug.Log(string.Format("btn {0}x{1}", col, row));

                    GameObject playBtn = Instantiate(prefabPlayBtn);
                    playBtn.transform.SetParent(panelRow.transform, false);

                    AudioClip clip = items[clipIndex];

                    playBtn.GetComponent<ButtonPlayer>().setClip(clip, clip.name);


                    clipIndex++;
                }
                else
                {
                    GameObject panelSpacer = Instantiate(prefabSpacer);
                    panelSpacer.transform.SetParent(panelRow.transform, false);
                }

            }


        }


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
