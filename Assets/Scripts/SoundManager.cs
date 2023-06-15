using UnityEngine;
using System.Collections;



public class SoundManager : MonoBehaviour {
    [SerializeField]
    public Sound[] sounds;
    public static SoundManager instance = null;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_"+i+" "+sounds[i].name);
            _go.AddComponent<AudioSource>();
            _go.transform.parent = this.transform;
            sounds[i].setSource(_go.GetComponent<AudioSource>());
        }

        PlaySound("Music");
    }

    public void killMusic()
    {
        StopSound("Music");
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].play();
            }
        }
    }

    public void StopSound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name)
            {
                sounds[i].stop();
            }
        }
    }

    
	
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 0.7f;
    [Range(0.5f,1.5f)]
    public float pitch = 1.0f;
    public bool loop = false;
    private AudioSource source;
    [Range(0f,0.5f)]
    public float randomVolume = 0f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;


    public void setSource(AudioSource _source)
    {
        this.source = _source;
        this.source.clip = clip;
    }

    public void play()
    {
        source.volume = volume * ( 1 + Random.Range(-randomVolume/2, randomVolume/2));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2, randomPitch / 2));
        source.loop = loop;
        source.Play();
    }

    public void stop()
    {
        source.Stop();
    }
}
