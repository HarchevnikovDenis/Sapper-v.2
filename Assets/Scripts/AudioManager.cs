using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public static AudioManager audio { get; private set;}
    public int music
    {
        get
        {
            return PlayerPrefs.GetInt("Music", 1);
        }
        set
        {
            PlayerPrefs.SetInt("Music", value);
            audioSource.volume = value;
        }
    }


    private void Awake()
    {
        if(!audio)
        {
            audio = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource.volume = music;
    }
}
