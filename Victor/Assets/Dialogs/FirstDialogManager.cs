using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstDialogManager : MonoBehaviour
{
    public Animator animator;
    public Text nameText;
    public Text dialogText;
    public Image NPCImage;

    public Image NPCIce;
    public Image NPCFire;
    public Image NPCBolt;

    public int state = 0;
    public Dialog[] _dialog;

    public static int TeamChoice = -1;

    private Queue<string> sentences;
    private bool dialogEnded = false;

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
            NPCIce.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            NPCFire.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            NPCBolt.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            StopAllCoroutines();
            StartCoroutine(EndDialog());
            return;
        }

        string sentence = sentences.Dequeue();

        if (state == 0 && sentences.Count == 3)
        {
            NPCIce.color = new Color(NPCIce.color.r, NPCIce.color.b, NPCIce.color.b, 1f);
            NPCFire.color = new Color(NPCFire.color.r, NPCFire.color.b, NPCFire.color.b, 1f);
            NPCBolt.color = new Color(NPCBolt.color.r, NPCBolt.color.b, NPCBolt.color.b, 1f);
        }
        else if (state == 0 && sentences.Count == 2)
        {
            NPCIce.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (state == 0 && sentences.Count == 1)
        {
            NPCIce.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            NPCFire.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (state == 0 && sentences.Count == 0)
        {
            NPCFire.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            NPCBolt.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (state == 1 && sentences.Count == 0)
        {
            NPCIce.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (state == 2 && sentences.Count == 0)
        {
            NPCIce.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            NPCFire.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (state == 3 && sentences.Count == 0)
        {
            NPCFire.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            NPCBolt.color = new Color(1f, 1f, 1f, 1f);
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.01f);
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
            NPCIce.color = new Color(1f, 1f, 1f, 1f);
            NPCFire.color = new Color(1f, 1f, 1f, 1f);
            NPCBolt.color = new Color(1f, 1f, 1f, 1f);
            dialogEnded = true;
        }
    }

    public void ChooseTeam(int team)
    {
        if (dialogEnded)
        {
            TeamChoice = team;
            Debug.Log("You have chose team : " + team);
            SceneManager.LoadScene(2);
        }
    }
}
