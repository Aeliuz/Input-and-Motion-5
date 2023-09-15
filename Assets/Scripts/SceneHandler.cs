using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public TextMeshProUGUI text_display;


    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Multiplayer()
    {
        text_display.text = "There is no multiplayer.".ToString();
        Invoke("clear_message", 2);

    }
    public void Options()
    {
        text_display.text = "The only option is not to play.".ToString();
        Invoke("clear_message", 2);
    }
    public void QuitGame()
    {
        text_display.text = "You can't quit.".ToString();
        Invoke("clear_message", 2);
    }

    void clear_message()
    {
        text_display.text = " ".ToString();
    }

}
