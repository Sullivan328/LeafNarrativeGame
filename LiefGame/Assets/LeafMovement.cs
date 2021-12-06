using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeafMovement : MonoBehaviour
{
    public float moveSpeed;
    public float moveBuffer;

    public Rigidbody2D _rb;
    private SpriteRenderer _spriteRend;

    private float _playerSpeed;

    private bool isInDialogue;

    [SerializeField]
    LeafGameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       
    }


    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Z))
        {
            gameManager.DialogueScreen();
         
       }
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        //Debug.Log("Movement: " + movement);
        transform.localPosition += movement;
    }

    private void FlipSpriteDirection()
    {
        float direction = Mathf.Sign(_playerSpeed);

        if(direction < 0)
        {
            _spriteRend.flipX = false;
        }
        else
        {
            _spriteRend.flipX = true;
        }
    }
}
