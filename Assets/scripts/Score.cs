using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public TMP_Text newScore;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public const string prefScore = "prefScore";  


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 5f;
    }
    void Update()
    {
        newScore.text = "Score :" + (int)scoreAmount  ;
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;

        Achievement1();
        
    }

    public bool CheckNewHighscore()
    {
        if((int)scoreAmount > PlayerPrefs.GetInt("prefScore"))
        {
            //New Highscore
            PlayerPrefs.SetInt(prefScore, (int)scoreAmount);
            Debug.Log("new highscore: " + (int)scoreAmount);
            return true;


        }
        else
        {
            //no new Highscore

            Debug.Log("no new highscore");
            return false;
        }    
    }

    public void Achievement1()
    {      
        if ((int)scoreAmount == 50)
        {         
            AchievementManager.Instance.UnlockAchievement(Achievement.AchievementTypes.ReachDistance1);
        }
        if ((int)scoreAmount == 100)
        {
            AchievementManager.Instance.UnlockAchievement(Achievement.AchievementTypes.ReachDistance2);
        }
        if ((int)scoreAmount == 150)
        {
            AchievementManager.Instance.UnlockAchievement(Achievement.AchievementTypes.ReachDistance3);
        }

    }
    

}
