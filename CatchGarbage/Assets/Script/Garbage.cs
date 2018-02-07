using UnityEngine;
using System.Collections;

public class Garbage : MonoBehaviour {
    private const string PLAYER_PREFIX = "Player";
    private float timer = 3;
    private float rayLength = 0;
    private Collider2D collider;
    private LayerMask hitLayer;

    // Use this for initialization
    void Start () {
        collider = this.GetComponent<Collider2D>();
        hitLayer = LayerMask.GetMask("HitLayer");
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D _hit = Physics2D.Raycast(this.transform.position, Vector2.down, 0.3f, hitLayer);

        if(_hit.collider != null && _hit.collider.tag == "Player") {
            Debug.Log("HitPlayer!");
            Destroy(this.gameObject);
        }

        Debug.DrawRay(this.transform.position, Vector3.down * 0.5f, Color.red, Time.deltaTime);


        Destroy(this.gameObject, timer);
	}
}
