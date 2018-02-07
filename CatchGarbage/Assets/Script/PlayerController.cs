using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    [SerializeField] private SpriteRenderer[] characterSprites;
    [SerializeField] private float speed = 1;

    [HideInInspector] public int characterID = 0;
    [HideInInspector] public float moveBoundary = 0;
    [HideInInspector] public bool isTouchControl = false;
    [HideInInspector] public bool moveLeft = false;
    [HideInInspector] public bool moveRight = false;

    private float currentSpeed = 0;
    private float smoothStep = 0.3f;
    private Animator[] characterAnim = new Animator[3];
    private Rigidbody2D rig;

    void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start() {
        rig = this.transform.GetComponent<Rigidbody2D>();

        if (characterSprites.Length > 0) {
            for (int i = 0; i < characterSprites.Length; i++) {
                characterAnim[i] = characterSprites[i].GetComponent<Animator>();
            }
        }

        this.transform.localScale = new Vector3(0.85f, 0.85f, 1);
    }

    // Update is called once per frame
    void Update() {

        characterAnim[characterID].SetFloat("Speed", Mathf.Abs(currentSpeed));

        OnMove();
        ChangeCharacter();
    }

    private void OnMove() {
        if (isTouchControl) {
            if (moveRight) {
                currentSpeed = Mathf.Lerp(currentSpeed, speed, smoothStep);
            }
            if (moveLeft) {
                currentSpeed = Mathf.Lerp(currentSpeed, -speed, smoothStep);
            }
        } else {
            currentSpeed = Mathf.Lerp(currentSpeed, speed * Input.GetAxis("Horizontal"), smoothStep);
        }

        if (currentSpeed >= 0.01f) {
            this.transform.localScale = new Vector3(0.85f, 0.85f, 1);
        } else if (currentSpeed <= -0.01f) {
            this.transform.localScale = new Vector3(-0.85f, 0.85f, 1);
        }

        if (this.transform.position.x > moveBoundary) {
            this.transform.position = new Vector2(moveBoundary, this.transform.position.y);
        } else if (this.transform.position.x < -moveBoundary) {
            this.transform.position = new Vector2(-moveBoundary, this.transform.position.y);
        }
    }

    private void ChangeCharacter() {
        for (int i = 0; i < characterSprites.Length; i++) {
            if(i == characterID) {
                characterSprites[i].gameObject.SetActive(true);
            } else {
                characterSprites[i].gameObject.SetActive(false);
            }
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

    private void FixedUpdate() {
        rig.MovePosition(new Vector2(this.transform.position.x + currentSpeed * Time.deltaTime, this.transform.position.y));
    }
}
