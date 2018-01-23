using UnityEngine;
using LuaInterface;
using System;

public class HelloWorld : MonoBehaviour
{
    private string hello1 = $"hi, this is hello1";
    void Awake()
    {
        LuaState lua = new LuaState();
        lua.Start();
        string hello =
            @"                
                print('hello tolua#')                                  
            ";

        string myhello2 = $"print('wjp , come here')";
        string myhello3 = $"print('wjp , come here this is what you to do')";

        lua.DoString(hello, "HelloWorld.cs");
        lua.DoString(myhello2,"HelloWorld.cs");
        lua.DoString(myhello3,"HelloWorld.cs");
        //lua.DoString(hello1,"HelloWorld.cs");

        lua.CheckTop();
        lua.Dispose();
        lua = null;
    }
}
