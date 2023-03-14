using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanliness : MonoBehaviour
{
    //TODO:
    //GET RID OF FLICKERING INDICATOR
    public static Cleanliness Instance;
    CleanIndicatorUI cleanlinessUI;
    public float MaxCleaningnessLevelPoints { get { return 40; } }
    public static float Points{ get { return 1f; } }
    private static float AmountOfGarbageInScene { get; set; } 


    float NormalizeValue(float _fillValue)
    {
        float _normalizedValue = _fillValue / MaxCleaningnessLevelPoints;
        return _normalizedValue;
    }

    void OnUpdateCleanRating(float cleanRatingPoints)
    {
        float normalized = NormalizeValue(cleanRatingPoints);
        cleanlinessUI.UpdateFill(normalized);
    }

    public class CleanRatingPoints
    {
        static float cleanRatingPoints = 0;
        public delegate void OnCleanUpdateDelegate(float _cleanRatingPoints); 
        static OnCleanUpdateDelegate onCleanUpdateDelegateInstance; 

        public static void Initialize(OnCleanUpdateDelegate _onUpdate) 
        {
            onCleanUpdateDelegateInstance = _onUpdate;
        }

        public static float Get()
        {
            return cleanRatingPoints;
        }

        public static float Set(float _cleanRatingPoints)
        {
            cleanRatingPoints = _cleanRatingPoints;
            onCleanUpdateDelegateInstance(_cleanRatingPoints);
            return _cleanRatingPoints;
        }
    }


    private void Awake()
    {
        Instance = this;
        cleanlinessUI = FindObjectOfType<CleanIndicatorUI>();
        CleanRatingPoints.Initialize(OnUpdateCleanRating);
    }

     void Start()
    {
        CleanRatingPoints.Set(MaxCleaningnessLevelPoints);
    }

    void Update()
    {
        if (GameManager.isGameOver)
        { return; }

        //if (Input.GetKey(KeyCode.I))
        //{
        //    IncreaseCleanRatingPoints(1);
        //}

        //if (Input.GetKey(KeyCode.P))
        //{
        //    DecreaseCleanRatingPoints(1);
        //}


        if (CleanRatingPoints.Get() <= 0)
        {
            GameManager.isGameOver = true;
            Debug.Log("isGameOver" + GameManager.isGameOver);
        }


    }

    private void FixedUpdate()
    {
        RecalculateCleanRatingPoints();
    }

    #region FindGarbage
    int FindGarbageInScene()
    {
        var foundGarbageObjects = FindObjectsOfType<Litter>();
        return foundGarbageObjects.Length;
    }

    #endregion

    #region CleanRating

    public float GetCleanRatingPoints()
    { return CleanRatingPoints.Get(); }
    public float ZeroDownCleanRating()
    {
        return CleanRatingPoints.Set(0);
    }


    public float IncreaseCleanRatingPoints(float num)
    {
        return CleanRatingPoints.Set(Mathf.Clamp(CleanRatingPoints.Get() + num, 0, MaxCleaningnessLevelPoints));
    }

    public float DecreaseCleanRatingPoints(float num)
    {
        return CleanRatingPoints.Set(Mathf.Clamp(CleanRatingPoints.Get() - num, 0, MaxCleaningnessLevelPoints));
    }

    public float RecalculateCleanRatingPoints()
    {
       AmountOfGarbageInScene = FindGarbageInScene();
       float curPoints = MaxCleaningnessLevelPoints - AmountOfGarbageInScene;
       return CleanRatingPoints.Set(Mathf.Clamp(curPoints, 0, MaxCleaningnessLevelPoints));
    }

    #endregion

}
