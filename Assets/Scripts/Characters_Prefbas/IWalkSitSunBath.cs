
public interface IWalk
{
    bool GetIsWalking();
}

public interface ISit
{
    bool GetIsSitting();
}

public interface IWalkSit : IWalk, ISit
{
}

public interface ISunBath
{
    bool GetIsSunBathing();
}

public interface IWalkSitSunBath : IWalkSit, ISunBath
{
}