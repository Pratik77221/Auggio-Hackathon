using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextAnim : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] Button continueButton;

    public string[] stringArray;

    [SerializeField] float timeBtwnChars = 0.05f;
    [SerializeField] float timeBtwnWords = 1.5f;

    int currentParagraphIndex = 0;

    void Start()
    {
        // Make sure the button is hidden at the start
        if (continueButton != null)
            continueButton.gameObject.SetActive(false);

        StartNextParagraph();
    }

    void StartNextParagraph()
    {
        if (currentParagraphIndex <= stringArray.Length - 1)
        {
            // Set new paragraph text
            _text.text = "";  // Clear the text first
            StartCoroutine(TypewriterEffect(stringArray[currentParagraphIndex]));
        }
        else
        {
            // All paragraphs have been displayed, show the button
            if (continueButton != null)
                continueButton.gameObject.SetActive(true);
        }
    }

    private IEnumerator TypewriterEffect(string textToType)
    {
        // Type each character one by one
        for (int i = 0; i <= textToType.Length; i++)
        {
            _text.text = textToType.Substring(0, i);
            yield return new WaitForSeconds(timeBtwnChars);
        }

        // Wait before showing next paragraph
        yield return new WaitForSeconds(timeBtwnWords);

        // Move to the next paragraph
        currentParagraphIndex++;
        StartNextParagraph();
    }


    public void launchAR()
    {
        SceneManager.LoadScene("ARScene");
    }

}