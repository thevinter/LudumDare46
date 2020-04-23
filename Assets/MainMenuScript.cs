﻿using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    GameObject p;
    public AudioClip boop;
    public AudioClip woosh;
    public Button startButton;
    public TextMeshProUGUI tutorial;

    public void Sound()
    {
        AudioManager.Instance.Play(boop, transform, .1f);
    }
    public void StartGame()
    {
        Camera.main.GetComponent<CameraFollow>().player = p.transform;
        
        p.GetComponentInChildren<Light>().intensity = 2;
        p.GetComponentInChildren<Light>().range = 20;
        StartCoroutine(fadeButton(startButton, false, .2f));
        AudioManager.Instance.Play(woosh, transform, .1f, 2.5f);
        StartCoroutine(ShowTutorial("Use WASD to move"));
    }
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
        p.GetComponent<Player>().isResting = true;
        //


    }

    IEnumerator ShowTutorial(string prompt)
    {

        yield return new WaitForSeconds(1.5f);
        Camera.main.GetComponent<CameraFollow>().smoothSpeed = 0.125f;
        p.GetComponent<Player>().isResting = false;
        p.GetComponent<Animator>().SetBool("isIdle", true); 
        tutorial.text = prompt;
        StartCoroutine(FadeIn(tutorial));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeOut(tutorial));
    }

    private IEnumerator FadeIn(TextMeshProUGUI text)
    {
        float duration = 0.5f; //0.5 secs
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator FadeOut(TextMeshProUGUI text)
    {
        float duration = 0.5f; //0.5 secs
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    IEnumerator fadeButton(Button button, bool fadeIn, float duration)
    {

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0;
            b = 1;
        }
        else
        {
            a = 1;
            b = 0;
        }

        Image buttonImage = button.GetComponent<Image>();
        Text buttonText = button.GetComponentInChildren<Text>();

        //Enable both Button, Image and Text components
        if (!button.enabled)
            button.enabled = true;

        if (!buttonImage.enabled)
            buttonImage.enabled = true;

        if (!buttonText.enabled)
            buttonText.enabled = true;

        //For Button None or ColorTint mode
        Color buttonColor = buttonImage.color;
        Color textColor = buttonText.color;

        //For Button SpriteSwap mode
        ColorBlock colorBlock = button.colors;


        //Do the actual fading
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);
            //Debug.Log(alpha);

            if (button.transition == Selectable.Transition.None || button.transition == Selectable.Transition.ColorTint)
            {
                buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);//Fade Traget Image
                buttonText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);//Fade Text
            }
            else if (button.transition == Selectable.Transition.SpriteSwap)
            {
                ////Fade All Transition Images
                colorBlock.normalColor = new Color(colorBlock.normalColor.r, colorBlock.normalColor.g, colorBlock.normalColor.b, alpha);
                colorBlock.pressedColor = new Color(colorBlock.pressedColor.r, colorBlock.pressedColor.g, colorBlock.pressedColor.b, alpha);
                colorBlock.highlightedColor = new Color(colorBlock.highlightedColor.r, colorBlock.highlightedColor.g, colorBlock.highlightedColor.b, alpha);
                colorBlock.disabledColor = new Color(colorBlock.disabledColor.r, colorBlock.disabledColor.g, colorBlock.disabledColor.b, alpha);

                button.colors = colorBlock; //Assign the colors back to the Button
                buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);//Fade Traget Image
                buttonText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);//Fade Text
            }
            else
            {
                Debug.LogError("Button Transition Type not Supported");
            }

            yield return null;
        }

        if (!fadeIn)
        {
            //Disable both Button, Image and Text components
            buttonImage.enabled = false;
            buttonText.enabled = false;
            button.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
