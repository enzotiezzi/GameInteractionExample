using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 2.0f;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private Interactable _interactable;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var right = moveHorizontal > 0;
        var left = moveHorizontal < 0;
        var up = moveVertical > 0;
        var down = moveVertical < 0;

        var isMoving = right | left | up | down;

        _animator.SetBool("isMoving", isMoving);

        if (right)
        {
            _spriteRenderer.flipX = false;
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (left)
        {
            _spriteRenderer.flipX = true;
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        if (up)
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
        }
        if (down)
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
        }
        
        if(Input.GetButtonDown("Submit") && _interactable != null)
        {
            _interactable.ShowNextDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        _interactable = col.gameObject.GetComponent<Interactable>();

        if (_interactable != null)
            _interactable.TriggerDialog();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _interactable = null;
    }
}
