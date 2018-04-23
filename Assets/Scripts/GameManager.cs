using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public TMP_Text storyText;
    public string[] story;
    public GameObject[] lifeIcons;

    public AudioClip[] clips;

    int storyIndex;

    private bool hasTextChanged;
    int totalLives = 3;

    AudioSource source;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        StartCoroutine("TellStory");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TellStory()
    {
        for (int i = 0; i < story.Length; i++)
        {
            storyText.text = story[i];
            StartCoroutine(RevealCharacters(storyText));
            
            yield return new WaitForSeconds(2);
            if (i == 9)
            {
                StartCoroutine("ShowLives");
                yield return new WaitForSeconds(3);

            }
        }

        storyText.text = "";
        
    }


    void OnEnable()
    {
        // Subscribe to event fired when text object has been regenerated.
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
    }

    void OnDisable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
    }


    // Event received when the text object has changed.
    void ON_TEXT_CHANGED(Object obj)
    {
        hasTextChanged = true;
    }

    /// <summary>
    /// Method revealing the text one character at a time.
    /// </summary>
    /// <returns></returns>
    IEnumerator RevealCharacters(TMP_Text textComponent)
    {
        textComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = textComponent.textInfo;

        int totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
        int visibleCount = 0;

        while (visibleCount < totalVisibleCharacters)
        {
            if (hasTextChanged)
            {
                totalVisibleCharacters = textInfo.characterCount; // Update visible character count.
                hasTextChanged = false;
            }

            //if (visibleCount > totalVisibleCharacters)
            //{
            //    yield return new WaitForSeconds(1.0f);
            //    visibleCount = 0;
            //}

            textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

            visibleCount += 1;

            yield return null;
        }
    }


    IEnumerator ShowLives()
    {
        for (int i = 0; i < totalLives; i++)
        {
            lifeIcons[i].SetActive(true);
            // play life sound
            source.PlayOneShot(clips[0]);
            yield return new WaitForSeconds(1);
        }
    }
}
