using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Regex_Format_1_Event
public class Script_1
{
    // Example properties and methods for Script_1
    public string Name { get; set; }

    public void Execute()
    {
        Debug.Log($"Executing {Name}");
    }
}

public class Script_2
{
    // Example properties and methods for Script_2
    public int Value { get; set; }

    public void Perform()
    {
        Debug.Log($"Performing with value {Value}");
    }
}

public class Script_Execution
{
    public Script_1 _Script_1;
    public Script_2 _Script_2;

    public Dictionary<string, object> Dict_Script_Target;

    public Script_Execution()
    {
        // Initialize the scripts
        _Script_1 = new Script_1 { Name = "Script One" };
        _Script_2 = new Script_2 { Value = 42 };

        // Initialize the dictionary
        Dict_Script_Target = new Dictionary<string, object>();

        // Add the scripts to the dictionary
        Dict_Script_Target.Add("script1", _Script_1);
        Dict_Script_Target.Add("script2", _Script_2);
    }

    public void ExecuteScripts()
    {
        foreach (var item in Dict_Script_Target)
        {
            if (item.Value is Script_1 script1)
            {
                script1.Execute();
            }
            else if (item.Value is Script_2 script2)
            {
                script2.Perform();
            }
        }
    }

    public static void Main(string[] args)
    {
        Script_Execution example = new Script_Execution();
        example.ExecuteScripts();
    }
}
