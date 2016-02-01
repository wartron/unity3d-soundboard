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

    public GameObject uiMainPanel;
    public GameObject uiBtnNext;
    public GameObject uiBtnPrev;



    public GameObject prefabRow;
    public GameObject prefabPlayBtn;
    public GameObject prefabSpacer;


    private int _page = 0;
    private int _pageOffset = 0;
    

	void Start () {
        instance = this;
	}

    void Awake()
    {
        _audio = GetComponent<AudioSource>();

        RenderButtons();
        
    }

    void RenderButtons()
    {

        int clipIndex = _pageOffset;

        for (int row = 0; row < gridRows; row++)
        {
            //init new vert layout panel
            GameObject panelRow = Instantiate(prefabRow);
            panelRow.transform.SetParent(uiMainPanel.transform, false);

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

    void ClearButtons()
    {
        //remove all children
        foreach (Transform row in uiMainPanel.transform)
        {
            Destroy(row.gameObject);
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

    public void UiBtnNextClick()
    {
        ClearButtons();
        _page = _page + 1;
        _pageOffset = _page * (gridCols * gridRows);
        RenderButtons();
    }
    public void UiBtnPrevClick()
    {
        if (_page == 0)
            return;

        ClearButtons();
        _page = _page - 1;
        _pageOffset = _page * (gridCols * gridRows);

  

        RenderButtons();
    }
}
