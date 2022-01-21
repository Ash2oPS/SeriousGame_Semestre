using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EmotionsToSprite
{
    public Emotion emotionName;
    public Sprite emotionSprite;

    public EmotionsToSprite(Emotion emotionName, Sprite emotionSprite)
    {
        this.emotionName = emotionName;
        this.emotionSprite = emotionSprite;
    }
}