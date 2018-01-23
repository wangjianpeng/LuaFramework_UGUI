using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class JsonTutorial : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
           Stopwatch st = new Stopwatch();
           
            var parent = new Parent1();
            parent.Child1s = new Child1[100];
            for (int i = 0; i < 100; i++)
            {
                Child1 child1 = new Child1()
                {
                    name = "child "+i,
                    num = new int[] {i},
                };
                parent.Child1s[i]=child1;
            }
            st.Start();
           var s2=JsonConvert.SerializeObject(parent);
            st.Stop();
            File.WriteAllText(Path.Combine(Application.persistentDataPath,"jsonnet.txt"),s2);
            Debug.LogWarning($"time is {st.ElapsedMilliseconds} {s2}");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Stopwatch st = new Stopwatch();
            
            var parent = new Parent1();
            parent.Child1s = new Child1[100];
            for (int i = 0; i < 100; i++)
            {
                Child1 child1 = new Child1()
                {
                    name = "child " + i,
                    num = new int[] { i },
                };
                parent.Child1s[i] = child1;
            }
            st.Start();
            var s1=JsonUtility.ToJson(parent);
            st.Stop();
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "jsonunity.txt"), s1);
            Debug.LogWarning($"time is {st.ElapsedMilliseconds}  {s1}");
        }
    }
}

[Serializable]
public class Child1
{
    public int[] num;
    public string name;
}

[Serializable]
public class Parent1
{
    public Child1[] Child1s;
}
