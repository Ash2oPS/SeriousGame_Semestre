using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private int currentSprite;
    private float timer;
    private Sprite spr1, spr2;
    private SpriteRenderer sr, srshadow;
    private DialogueManager dm;

    [SerializeField]
    private float timeBetweenSprites;

    [SerializeField]
    private CharacterTemplate charTemplate;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
        sr = transform.Find("CharacterSprite").GetComponent<SpriteRenderer>();
        srshadow = sr.transform.Find("CharacterSpriteShadow").GetComponent<SpriteRenderer>();
        spr1 = charTemplate.idleSprite;
        spr2 = charTemplate.idleSprite2;
        currentSprite = 1;
    }

    private void Update()
    {
        if (!dm.isDialogueOn)
        {
            if (timer >= timeBetweenSprites)
            {
                timer = 0;

                if (currentSprite == 1)
                {
                    currentSprite = 2;
                    sr.sprite = spr2;
                    srshadow.sprite = spr2;
                }
                else
                {
                    currentSprite = 1;
                    sr.sprite = spr1;
                    srshadow.sprite = spr1;
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}