using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textField;

    private int _score;
    private int _currentScore;
    private int _amountKilledAliens;
    
    public int Score 
    { 
        get 
        {
            return _score; 
        }
    }
    public int AmountKilledAliens
    {
        get
        {
            return _amountKilledAliens;
        }
    }

    public void CalculateScore(string name)
    {
        switch (name)
        {
            case "Meteor 5(Clone)":
            {
                _score += 5;
                break;
            }
            case "Meteor 6(Clone)":
            {
                _score += 5; 
                break;
            }
            case "AlienEnemy(Clone)":
            {
                _score += 10;
                _amountKilledAliens += 1;
                break;
            }
            default:
            _score += 1;
            break;
        }
    }

    private void SetText()
    {
        _textField.text = _score.ToString();
    }

    private void Update()
    {
        SetText();
    }
}