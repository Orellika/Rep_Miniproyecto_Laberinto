using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TMPGUI;
    [SerializeField] GameObject gameManager;
    GameManager gM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gM = gameManager.GetComponent<GameManager>();
        TMPGUI.GetComponent<TextMeshProUGUI>();
        TMPGUI.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gM.playerHasKey)
        {
            //WIN
            SceneManager.LoadScene("Win");
        }
        else if (other.tag == "Player" && !gM.playerHasKey)
        {
            //A KEY IS REQUIRED
            TMPGUI.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !gM.playerHasKey)
        {
            TMPGUI.enabled = false;
        }
    }
}

