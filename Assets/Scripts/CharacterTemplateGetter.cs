using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CharacterTemplateGetter : MonoBehaviour
{
    public CharacterTemplate charTemplate;
    private SpriteRenderer characterSprite;
    private LevitationAnimation iconSprite;

    private void Update()
    {
        {
            characterSprite = gameObject.transform.Find("CharacterSprite").GetComponent<SpriteRenderer>();
            iconSprite = gameObject.transform.Find("TalkingIcon").GetComponent<LevitationAnimation>();

            characterSprite.sprite = charTemplate.idleSprite;
            iconSprite.baseY = 3.44f + charTemplate.taille - 0.8f;
        }
    }
}