using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QValueStore : MonoBehaviour
{
    private Dictionary<GameState, Dictionary<GameAction, float>> store;

    public QValueStore()
    {
        store = new Dictionary<GameState, Dictionary<GameAction, float>>();
    }

    public virtual float GetQValue(GameState s, GameAction a)
    {
        return 0f;
    }

    public virtual GameAction GetBestAction(GameState s)
    {
        return new GameAction();
    }

    public void StoreQValue(GameState s,GameAction a,float val)
    {
        if (!store.ContainsKey(s))
        {
            Dictionary<GameAction, float> d;
            d = new Dictionary<GameAction, float>();
            store.Add(s, d);
        }

        if (!store[s].ContainsKey(a))
        {
            store[s].Add(a, 0f);
        }

        store[s][a] = val;
    }
}
