using UnityEngine;

public class GameData : MonoBehaviour
{
    public static string CorrectAnswer { get; set; } = "Baul";
    
    public static bool IsCorrectAnswer(string PlayAnswer)
    {
        return PlayAnswer.Equals(CorrectAnswer, System.StringComparison.OrdinalIgnoreCase);
    }
}