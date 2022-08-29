using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonPressScript : MonoBehaviour
{
    [SerializeField] private Sprite button_pressed_sprite, button_unpressed_sprite;
    [SerializeField] private SpriteRenderer button_renderer;

    [SerializeField] private GameObject object_to_disable;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            button_renderer.sprite = button_pressed_sprite;
            object_to_disable.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            button_renderer.sprite = button_unpressed_sprite;
            object_to_disable.SetActive(true);
        }
    }
}
