using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public Question[] Questions;

    private static List<Question> unansweredQuestion;
    private static int faultsNumber = 0;

   private Question curentQuestion;

    [SerializeField]
    private Text curenQuestionText;

    [SerializeField]
    private RawImage curenQuestionTexture;

    [SerializeField]
    private float timeBetweenQuestion = 1f;


    void Start()
    {
        
        if ((unansweredQuestion == null) || (unansweredQuestion.Count == 0))
        {
            unansweredQuestion = Questions.ToList<Question>();
        }
        SetRandomQuestion();
        //Debug.Log(curentQuestion.question + " is " + curentQuestion.answer);
    }

    private void SetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestion.Count);

        curentQuestion = unansweredQuestion[randomQuestionIndex];

        curenQuestionText.text = curentQuestion.question;
        curenQuestionTexture.texture = curentQuestion.imageTexture;

    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestion.Remove(curentQuestion);
        
        Debug.Log(unansweredQuestion.Count);

        yield return new WaitForSeconds(timeBetweenQuestion);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserAnswer (int choise)
    {
        if (choise != curentQuestion.answer)
        {
            Debug.Log("UNCORECT!!");
            faultsNumber++;
        }
        else
        {
            Debug.Log("CORECT!!");
        }

        StartCoroutine(TransitionToNextQuestion());
    }
}