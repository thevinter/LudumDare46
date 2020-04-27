using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameEventListener))]
[RequireComponent(typeof(Image))]

public class UI_DeathScreenManager : MonoBehaviour
{
    private Image image;
    // Start is called before the first frame update
    void Start() {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    public void Fade(bool fadeAway) {
        StartCoroutine(FadeImage(fadeAway));
    }

    /// <summary>
    /// IEnumerator that allows the fade of an Image. It shouldn't be here but rather in a separate UI script
    /// </summary>
    /// <param name="fadeAway"></param>
    /// <param name="gameOver"></param>
    /// <returns></returns>
    IEnumerator FadeImage(bool fadeAway) {
        // fade from opaque to transparent
        if (fadeAway) {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime) {
                // set color with i as alpha
                image.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else {
            // loop over 1 second
            for (float i = 0; i <= 2; i += Time.deltaTime) {
                // set color with i as alpha
                image.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}
