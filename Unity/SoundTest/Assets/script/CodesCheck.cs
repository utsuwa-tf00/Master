using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodesCheck : MonoBehaviour
{
    private List<List<string>> codes = new List<List<string>>();

    // C --------------------------------------------------------------------------------
    private List<string> C = new List<string>(){"C","E","G"};
    private List<string> Cm = new List<string>(){"C","D#","G"};
    private List<string> Caug = new List<string>(){"C","E","G#"};
    private List<string> C6 = new List<string>(){"C","E","G","A"};

    private List<string> Cm6 = new List<string>(){"C","D#","G","A"};
    private List<string> CM7 = new List<string>(){"C","E","G","B"};
    private List<string> CmM7 = new List<string>(){"C","D#","G","B"};
    private List<string> C7 = new List<string>(){"C","E","G","A#"};

    private List<string> Cm7 = new List<string>(){"C","D#","G","A#"};
    private List<string> Caug7 = new List<string>(){"C","E","G#","A#"};
    private List<string> Cm7_5 = new List<string>(){"C","D#","F#","A#"};
    private List<string> C9 = new List<string>(){"C","E","G","A#","D"};

    //private List<string> Cm9 = new List<string>(){"C","D#","G","A#","D"};
    private List<string> Cdim = new List<string>(){"C","D#","F#"};
    //private List<string> Cdim7 = new List<string>(){"C","D#","F#","A"};
    private List<string> Csus4 = new List<string>(){"C","F","G"};

    private List<string> C7sus4 = new List<string>(){"C","F","G","A#"};
    private List<string> Cadd9 = new List<string>(){"C","D","E","G"};

    // Db --------------------------------------------------------------------------------
    private List<string> Db = new List<string>(){"C#","F","G#"};
    private List<string> Dbm = new List<string>(){"C#","E","G#"};
    private List<string> Dbaug = new List<string>(){"C#","F","A"};
    private List<string> Db6 = new List<string>(){"C#","F","G#","A#"};

    private List<string> Dbm6 = new List<string>(){"C#","E","G#","A#"};
    private List<string> DbM7 = new List<string>(){"C#","F","G#","C"};
    private List<string> DbmM7 = new List<string>(){"C#","E","G#"};
    private List<string> Db7 = new List<string>(){"C#","F","G#"};

    private List<string> Dbm7 = new List<string>(){"C#","E","G#"};
    private List<string> Dbaug7 = new List<string>(){"C#","F","A"};
    private List<string> Dbm7_5 = new List<string>(){"C#","E","G"};
    private List<string> Db9 = new List<string>(){"C#","F","G#"};
    
    private List<string> Dbm9 = new List<string>(){"C#","F","G#"};
    private List<string> Dbdim = new List<string>(){"C#","E","G"};
    private List<string> Dbdim7 = new List<string>(){"C#","E","G"};
    private List<string> Dbsus4 = new List<string>(){"C#","F#","G#"};
    
    private List<string> Db7sus4 = new List<string>(){"C#","F#","G#"};
    private List<string> Dbadd9 = new List<string>(){"C#","D#","F"};

    void InputCode(List<string> inputCode, string root, string codeType)
    {
        int number = 0;
        int rootNumber = 0;
        int n2 = 0;
        int n3 = 0;
        int n4 = 0;
        int n5 = 0;

        rootNumber = NoteToNumber(root);
        number = CodeTypeToNoteNumber(codeType);
        
        for (int i = 0; i < number; i++)
        {

        }
    }

    int NoteToNumber(string note)
    {
        switch (note)
        {
            case "C" :
                return 0;
                break;
            case "C#" :
                return 1;
                break;
            case "D" :
                return 2;
                break;
            case "D#" :
                return 3;
                break;
            case "E" :
                return 4;
                break;
            case "F" :
                return 5;
                break;
            case "F#" :
                return 6;
                break;
            case "G" :
                return 7;
                break;
            case "G#" :
                return 8;
                break;
            case "A" :
                return 9;
                break;
            case "A#" :
                return 10;
                break;
            case "B" :
                return 11;
                break;
        }
    }

    int CodeTypeToNoteNumber(string codeType)
    {
        switch (codeType)
        {
            case "default":
                return 3;
                break;
            case "m":
                return 3;
                break;
            case "aug":
                return 3;
                break;
            case "6":
                return 4;
                break;
            case "m6":
                return 4;
                break;
            case "M7":
                return 4;
                break;
            case "mM7":
                return 4;
                break;
            case "7":
                return 4;
                break;
            case "m7":
                return 4;
                break;
            case "aug7":
                return 4;
                break;
            case "m7_5":
                return 4;
                break;
            case "9":
                return 5;
                break;
            case "m9":
                return 5;
                break;
            case "dim":
                return 3;
                break;
            case "dim7":
                return 4;
                break;
            case "sus4":
                return 3;
                break;
            case "7sus4":
                return 4;
                break;
            case "add9":
                return 4;
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
