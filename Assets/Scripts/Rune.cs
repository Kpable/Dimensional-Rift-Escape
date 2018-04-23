using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour {

    public delegate void RuneHit(int runeID);
    public RuneHit OnRuneHit;
    public int runeID;
    bool pressed;
    SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() && 
            collision.gameObject.layer == LayerMask.NameToLayer("Player Bullets")) 
        {
            if (!pressed)
            {
                if (OnRuneHit != null)
                    OnRuneHit(runeID);
                Press();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            if (!pressed)
            {
                if (OnRuneHit != null)
                    OnRuneHit(runeID);
                Press();
            }
        }
    }

    public void Unpress()
    {
        sr.color = Color.white;
        pressed = false;
    }

    public void Press()
    {
        sr.color = Color.grey;
        pressed = true;

    }
}
