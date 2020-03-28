using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour, IPointerClickHandler
{
    public string scene; 
    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
        switch (scene)
        {
            case "Play":
                print("Play");
                SceneManager.LoadScene(2);
                break;

            case "Option":
                print("Option");
                SceneManager.LoadScene(3);
                break;

            case "Exit":
                print("Exit");
                //SceneManager.LoadScene(2);
                break;

            case "Quiz":
                print("Quiz");
                //SceneManager.LoadScene(2);
                break;

            case "Drive":
                print("Drive");
                SceneManager.LoadScene(0);
                break;

            case "Back":
                print("Back");
                SceneManager.LoadScene(1);
                break;
        }
    }
}
