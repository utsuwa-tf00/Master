using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteNameIdentification : MonoBehaviour
{
    public static bool C(string note)
    {
        if(note == "C1" || note == "C2" || note == "C3" || note == "C4" || note == "C5" || note == "C6" || note == "C7" || note == "C8")return true;
        return false;
    }

    public static bool Cs(string note)
    {
        if(note == "C#1" || note == "C#2" || note == "C#3" || note == "C#4" || note == "C#5" || note == "C#6" || note == "C#7")return true;
        return false;
    }

    public static bool D(string note)
    {
        if(note == "D1" || note == "D2" || note == "D3" || note == "D4" || note == "D5" || note == "D6" || note == "D7")return true;
        return false;    }

    public static bool Ds(string note)
    {
        if(note == "D#1" || note == "D#2" || note == "D#3" || note == "D#4" || note == "D#5" || note == "D#6" || note == "D#7")return true;
        return false;
    }

    public static bool E(string note)
    {
        if(note == "E1" || note == "E2" || note == "E3" || note == "E4" || note == "E5" || note == "E6" || note == "E7")return true;
        return false;
    }

    public static bool F(string note)
    {
        if(note == "F1" || note == "F2" || note == "F3" || note == "F4" || note == "F5" || note == "F6" || note == "F7")return true;
        return false;
    }

    public static bool Fs(string note)
    {
        if(note == "F#1" || note == "F#2" || note == "F#3" || note == "F#4" || note == "F#5" || note == "F#6" || note == "F#7")return true;
        return false;
    }

    public static bool G(string note)
    {
        if(note == "G1" || note == "G2" || note == "G3" || note == "G4" || note == "G5" || note == "G6" || note == "G7")return true;
        return false;
    }

    public static bool Gs(string note)
    {
        if(note == "G#1" || note == "G#2" || note == "G#3" || note == "G#4" || note == "G#5" || note == "G#6" || note == "G#7")return true;
        return false;
    }

    public static bool A(string note)
    {
        if(note == "A0" || note == "A1" || note == "A2" || note == "A3" || note == "A4" || note == "A5" || note == "A6" || note == "A7")return true;
        return false;
    }

    public static bool As(string note)
    {
        if(note == "A#0" || note == "A#1" || note == "A#2" || note == "A#3" || note == "A#4" || note == "A#5" || note == "A#6" || note == "A#7")return true;
        return false;
    }

    public static bool B(string note)
    {
        if(note == "B0" || note == "B1" || note == "B2" || note == "B3" || note == "B4" || note == "B5" || note == "B6" || note == "B7")return true;
        return false;
    }

    public static int Pitch(string note)
    {
        if(note == "A0" || note == "A#0" || note == "B0")return 0;
        else if(note == "C1" || note == "C#1" || note == "D1" || note == "D#1" || note == "E1" || note == "F1" || note == "F#1" || note == "G1" || note == "G#1" || note == "A1" || note == "A#1" || note == "B1")return 1;
        else if(note == "C2" || note == "C#2" || note == "D2" || note == "D#2" || note == "E2" || note == "F2" || note == "F#2" || note == "G2" || note == "G#2" || note == "A2" || note == "A#2" || note == "B2")return 2;
        else if(note == "C3" || note == "C#3" || note == "D3" || note == "D#3" || note == "E3" || note == "F3" || note == "F#3" || note == "G3" || note == "G#3" || note == "A3" || note == "A#3" || note == "B3")return 3;
        else if(note == "C4" || note == "C#4" || note == "D4" || note == "D#4" || note == "E4" || note == "F4" || note == "F#4" || note == "G4" || note == "G#4" || note == "A4" || note == "A#4" || note == "B4")return 4;
        else if(note == "C5" || note == "C#5" || note == "D5" || note == "D#5" || note == "E5" || note == "F5" || note == "F#5" || note == "G5" || note == "G#5" || note == "A5" || note == "A#5" || note == "B5")return 5;
        else if(note == "C6" || note == "C#6" || note == "D6" || note == "D#6" || note == "E6" || note == "F6" || note == "F#6" || note == "G6" || note == "G#6" || note == "A6" || note == "A#6" || note == "B6")return 6;
        else if(note == "C7" || note == "C#7" || note == "D7" || note == "D#7" || note == "E7" || note == "F7" || note == "F#7" || note == "G7" || note == "G#7" || note == "A7" || note == "A#7" || note == "B7")return 7;
        else if(note == "C8")return 8;
        return 0;
    }

    public static string Back(string note)
    {
        switch(note)
        {
            case "C":
                return "C3";
                break;
            case "C#":
                return "C#3";
                break;
            case "D":
                return "D3";
                break;
            case "D#":
                return "D#3";
                break;
            case "E":
                return "E3";
                break;
            case "F":
                return "F3";
                break;
            case "F#":
                return "F#3";
                break;
            case "G":
                return "G3";
                break;
            case "G#":
                return "G#3";
                break;
            case "A":
                return "A3";
                break;
            case "A#":
                return "A#3";
                break;
            case "B":
                return "B3";
                break;
            default:
                return "";
                break;
        }
    }
}
