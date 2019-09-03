using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;


    Rigidbody2D rigidbody2d;

    Animator animator;
    Vector2 lookDirection = new Vector2(0, -1);

    private void Awake()
    {
        if (GlobalContext.useSavedPosition)
        {
            Debug.Log("[SAVE] Using saved position for player");
            transform.position = GlobalContext.playerTransformPosition;
            GlobalContext.useSavedPosition = false;
        }
        else
        {
            Debug.Log("[SAVE] No saved position used for player");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (DialogBox.instance.isActive() || ChoiceBox.instance.isActiveAndEnabled)
        {
            horizontal = vertical = 0;
        }

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;

        position += move * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        if (Input.GetButtonDown("Fire2") && !DialogBox.instance.isActive())
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 3.0f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                NonPlayableCharacter character = hit.collider.GetComponent<NonPlayableCharacter>();
                if (character != null)
                {
                    character.OnRaycast();
                }
            }
        }
    }
}
