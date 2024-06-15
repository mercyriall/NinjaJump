using UnityEngine;

public class BluePlatform : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _jumpForce = 7;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();
        var playerRigitbody = _player.GetComponent<Rigidbody2D>();

        if (player != null && collision.attachedRigidbody.velocity.y < 0 &&
            collision.transform.position.y - collision.bounds.size.y / 5 > transform.position.y)
        {
            playerRigitbody.velocity = new Vector2(playerRigitbody.velocity.x, _jumpForce);
            Destroy(this.gameObject);
        }
    }
}
