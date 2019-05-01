using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutRender : MonoBehaviour {


    public SpriteRenderer[] spriteRenderers;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // do some
            setRanderers(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            setRanderers(true);


        }
    }


    void setRanderers(bool active)
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].gameObject.SetActive(active);
        }
    }
}
