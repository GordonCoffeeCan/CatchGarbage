using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;

    public static GameManager Instance {
        get {
            return _instance;
        }
    }

    public Transform restartPanel;
    public Text scoreUI;
    public GameObject startPage;
    public GameObject player;

    public static int score;
    public static bool isGameStart = false;

    private AudioSource _audio;

    public AudioClip burstSound;
    public AudioClip erosionSound;
    public AudioClip garbageSound;
    public AudioClip onFireSound;

    void Awake() {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
        score = 0;
        _audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreUI.text = score.ToString();

        if (Input.anyKeyDown && isGameStart == false && restartPanel.gameObject.activeInHierarchy == false) {
            startPage.SetActive(false);
            player.SetActive(true);
            scoreUI.gameObject.SetActive(true);
            isGameStart = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) && isGameStart == false && restartPanel.gameObject.activeInHierarchy == true) {
            ReloadLevel();
        }
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
