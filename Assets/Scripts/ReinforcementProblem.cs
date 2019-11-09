using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinforcementProblem
{
    

    public virtual GameState GetRandomState()
    {
        return new GameState();
    }

    public virtual GameAction[] GetAvailableActions(GameState s)
    {
        return null;
    }

    public virtual GameState TakeAction(GameState s, GameAction a, ref float reward)
    {
        reward = 0f;
        return new GameState();
    }

}

public struct GameState
{

}

public struct GameAction
{

}