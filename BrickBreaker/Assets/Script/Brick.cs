using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Brick : MonoBehaviour
{

    public SpriteRenderer spriteRenderer { get; private set; }
    public bool unbreake;

    public Sprite[] states;

    public int healt { get; private set; }


    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (!this.unbreake)
        {
            this.healt = this.states.Length;
            this.spriteRenderer.sprite = this.states[this.healt - 1];
        }
    }

    private void Hit()
    {
        if (this.unbreake)
        {
            return;
        }
        this.healt--;
        if (this.healt <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.spriteRenderer.sprite = this.states[this.healt - 1];
        }




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }
}
