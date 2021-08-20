using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D _rb2;
    private Animator _anim;

    [SerializeField]
    private float _upVelocity;
    private bool _isBirdDead = false;

    void Start()
    {
        _rb2 = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!_isBirdDead && Input.GetMouseButtonDown(0))
        {
            _rb2.velocity = Vector2.up * _upVelocity;
            _anim.SetBool("Fly", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isBirdDead)
        {
            _anim.SetBool("Fly", false);
            GameEvents.gameEvents.GameOver();
            _isBirdDead = true;
        }
    }
}
