using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private static PlayerController _instance;

    public static PlayerController Instance {
        get {
            return _instance;
        }
    }

    public Transform recycleGuy;
    public Transform trashGuy;
    public Transform fireFighter;

    public Text debugOutput;

    public float speed = 1;

    private Rigidbody2D _rigidbody;

    private Animator recycleGuyAnim;
    private Animator trashGuyAnim;
    private Animator fireFighterAnim;

    private Touch touch;

    void Awake() {
        _instance = this;
    }

    // Use this for initialization
    void Start() {
        _rigidbody = this.transform.GetComponent<Rigidbody2D>();

        recycleGuyAnim = this.transform.Find("RecycleGuy").GetComponent<Animator>();
        trashGuyAnim = this.transform.Find("TrashGuy").GetComponent<Animator>();
        fireFighterAnim = this.transform.Find("FireFighter").GetComponent<Animator>();

        recycleGuy.gameObject.SetActive(true);
        trashGuy.gameObject.SetActive(false);
        fireFighter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        recycleGuyAnim.speed = 2;
        trashGuyAnim.speed = 2;
        fireFighterAnim.speed = 2;

        if (recycleGuy.gameObject.activeInHierarchy == true) {
            recycleGuyAnim.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        } else if (trashGuy.gameObject.activeInHierarchy == true) {
            trashGuyAnim.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        } else if (fireFighter.gameObject.activeInHierarchy == true) {
            fireFighterAnim.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        }
    }

    void FixedUpdate() {
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Moved) {
                touch = Input.GetTouch(0);
                debugOutput.text = (touch.deltaPosition).ToString();
                if (Mathf.Abs(touch.deltaPosition.x) > 1.5f) {
                    _rigidbody.velocity = new Vector2(speed * touch.deltaPosition.x * 0.065f, 0);
                }
                
            }
        } else if (Input.touchCount <= 0) {
            _rigidbody.velocity = new Vector2(speed * 0, 0);
        }

#if UNITY_EDITOR
        _rigidbody.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), 0);
#endif
        
        if (_rigidbody.velocity.x > 0.1f) {
            this.transform.localScale = new Vector3(1, 1, 1);
        } else if (_rigidbody.velocity.x < -0.1f) {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void SetRecycle() {
        recycleGuy.gameObject.SetActive(true);
        trashGuy.gameObject.SetActive(false);
        fireFighter.gameObject.SetActive(false);
    }

    public void SetTrash() {
        recycleGuy.gameObject.SetActive(false);
        trashGuy.gameObject.SetActive(true);
        fireFighter.gameObject.SetActive(false);
    }

    public void SetFirefighter() {
        recycleGuy.gameObject.SetActive(false);
        trashGuy.gameObject.SetActive(false);
        fireFighter.gameObject.SetActive(true);
    }

}
