using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : MonoBehaviour
{
    public Image image;
    public Sprite onSprite;
    public Sprite offSprite;

    void Start()
    {
        //GetComponent<Button>().onClick.AddListener(Switch);
    }

    public void Switch()
    {
        image.sprite = image.sprite == onSprite ? offSprite : onSprite;
    }
}
