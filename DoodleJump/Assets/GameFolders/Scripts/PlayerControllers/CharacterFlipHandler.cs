using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlipHandler 
{
    SpriteRenderer _sprite;
    public CharacterFlipHandler(SpriteRenderer sprite)
    {
        _sprite = sprite;
    }

    public void FlipCharacter(float value)
    {
        if(value<0)
        {
            _sprite.flipX= true;
        }
        else if(value>0)
        {
            _sprite.flipX = false;
        }
    }
}
