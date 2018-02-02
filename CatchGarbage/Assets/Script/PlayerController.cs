using UnityEngine;
using System.Collections;

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

    [HideInInspector]public bool moveLeft = false;
    [HideInInspector]public bool moveRight = false;

    [HideInInspector] public int characterID = 0;

    public KeyCode leftKey;
    public KeyCode rightKey;

    public float speed = 1;
    private float currentSpeed = 0;

    private Rigidbody2D _rigidbody;

    private Animator recycleGuyAnim;
    private Animator trashGuyAnim;
    private Animator fireFighterAnim;

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

        //StanderdInput();
        OnMovement(moveLeft, moveRight);
        SelectCharacter();

        if (recycleGuy.gameObject.activeInHierarchy == true) {
            recycleGuyAnim.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        } else if (trashGuy.gameObject.activeInHierarchy == true) {
            trashGuyAnim.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        } else if (fireFighter.gameObject.activeInHierarchy == true) {
            fireFighterAnim.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        }
    }

    private void SelectCharacter() {
        if (characterID == 0) {
            recycleGuy.gameObject.SetActive(true);
            trashGuy.gameObject.SetActive(false);
            fireFighter.gameObject.SetActive(false);
        } else if (characterID == 1) {
            recycleGuy.gameObject.SetActive(false);
            trashGuy.gameObject.SetActive(true);
            fireFighter.gameObject.SetActive(false);
        } else if (characterID == 2) {
            recycleGuy.gameObject.SetActive(false);
            trashGuy.gameObject.SetActive(false);
            fireFighter.gameObject.SetActive(true);
        }
    }

    /*private void AcceleratorInput() {
        
        float dirX = Input.acceleration.x;

        if (dirX < -0.1f) {
            _rigidbody.velocity = new Vector3(-speed, 0, 0);
            this.transform.localScale = new Vector3(-1, 1, 1);
            recycleGuyAnim.speed = speed / 2;
            fireFighterAnim.speed = speed / 2;
            fireFighterAnim.speed = speed / 2;
        }else if (dirX > 0.1f) {
            _rigidbody.velocity = new Vector3(speed, 0, 0);
            this.transform.localScale = new Vector3(1, 1, 1);
            recycleGuyAnim.speed = speed / 2;
            trashGuyAnim.speed = speed / 2;
            fireFighterAnim.speed = speed / 2;
        }
    }*/

    private void StanderdInput() {
        OnMovement(Input.GetKey(leftKey), Input.GetKey(rightKey));
    }

    private void OnMovement(bool onMoveLeft = false, bool onMoveRight = false) {
        currentSpeed = 0;

        if (onMoveLeft) {
            currentSpeed = -speed;
            this.transform.localScale = new Vector3(-0.85f, 0.85f, 1);
        }

        if (onMoveRight) {
            currentSpeed = speed;
            this.transform.localScale = new Vector3(0.85f, 0.85f, 1);
        }
    }

    private void FixedUpdate() {
        _rigidbody.velocity = new Vector3(currentSpeed, 0, _rigidbody.velocity.y);
    }
}
