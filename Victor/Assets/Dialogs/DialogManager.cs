using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public Animator animator;
    public Text nameText;
    public Text dialogText;
    public Image NPCImage;

    public int state = 0;
    public Dialog[] _dialog;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        StopAllCoroutines();
        StartCoroutine(StartDialog());
    }

    IEnumerator StartDialog()
    {
        yield return new WaitForSeconds(1);

        animator.SetBool("IsOpen", true);

        nameText.text = _dialog[state].name;
        NPCImage.sprite = _dialog[state].NPC.sprite;
        sentences.Clear();

        foreach (string sentence in _dialog[state].sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartNextDialog()
    {
        animator.SetBool("IsOpen", true);

        nameText.text = _dialog[state].name;
        NPCImage.sprite = _dialog[state].NPC.sprite;
        sentences.Clear();

        foreach (string sentence in _dialog[state].sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            StopAllCoroutines();
            StartCoroutine(EndDialog());
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    IEnumerator EndDialog()
    {
        animator.SetBool("IsOpen", false);

        state++;

        yield return new WaitForSeconds(0.5f);

        if (state < _dialog.Length)
        {
            StartNextDialog();
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
