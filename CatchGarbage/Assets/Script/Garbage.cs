using UnityEngine;
using System.Collections;

public class Garbage : MonoBehaviour {
    private const string PLAYER_PREFIX = "Player";
    private const string GROUND_PREFIX = "Ground";
    private SpriteRenderer sprite;
    private float timer = 5;
    private float rayLength = 0;
    private Collider2D col;
    private LayerMask hitLayer;
    private bool hitGround;

    // Use this for initialization
    void Start () {
        sprite = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<Collider2D>();
        hitLayer = LayerMask.GetMask("HitLayer");
        hitGround = false;
        rayLength = Mathf.Sqrt((Mathf.Pow(col.bounds.size.x, 2) + Mathf.Pow(col.bounds.size.y, 2)) / 4);
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D _hit = Physics2D.Raycast(this.transform.position, Vector2.down, rayLength, hitLayer);

        if(_hit.collider != null) {
            if (_hit.collider.tag == PLAYER_PREFIX) {
                Debug.Log("HitPlayer!");
                Destroy(this.gameObject);
            }else if (_hit.collider.tag == GROUND_PREFIX) {
                hitGround = true;
            }
            
        }

        Debug.DrawRay(this.transform.position, Vector3.down * rayLength, Color.red, Time.deltaTime);

        if (hitGround) {
            sprite.color = new Color32(255, 255, 255, (byte)Mathf.Lerp(255, 0, 0.5f));
        }
        
    }
}
