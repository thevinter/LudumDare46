using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialShower : MonoBehaviour
{
    public TextMeshProUGUI tutorial;
    public string prompt;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ShowTutorial(prompt));
        }
    }


    IEnumerator ShowTutorial(string prompt)
    {
        tutorial.text = prompt;
        StartCoroutine(FadeIn(tutorial));
        yield return new WaitForSeconds(2f);
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
        tutorial.text = "";
        yield break;
        
    }
}
