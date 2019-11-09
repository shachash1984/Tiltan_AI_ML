using System.Collections;
using System.Collections.Generic;
using System.Text;


public class NGramPredictor<T>
{
    private int nValue;
    private Dictionary<string, KeyDataRecord<T>> data;

    public NGramPredictor(int windowSize)
    {
        nValue = windowSize ;
        data = new Dictionary<string, KeyDataRecord<T>>();
    }

    public static string ArrToStrKey(ref T action)
    {
        //StringBuilder builder = new StringBuilder();
        //foreach (T a in actions)
        //{
        //    builder.Append(a.ToString());
        //}
        //return builder.ToString();

        return action.ToString();
    }

    public void RegisterSequence(T action)
    {
        string key = ArrToStrKey(ref action);
        T val = action;

        if (!data.ContainsKey(key))
        {
            data[key] = new KeyDataRecord<T>();
        }

         KeyDataRecord<T> kdr = data[key];

        if (!kdr.counts.ContainsKey(val))
        {
            kdr.counts[val] = 1;
        }
        else
        {
            kdr.counts[val]++;
        }
         

        //if (kdr.counts.ContainsKey(val))
        //{
        //    kdr.counts[val] = 0;
        //}

        //kdr.counts[val]++;
        kdr.total++;
    }

    public T GetMostLikely(T[] actions)
    {
        int highestVal = 0;
        T bestAction = default(T);
        for (int i = 0; i < actions.Length; i++)
        {
            string key = NGramPredictor<T>.ArrToStrKey(ref actions[i]);
            foreach (KeyValuePair<T, int> kvp in data[key].counts)
            {
                if (kvp.Value > highestVal)
                {
                    bestAction = kvp.Key;
                    highestVal = kvp.Value;
                }
            }
        }
        
       
        //string key = ArrToStrKey(ref action);
        //KeyDataRecord<T> kdr = data[key];
        //int highestVal = 0;
        //T bestAction = default(T);
        //foreach (KeyValuePair<T, int> kvp in kdr.counts)
        //{
        //    if (kvp.Value > highestVal)
        //    {
        //        bestAction = kvp.Key;
        //        highestVal = kvp.Value;
        //    }
        //}
        return bestAction;
    }
}
