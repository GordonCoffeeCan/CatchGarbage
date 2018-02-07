using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text scoreUI;
    public GameObject player;

    public static int score;
    public static bool isGameStart = false;

    private AudioSource _audio;

    public AudioClip burstSound;
    public AudioClip erosionSound;
    public AudioClip garbageSound;
    public AudioClip onFireSound;

    void Awake() {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        score = 0;
        _audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreUI.text = score.ToString();
    }

    public void ReloadLevel() {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void PlaySound(string _clip) {
        switch (_clip) {
            case "Burst":
                _audio.clip = burstSound;
                _audio.Play();
                break;
            case "Erosion":
                _audio.clip = erosionSound;
                _audio.Play();
                break;
            case "Garbage":
                _audio.clip = garbageSound;
                _audio.Play();
                break;
            case "OnFire":
                _audio.clip = onFireSound;
                _audio.Play();
                break;
        }
    }
}
