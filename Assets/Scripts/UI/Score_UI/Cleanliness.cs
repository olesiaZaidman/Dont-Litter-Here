using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanliness : MonoBehaviour
{
    public static Cleanliness Instance;
    CleanIndicatorUI cleanlinessUI;
    public float MaxCleaningnessLevelPoints { get { return 10; } }
    static float amountOfGarbageInScene; //Make it private with getter!
    public float amGarbInScene;

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
        SetStartCleanRatingPoints();
    }

    void Update()
    {
        amountOfGarbageInScene = FindGarbageInScene();
        amGarbInScene = amountOfGarbageInScene;

        UpdateCleanRatingPoints();

        if (GetCleanRatingPoints() <= 0)
        {
            ZeroDownCleanRating();
        }
       // UpdateFill(1);

    }


    public float ZeroDownCleanRating()
    {
        //TODO: call ZeroFill() from CleanIndicatorUI with delegate with GAME OVER
        return CleanRatingPoints.Set(0);
    }


    #region FindGarbage
    int FindGarbageInScene()
    {
        //Calculate Amount of garbage in the scene:
        var foundGarbageObjects = FindObjectsOfType<Litter>();
        //   Debug.Log(foundGarbageObjects + " : " + foundGarbageObjects.Length);
        return foundGarbageObjects.Length;
    }

    #endregion

    #region CleanRating
    void SetStartCleanRatingPoints()
    {
        CleanRatingPoints.Set(MaxCleaningnessLevelPoints - amountOfGarbageInScene);
        //Debug.Log("Start for cleanRatingPoints: " + cleanRatingPoints);
    }

    public float GetCleanRatingPoints()
    { return CleanRatingPoints.Get(); }

    public void UpdateCleanRatingPoints()
    {
        if (CleanRatingPoints.Get() < 0)
        {
            ZeroDownCleanRating(); //gameover should be inside?

            //GAMEOVER
            //   return cleanRatingPoints;
        }
        else
        {
            CleanRatingPoints.Set(MaxCleaningnessLevelPoints - amountOfGarbageInScene);
            //  Debug.Log("damn garbage!: " + cleanRatingPoints);
            // return cleanRatingPoints;
        }
    }
    #endregion

    public void DecreaseFill() //Spawn() in Spawn() 
    {
       UpdateCleanRatingPoints();

        if (CleanRatingPoints.Get() <= 0)
        {
            ZeroDownCleanRating();
        }

      //  UpdateFill(1);
    }

    public void IncreaseFill()
    {
       UpdateCleanRatingPoints();
      //  UpdateFill(1);
    }




    //    //DestroyGarbageOnCleaningAnimationState() in PlayerGarbageDestroyer:
    //    //float cleanPoint = 2f;

    //    //if (fillValue >= 0)
    //    //{
    //    //    if (fillValue < maxFillValue)
    //    //    {
    //    //        fillValue += cleanPoint;

    //    //        if (fillValue > maxFillValue)
    //    //        { fillValue = maxFillValue; }
    //    //    }
    //    //    else //(fillValue > maxFillValue)
    //    //    {
    //    //        fillValue = maxFillValue;
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    ZeroFill();
    //    //}

    //}

}
