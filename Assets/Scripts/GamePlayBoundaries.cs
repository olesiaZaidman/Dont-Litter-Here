
public static class GamePlayBoundaries 
{
    //Boundaries:
    public static float XRightBound
    {
        get { return 11.4f; }  // return private float xMaxRange = 11.4f;
    }
    public static float XLeftBound
    {
        get { return -11.8f; }  // return private float xMinRange = -11.8f;
    }
    public static float ZTopBound
    {
        get { return 4f; }  // return private float zMaxRange = 4f;
    }
    public static float ZBottomBound
    {
        get { return -16f; }  // return private float zMinRange = -16f;
    }


    //Boundaries For Characters WalkingArea:
    public static float XRighZToptWalkingAreaBound
    {
        get { return 30f; }  // return private float rightBound = 30f;
        // return private float topBound = 30f;
    }
    public static float XLeftZBottomWalkingAreaBound
    {
        get { return -20f; }  // return private float leftBound = -20f;
    }// return private float bottomBound = -20f;

}
