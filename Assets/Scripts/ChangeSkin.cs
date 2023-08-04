using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;
    public bool SkinIsBought = false;
    public int ValueOfSkin = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;

    }

    void Update()
    {

        if (SkinIsBought)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (spriteRenderer.sprite == sprite1)
                {
                    spriteRenderer.sprite = sprite2;
                }
                else
                {
                    spriteRenderer.sprite = sprite1;
                }
            }
        }
    }

    public void AddSkinWasBought()
    {
        SkinIsBought = true;
    }
}
