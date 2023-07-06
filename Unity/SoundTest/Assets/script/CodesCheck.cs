using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CodesCheck : MonoBehaviour
{
    public ScoreRecorder scoreRecorder;
    private bool scoreDataUpdate = false;
    private List<string> score = new List<string>();
    private int numberOfBars = 4;
    private List<string> notes = new List<string>(){"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
    public List<List<string>> backScore = new List<List<string>>();
    
    private List<List<string>> codes = new List<List<string>>();

    private List<List<string>> codesC = new List<List<string>>();
    private List<List<string>> codesCs = new List<List<string>>();
    private List<List<string>> codesD = new List<List<string>>();
    private List<List<string>> codesDs = new List<List<string>>();
    private List<List<string>> codesE = new List<List<string>>();
    private List<List<string>> codesF = new List<List<string>>();
    private List<List<string>> codesFs = new List<List<string>>();
    private List<List<string>> codesG = new List<List<string>>();
    private List<List<string>> codesGs = new List<List<string>>();
    private List<List<string>> codesA = new List<List<string>>();
    private List<List<string>> codesAs = new List<List<string>>();
    private List<List<string>> codesB = new List<List<string>>();

    // codeC --------------------------------------------------------------------------------
    private List<string> codeC = new List<string>();
    private List<string> codeCm = new List<string>();
    private List<string> codeCaug = new List<string>();
    //rivate List<string> codeC6 = new List<string>();
    //private List<string> codeCm6 = new List<string>();
    private List<string> codeCM7 = new List<string>();
    //private List<string> codeCmM7 = new List<string>();
    private List<string> codeC7 = new List<string>();
    private List<string> codeCm7 = new List<string>();
    //private List<string> codeCaug7 = new List<string>();
    private List<string> codeCm7_5 = new List<string>();
    //private List<string> codeC9 = new List<string>();
    //private List<string> codeCm9 = new List<string>();
    private List<string> codeCdim = new List<string>();
    private List<string> codeCdim7 = new List<string>();
    //private List<string> codeCsus4 = new List<string>();
    //private List<string> codeC7sus4 = new List<string>();
    //private List<string> codeCadd9 = new List<string>();

    // codeDb --------------------------------------------------------------------------------
    private List<string> codeDb = new List<string>();
    private List<string> codeDbm = new List<string>();
    private List<string> codeDbaug = new List<string>();
    //private List<string> codeDb6 = new List<string>();
    //private List<string> codeDbm6 = new List<string>();
    private List<string> codeDbM7 = new List<string>();
    //private List<string> codeDbmM7 = new List<string>();
    private List<string> codeDb7 = new List<string>();
    private List<string> codeDbm7 = new List<string>();
    //private List<string> codeDbaug7 = new List<string>();
    private List<string> codeDbm7_5 = new List<string>();
    //private List<string> codeDb9 = new List<string>();
    //private List<string> codeDbm9 = new List<string>();
    private List<string> codeDbdim = new List<string>();
    private List<string> codeDbdim7 = new List<string>();
    //private List<string> codeDbsus4 = new List<string>();
    //private List<string> codeDb7sus4 = new List<string>();
    //private List<string> codeDbadd9 = new List<string>();

    // codeD --------------------------------------------------------------------------------
    private List<string> codeD = new List<string>();
    private List<string> codeDm = new List<string>();
    private List<string> codeDaug = new List<string>();
    //private List<string> codeD6 = new List<string>();
    //private List<string> codeDm6 = new List<string>();
    private List<string> codeDM7 = new List<string>();
    //private List<string> codeDmM7 = new List<string>();
    private List<string> codeD7 = new List<string>();
    private List<string> codeDm7 = new List<string>();
    //private List<string> codeDaug7 = new List<string>();
    private List<string> codeDm7_5 = new List<string>();
    //private List<string> codeD9 = new List<string>();
    //private List<string> codeDm9 = new List<string>();
    private List<string> codeDdim = new List<string>();
    private List<string> codeDdim7 = new List<string>();
    //private List<string> codeDsus4 = new List<string>();
    //private List<string> codeD7sus4 = new List<string>();
    //private List<string> codeDadd9 = new List<string>();

    // codeEb --------------------------------------------------------------------------------
    private List<string> codeEb = new List<string>();
    private List<string> codeEbm = new List<string>();
    private List<string> codeEbaug = new List<string>();
    //private List<string> codeEb6 = new List<string>();
    //private List<string> codeEbm6 = new List<string>();
    private List<string> codeEbM7 = new List<string>();
    //private List<string> codeEbmM7 = new List<string>();
    private List<string> codeEb7 = new List<string>();
    private List<string> codeEbm7 = new List<string>();
    //private List<string> codeEbaug7 = new List<string>();
    private List<string> codeEbm7_5 = new List<string>();
    //private List<string> codeEb9 = new List<string>();
    //private List<string> codeEbm9 = new List<string>();
    private List<string> codeEbdim = new List<string>();
    private List<string> codeEbdim7 = new List<string>();
    //private List<string> codeEbsus4 = new List<string>();
    //private List<string> codeEb7sus4 = new List<string>();
    //private List<string> codeEbadd9 = new List<string>();

    // codeE --------------------------------------------------------------------------------
    private List<string> codeE = new List<string>();
    private List<string> codeEm = new List<string>();
    private List<string> codeEaug = new List<string>();
    //private List<string> codeE6 = new List<string>();
    //private List<string> codeEm6 = new List<string>();
    private List<string> codeEM7 = new List<string>();
    //private List<string> codeEmM7 = new List<string>();
    private List<string> codeE7 = new List<string>();
    private List<string> codeEm7 = new List<string>();
    //private List<string> codeEaug7 = new List<string>();
    private List<string> codeEm7_5 = new List<string>();
    //private List<string> codeE9 = new List<string>();
    //private List<string> codeEm9 = new List<string>();
    private List<string> codeEdim = new List<string>();
    private List<string> codeEdim7 = new List<string>();
    //private List<string> codeEsus4 = new List<string>();
    //private List<string> codeE7sus4 = new List<string>();
    //private List<string> codeEadd9 = new List<string>();

    // codeF --------------------------------------------------------------------------------
    private List<string> codeF = new List<string>();
    private List<string> codeFm = new List<string>();
    private List<string> codeFaug = new List<string>();
    //private List<string> codeF6 = new List<string>();
    //private List<string> codeFm6 = new List<string>();
    private List<string> codeFM7 = new List<string>();
    //private List<string> codeFmM7 = new List<string>();
    private List<string> codeF7 = new List<string>();
    private List<string> codeFm7 = new List<string>();
    //private List<string> codeFaug7 = new List<string>();
    private List<string> codeFm7_5 = new List<string>();
    //private List<string> codeF9 = new List<string>();
    //private List<string> codeFm9 = new List<string>();
    private List<string> codeFdim = new List<string>();
    private List<string> codeFdim7 = new List<string>();
    //private List<string> codeFsus4 = new List<string>();
    //private List<string> codeF7sus4 = new List<string>();
    //private List<string> codeFadd9 = new List<string>();

    // codeFs --------------------------------------------------------------------------------
    private List<string> codeFs = new List<string>();
    private List<string> codeFsm = new List<string>();
    private List<string> codeFsaug = new List<string>();
    //private List<string> codeFs6 = new List<string>();
    //private List<string> codeFsm6 = new List<string>();
    private List<string> codeFsM7 = new List<string>();
    //private List<string> codeFsmM7 = new List<string>();
    private List<string> codeFs7 = new List<string>();
    private List<string> codeFsm7 = new List<string>();
    //private List<string> codeFsaug7 = new List<string>();
    private List<string> codeFsm7_5 = new List<string>();
    //private List<string> codeFs9 = new List<string>();
    //private List<string> codeFsm9 = new List<string>();
    private List<string> codeFsdim = new List<string>();
    private List<string> codeFsdim7 = new List<string>();
    //private List<string> codeFssus4 = new List<string>();
    //private List<string> codeFs7sus4 = new List<string>();
    //private List<string> codeFsadd9 = new List<string>();

    // codeG --------------------------------------------------------------------------------
    private List<string> codeG = new List<string>();
    private List<string> codeGm = new List<string>();
    private List<string> codeGaug = new List<string>();
    //private List<string> codeG6 = new List<string>();
    //private List<string> codeGm6 = new List<string>();
    private List<string> codeGM7 = new List<string>();
    //private List<string> codeGmM7 = new List<string>();
    private List<string> codeG7 = new List<string>();
    private List<string> codeGm7 = new List<string>();
    //private List<string> codeGaug7 = new List<string>();
    private List<string> codeGm7_5 = new List<string>();
    //private List<string> codeG9 = new List<string>();
    //private List<string> codeGm9 = new List<string>();
    private List<string> codeGdim = new List<string>();
    private List<string> codeGdim7 = new List<string>();
    //private List<string> codeGsus4 = new List<string>();
    //private List<string> codeG7sus4 = new List<string>();
    //private List<string> codeGadd9 = new List<string>();

    // codeAb --------------------------------------------------------------------------------
    private List<string> codeAb = new List<string>();
    private List<string> codeAbm = new List<string>();
    private List<string> codeAbaug = new List<string>();
    //private List<string> codeAb6 = new List<string>();
    //private List<string> codeAbm6 = new List<string>();
    private List<string> codeAbM7 = new List<string>();
    //private List<string> codeAbmM7 = new List<string>();
    private List<string> codeAb7 = new List<string>();
    private List<string> codeAbm7 = new List<string>();
    //private List<string> codeAbaug7 = new List<string>();
    private List<string> codeAbm7_5 = new List<string>();
    //private List<string> codeAb9 = new List<string>();
    //private List<string> codeAbm9 = new List<string>();
    private List<string> codeAbdim = new List<string>();
    private List<string> codeAbdim7 = new List<string>();
    //private List<string> codeAbsus4 = new List<string>();
    //private List<string> codeAb7sus4 = new List<string>();
    //private List<string> codeAbadd9 = new List<string>();

    // codeA --------------------------------------------------------------------------------
    private List<string> codeA = new List<string>();
    private List<string> codeAm = new List<string>();
    private List<string> codeAaug = new List<string>();
    //private List<string> codeA6 = new List<string>();
    //private List<string> codeAm6 = new List<string>();
    private List<string> codeAM7 = new List<string>();
    //private List<string> codeAmM7 = new List<string>();
    private List<string> codeA7 = new List<string>();
    private List<string> codeAm7 = new List<string>();
    //private List<string> codeAaug7 = new List<string>();
    private List<string> codeAm7_5 = new List<string>();
    //private List<string> codeA9 = new List<string>();
    //private List<string> codeAm9 = new List<string>();
    private List<string> codeAdim = new List<string>();
    private List<string> codeAdim7 = new List<string>();
    //private List<string> codeAsus4 = new List<string>();
    //private List<string> codeA7sus4 = new List<string>();
    //private List<string> codeAadd9 = new List<string>();

    // codeBb --------------------------------------------------------------------------------
    private List<string> codeBb = new List<string>();
    private List<string> codeBbm = new List<string>();
    private List<string> codeBbaug = new List<string>();
    //private List<string> codeBb6 = new List<string>();
    //private List<string> codeBbm6 = new List<string>();
    private List<string> codeBbM7 = new List<string>();
    //private List<string> codeBbmM7 = new List<string>();
    private List<string> codeBb7 = new List<string>();
    private List<string> codeBbm7 = new List<string>();
    //private List<string> codeBbaug7 = new List<string>();
    private List<string> codeBbm7_5 = new List<string>();
    //private List<string> codeBb9 = new List<string>();
    //private List<string> codeBbm9 = new List<string>();
    private List<string> codeBbdim = new List<string>();
    private List<string> codeBbdim7 = new List<string>();
    //private List<string> codeBbsus4 = new List<string>();
    //private List<string> codeBb7sus4 = new List<string>();
    //private List<string> codeBbadd9 = new List<string>();

    // codeB --------------------------------------------------------------------------------
    private List<string> codeB = new List<string>();
    private List<string> codeBm = new List<string>();
    private List<string> codeBaug = new List<string>();
    //private List<string> codeB6 = new List<string>();
    //private List<string> codeBm6 = new List<string>();
    private List<string> codeBM7 = new List<string>();
    //private List<string> codeBmM7 = new List<string>();
    private List<string> codeB7 = new List<string>();
    private List<string> codeBm7 = new List<string>();
    //private List<string> codeBaug7 = new List<string>();
    private List<string> codeBm7_5 = new List<string>();
    //private List<string> codeB9 = new List<string>();
    //private List<string> codeBm9 = new List<string>();
    private List<string> codeBdim = new List<string>();
    private List<string> codeBdim7 = new List<string>();
    //private List<string> codeBsus4 = new List<string>();
    //private List<string> codeB7sus4 = new List<string>();
    //private List<string> codeBadd9 = new List<string>();


    
    // コードに音を設定する
    void InputCode(List<string> inputCode, string root, string codeType)
    {
        int number = 0;
        int rootNumber = 0;

        // 基本となる音の判定
        rootNumber = NoteNameToNumber(root);
        // コードごとの音数の判定
        number = CodeTypeToNoteNumber(codeType);
        
        for (int i = 0; i < number; i++)
        {
            inputCode.Add(NoteInputToCode(codeType, rootNumber, i));
        }
    }

    // 音名から数値に変換
    int NoteNameToNumber(string note)
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
            default:
                return 0;
                break;
        }
    }

    // コードタイプから音数を判定
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
                return 0;
                break;
        }
    }

    // 数値から音名に変換
    string NumberToNoteName(int number)
    {
        int num = number % 12;

        switch(num)
        {
            case 0:
                return "C";
                break;
            case 1:
                return "C#";
                break;
            case 2:
                return "D";
                break;
            case 3:
                return "D#";
                break;
            case 4:
                return "E";
                break;
            case 5:
                return "F";
                break;
            case 6:
                return "F#";
                break;
            case 7:
                return "G";
                break;
            case 8:
                return "G#";
                break;
            case 9:
                return "A";
                break;
            case 10:
                return "A#";
                break;
            case 11:
                return "B";
                break;
            default:
                return "";
        }
    }

    // 相対的な音の数値を出力
    string NoteInputToCode(string codeType, int root , int i)
    {
        switch (codeType)
        {
            case "default":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 4);
                else if(i == 2)return NumberToNoteName(root + 7);
                return "";
                break;
            case "m":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 3);
                else if(i == 2)return NumberToNoteName(root + 7);
                return "";
                break;
            case "aug":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 4);
                else if(i == 2)return NumberToNoteName(root + 8);
                return "";
                break;
            case "6":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 4);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 9);
                return "";
                break;
            case "m6":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 3);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 9);
                return "";
                break;
            case "M7":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 4);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 11);
                return "";
                break;
            case "mM7":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 3);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 11);
                return "";
                break;
            case "7":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 4);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 10);
                return "";
                break;
            case "m7":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 3);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 10);
                return "";
                break;
            case "aug7":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 4);
                else if(i == 2)return NumberToNoteName(root + 8);
                else if(i == 3)return NumberToNoteName(root + 10);
                return "";
                break;
            case "m7_5":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 3);
                else if(i == 2)return NumberToNoteName(root + 6);
                else if(i == 3)return NumberToNoteName(root + 10);
                return "";
                break;
            case "9":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 4);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 10);
                else if(i == 4)return NumberToNoteName(root + 14);
                return "";
                break;
            case "m9":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 3);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 10);
                else if(i == 4)return NumberToNoteName(root + 14);
                return "";
                break;
            case "dim":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 3);
                else if(i == 2)return NumberToNoteName(root + 6);
                return "";
                break;
            case "dim7":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 3);
                else if(i == 2)return NumberToNoteName(root + 6);
                else if(i == 3)return NumberToNoteName(root + 9);
                return "";
                break;
            case "sus4":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 5);
                else if(i == 2)return NumberToNoteName(root + 7);
                return "";
                break;
            case "7sus4":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 5);
                else if(i == 2)return NumberToNoteName(root + 7);
                else if(i == 3)return NumberToNoteName(root + 10);
                return "";
                break;
            case "add9":
                if(i == 0)return NumberToNoteName(root);
                else if(i == 1)return NumberToNoteName(root + 2);
                else if(i == 2)return NumberToNoteName(root + 4);
                else if(i == 3)return NumberToNoteName(root + 7);
                return "";
                break;
            default:
                return "";
                break;
        }
    }

    // Start内でListに音名を設定
    void InputCodeInStart()
    {
        InputCode(codeC, "C", "default");
        InputCode(codeCm, "C", "m");
        InputCode(codeCaug, "C", "aug");
        //InputCode(codeC6, "C", "6");
        //InputCode(codeCm6, "C", "m6");
        InputCode(codeCM7, "C", "M7");
        //InputCode(codeCmM7, "C", "mM7");
        InputCode(codeC7, "C", "7");
        InputCode(codeCm7, "C", "m7");
        //InputCode(codeCaug7, "C", "aug7");
        InputCode(codeCm7_5, "C", "m7_5");
        //InputCode(codeC9, "C", "9");
        //InputCode(codeCm9, "C", "m9");
        InputCode(codeCdim, "C", "dim");
        InputCode(codeCdim7, "C", "dim7");
        //InputCode(codeCsus4, "C", "sus4");
        //InputCode(codeC7sus4, "C", "7sus4");
        //InputCode(codeCadd9, "C", "add9");

        InputCode(codeDb, "C#", "default");
        InputCode(codeDbm, "C#", "m");
        InputCode(codeDbaug, "C#", "aug");
        //InputCode(codeDb6, "C#", "6");
        //InputCode(codeDbm6, "C#", "m6");
        InputCode(codeDbM7, "C#", "M7");
        //InputCode(codeDbmM7, "C#", "mM7");
        InputCode(codeDb7, "C#", "7");
        InputCode(codeDbm7, "C#", "m7");
        //InputCode(codeDbaug7, "C#", "aug7");
        InputCode(codeDbm7_5, "C#", "m7_5");
        //InputCode(codeDb9, "C#", "9");
        //InputCode(codeDbm9, "C#", "m9");
        InputCode(codeDbdim, "C#", "dim");
        InputCode(codeDbdim7, "C#", "dim7");
        //InputCode(codeDbsus4, "C#", "sus4");
        //InputCode(codeDb7sus4, "C#", "7sus4");
        //InputCode(codeDbadd9, "C#", "add9");

        InputCode(codeD, "D", "default");
        InputCode(codeDm, "D", "m");
        InputCode(codeDaug, "D", "aug");
        //InputCode(codeD6, "D", "6");
        //InputCode(codeDm6, "D", "m6");
        InputCode(codeDM7, "D", "M7");
        //InputCode(codeDmM7, "D", "mM7");
        InputCode(codeD7, "D", "7");
        InputCode(codeDm7, "D", "m7");
        //InputCode(codeDaug7, "D", "aug7");
        InputCode(codeDm7_5, "D", "m7_5");
        //InputCode(codeD9, "D", "9");
        //InputCode(codeDm9, "D", "m9");
        InputCode(codeDdim, "D", "dim");
        InputCode(codeDdim7, "D", "dim7");
        //InputCode(codeDsus4, "D", "sus4");
        //InputCode(codeD7sus4, "D", "7sus4");
        //InputCode(codeDadd9, "D", "add9");

        InputCode(codeEb, "D#", "default");
        InputCode(codeEbm, "D#", "m");
        InputCode(codeEbaug, "D#", "aug");
        //InputCode(codeEb6, "D#", "6");
        //InputCode(codeEbm6, "D#", "m6");
        InputCode(codeEbM7, "D#", "M7");
        //InputCode(codeEbmM7, "D#", "mM7");
        InputCode(codeEb7, "D#", "7");
        InputCode(codeEbm7, "D#", "m7");
        //InputCode(codeEbaug7, "D#", "aug7");
        InputCode(codeEbm7_5, "D#", "m7_5");
        //InputCode(codeEb9, "D#", "9");
        //InputCode(codeEbm9, "D#", "m9");
        InputCode(codeEbdim, "D#", "dim");
        InputCode(codeEbdim7, "D#", "dim7");
        //InputCode(codeEbsus4, "D#", "sus4");
        //InputCode(codeEb7sus4, "D#", "7sus4");
        //InputCode(codeEbadd9, "D#", "add9");

        InputCode(codeE, "E", "default");
        InputCode(codeEm, "E", "m");
        InputCode(codeEaug, "E", "aug");
        //InputCode(codeE6, "E", "6");
        //InputCode(codeEm6, "E", "m6");
        InputCode(codeEM7, "E", "M7");
        //InputCode(codeEmM7, "E", "mM7");
        InputCode(codeE7, "E", "7");
        InputCode(codeEm7, "E", "m7");
        //InputCode(codeEaug7, "E", "aug7");
        InputCode(codeEm7_5, "E", "m7_5");
        //InputCode(codeE9, "E", "9");
        //InputCode(codeEm9, "E", "m9");
        InputCode(codeEdim, "E", "dim");
        InputCode(codeEdim7, "E", "dim7");
        //InputCode(codeEsus4, "E", "sus4");
        //InputCode(codeE7sus4, "E", "7sus4");
        //InputCode(codeEadd9, "E", "add9");

        InputCode(codeF, "F", "default");
        InputCode(codeFm, "F", "m");
        InputCode(codeFaug, "F", "aug");
        //InputCode(codeF6, "F", "6");
        //InputCode(codeFm6, "F", "m6");
        InputCode(codeFM7, "F", "M7");
        //InputCode(codeFmM7, "F", "mM7");
        InputCode(codeF7, "F", "7");
        InputCode(codeFm7, "F", "m7");
        //InputCode(codeFaug7, "F", "aug7");
        InputCode(codeFm7_5, "F", "m7_5");
        //InputCode(codeF9, "F", "9");
        //InputCode(codeFm9, "F", "m9");
        InputCode(codeFdim, "F", "dim");
        InputCode(codeFdim7, "F", "dim7");
        //InputCode(codeFsus4, "F", "sus4");
        //InputCode(codeF7sus4, "F", "7sus4");
        //InputCode(codeFadd9, "F", "add9");

        InputCode(codeFs, "F#", "default");
        InputCode(codeFsm, "F#", "m");
        InputCode(codeFsaug, "F#", "aug");
        //InputCode(codeFs6, "F#", "6");
        //InputCode(codeFsm6, "F#", "m6");
        InputCode(codeFsM7, "F#", "M7");
        //InputCode(codeFsmM7, "F#", "mM7");
        InputCode(codeFs7, "F#", "7");
        InputCode(codeFsm7, "F#", "m7");
        //InputCode(codeFsaug7, "F#", "aug7");
        InputCode(codeFsm7_5, "F#", "m7_5");
        //InputCode(codeFs9, "F#", "9");
        //InputCode(codeFsm9, "F#", "m9");
        InputCode(codeFsdim, "F#", "dim");
        InputCode(codeFsdim7, "F#", "dim7");
        //InputCode(codeFssus4, "F#", "sus4");
        //InputCode(codeFs7sus4, "F#", "7sus4");
        //InputCode(codeFsadd9, "F#", "add9");

        InputCode(codeG, "G", "default");
        InputCode(codeGm, "G", "m");
        InputCode(codeGaug, "G", "aug");
        //InputCode(codeG6, "G", "6");
        //InputCode(codeGm6, "G", "m6");
        InputCode(codeGM7, "G", "M7");
        //InputCode(codeGmM7, "G", "mM7");
        InputCode(codeG7, "G", "7");
        InputCode(codeGm7, "G", "m7");
        //InputCode(codeGaug7, "G", "aug7");
        InputCode(codeGm7_5, "G", "m7_5");
        //InputCode(codeG9, "G", "9");
        //InputCode(codeGm9, "G", "m9");
        InputCode(codeGdim, "G", "dim");
        InputCode(codeGdim7, "G", "dim7");
        //InputCode(codeGsus4, "G", "sus4");
        //InputCode(codeG7sus4, "G", "7sus4");
        //InputCode(codeGadd9, "G", "add9");

        InputCode(codeAb, "G#", "default");
        InputCode(codeAbm, "G#", "m");
        InputCode(codeAbaug, "G#", "aug");
        //InputCode(codeAb6, "G#", "6");
        //InputCode(codeAbm6, "G#", "m6");
        InputCode(codeAbM7, "G#", "M7");
        //InputCode(codeAbmM7, "G#", "mM7");
        InputCode(codeAb7, "G#", "7");
        InputCode(codeAbm7, "G#", "m7");
        //InputCode(codeAbaug7, "G#", "aug7");
        InputCode(codeAbm7_5, "G#", "m7_5");
        //InputCode(codeAb9, "G#", "9");
        //InputCode(codeAbm9, "G#", "m9");
        InputCode(codeAbdim, "G#", "dim");
        InputCode(codeAbdim7, "G#", "dim7");
        //InputCode(codeAbsus4, "G#", "sus4");
        //InputCode(codeAb7sus4, "G#", "7sus4");
        //InputCode(codeAbadd9, "G#", "add9");

        InputCode(codeA, "A", "default");
        InputCode(codeAm, "A", "m");
        InputCode(codeAaug, "A", "aug");
        //InputCode(codeA6, "A", "6");
        //InputCode(codeAm6, "A", "m6");
        InputCode(codeAM7, "A", "M7");
        //InputCode(codeAmM7, "A", "mM7");
        InputCode(codeA7, "A", "7");
        InputCode(codeAm7, "A", "m7");
        //InputCode(codeAaug7, "A", "aug7");
        InputCode(codeAm7_5, "A", "m7_5");
        //InputCode(codeA9, "A", "9");
        //InputCode(codeAm9, "A", "m9");
        InputCode(codeAdim, "A", "dim");
        InputCode(codeAdim7, "A", "dim7");
        //InputCode(codeAsus4, "A", "sus4");
        //InputCode(codeA7sus4, "A", "7sus4");
        //InputCode(codeAadd9, "A", "add9");

        InputCode(codeBb, "A#", "default");
        InputCode(codeBbm, "A#", "m");
        InputCode(codeBbaug, "A#", "aug");
        //InputCode(codeBb6, "A#", "6");
        //InputCode(codeBbm6, "A#", "m6");
        InputCode(codeBbM7, "A#", "M7");
        //InputCode(codeBbmM7, "A#", "mM7");
        InputCode(codeBb7, "A#", "7");
        InputCode(codeBbm7, "A#", "m7");
        //InputCode(codeBbaug7, "A#", "aug7");
        InputCode(codeBbm7_5, "A#", "m7_5");
        //InputCode(codeBb9, "A#", "9");
        //InputCode(codeBbm9, "A#", "m9");
        InputCode(codeBbdim, "A#", "dim");
        InputCode(codeBbdim7, "A#", "dim7");
        //InputCode(codeBbsus4, "A#", "sus4");
        //InputCode(codeBb7sus4, "A#", "7sus4");
        //InputCode(codeBbadd9, "A#", "add9");

        InputCode(codeB, "B", "default");
        InputCode(codeBm, "B", "m");
        InputCode(codeBaug, "B", "aug");
        //InputCode(codeB6, "B", "6");
        //InputCode(codeBm6, "B", "m6");
        InputCode(codeBM7, "B", "M7");
        //InputCode(codeBmM7, "B", "mM7");
        InputCode(codeB7, "B", "7");
        InputCode(codeBm7, "B", "m7");
        //InputCode(codeBaug7, "B", "aug7");
        InputCode(codeBm7_5, "B", "m7_5");
        //InputCode(codeB9, "B", "9");
        //InputCode(codeBm9, "B", "m9");
        InputCode(codeBdim, "B", "dim");
        InputCode(codeBdim7, "B", "dim7");
        //InputCode(codeBsus4, "B", "sus4");
        //InputCode(codeB7sus4, "B", "7sus4");
        //InputCode(codeBadd9, "B", "add9");
    }

    // Start内でListにコードを設定
    void InputCodesInStart()
    {
        codesC.Add(codeC);
        codesC.Add(codeCm);
        codesC.Add(codeCaug);
        //codesC.Add(codeC6);
        //codesC.Add(codeCm6);
        codesC.Add(codeCM7);
        //codesC.Add(codeCmM7);
        codesC.Add(codeC7);
        codesC.Add(codeCm7);
        //codesC.Add(codeCaug7);
        codesC.Add(codeCm7_5);
        //codesC.Add(codeC9);
        //codesC.Add(codeCm9);
        codesC.Add(codeCdim);
        codesC.Add(codeCdim7);
        //codesC.Add(codeCsus4);
        //codesC.Add(codeC7sus4);
        //codesC.Add(codeCadd9);

        codesCs.Add(codeDb);
        codesCs.Add(codeDbm);
        codesCs.Add(codeDbaug);
        //codesCs.Add(codeDb6);
        //codesCs.Add(codeDbm6);
        codesCs.Add(codeDbM7);
        //codesCs.Add(codeDbmM7);
        codesCs.Add(codeDb7);
        codesCs.Add(codeDbm7);
        //codesCs.Add(codeDbaug7);
        codesCs.Add(codeDbm7_5);
        //codesCs.Add(codeDb9);
        //codesCs.Add(codeDbm9);
        codesCs.Add(codeDbdim);
        codesCs.Add(codeDbdim7);
        //codesCs.Add(codeDbsus4);
        //codesCs.Add(codeDb7sus4);
        //codesCs.Add(codeDbadd9);

        codesD.Add(codeD);
        codesD.Add(codeDm);
        codesD.Add(codeDaug);
        //codesD.Add(codeD6);
        //codesD.Add(codeDm6);
        codesD.Add(codeDM7);
        //codesD.Add(codeDmM7);
        codesD.Add(codeD7);
        codesD.Add(codeDm7);
        //codesD.Add(codeDaug7);
        codesD.Add(codeDm7_5);
        //codesD.Add(codeD9);
        //codesD.Add(codeDm9);
        codesD.Add(codeDdim);
        codesD.Add(codeDdim7);
        //codesD.Add(codeDsus4);
        //codesD.Add(codeD7sus4);
        //codesD.Add(codeDadd9);

        codesDs.Add(codeEb);
        codesDs.Add(codeEbm);
        codesDs.Add(codeEbaug);
        //codesDs.Add(codeEb6);
        //codesDs.Add(codeEbm6);
        codesDs.Add(codeEbM7);
        //codesDs.Add(codeEbmM7);
        codesDs.Add(codeEb7);
        codesDs.Add(codeEbm7);
        //codesDs.Add(codeEbaug7);
        codesDs.Add(codeEbm7_5);
        //codesDs.Add(codeEb9);
        //codesDs.Add(codeEbm9);
        codesDs.Add(codeEbdim);
        codesDs.Add(codeEbdim7);
        //codesDs.Add(codeEbsus4);
        //codesDs.Add(codeEb7sus4);
        //codesDs.Add(codeEbadd9);

        codesE.Add(codeE);
        codesE.Add(codeEm);
        codesE.Add(codeEaug);
        //codesE.Add(codeE6);
        //codesE.Add(codeEm6);
        codesE.Add(codeEM7);
        //codesE.Add(codeEmM7);
        codesE.Add(codeE7);
        codesE.Add(codeEm7);
        //codesE.Add(codeEaug7);
        codesE.Add(codeEm7_5);
        //codesE.Add(codeE9);
        //codesE.Add(codeEm9);
        codesE.Add(codeEdim);
        codesE.Add(codeEdim7);
        //codesE.Add(codeEsus4);
        //codesE.Add(codeE7sus4);
        //codesE.Add(codeEadd9);

        codesF.Add(codeF);
        codesF.Add(codeFm);
        codesF.Add(codeFaug);
        //codesF.Add(codeF6);
        //codesF.Add(codeFm6);
        codesF.Add(codeFM7);
        //codesF.Add(codeFmM7);
        codesF.Add(codeF7);
        codesF.Add(codeFm7);
        //codesF.Add(codeFaug7);
        codesF.Add(codeFm7_5);
        //codesF.Add(codeF9);
        //codesF.Add(codeFm9);
        codesF.Add(codeFdim);
        codesF.Add(codeFdim7);
        //codesF.Add(codeFsus4);
        //codesF.Add(codeF7sus4);
        //codesF.Add(codeFadd9);

        codesFs.Add(codeFs);
        codesFs.Add(codeFsm);
        codesFs.Add(codeFsaug);
        //codesFs.Add(codeFs6);
        //codesFs.Add(codeFsm6);
        codesFs.Add(codeFsM7);
        //codesFs.Add(codeFsmM7);
        codesFs.Add(codeFs7);
        codesFs.Add(codeFsm7);
        //codesFs.Add(codeFsaug7);
        codesFs.Add(codeFsm7_5);
        //codesFs.Add(codeFs9);
        //codesFs.Add(codeFsm9);
        codesFs.Add(codeFsdim);
        codesFs.Add(codeFsdim7);
        //codesFs.Add(codeFssus4);
        //codesFs.Add(codeFs7sus4);
        //codesFs.Add(codeFsadd9);

        codesG.Add(codeG);
        codesG.Add(codeGm);
        codesG.Add(codeGaug);
        //codesG.Add(codeG6);
        //codesG.Add(codeGm6);
        codesG.Add(codeGM7);
        //codesG.Add(codeGmM7);
        codesG.Add(codeG7);
        codesG.Add(codeGm7);
        //codesG.Add(codeGaug7);
        codesG.Add(codeGm7_5);
        //codesG.Add(codeG9);
        //codesG.Add(codeGm9);
        codesG.Add(codeGdim);
        codesG.Add(codeGdim7);
        //codesG.Add(codeGsus4);
        //codesG.Add(codeG7sus4);
        //codesG.Add(codeGadd9);

        codesGs.Add(codeAb);
        codesGs.Add(codeAbm);
        codesGs.Add(codeAbaug);
        //codesGs.Add(codeAb6);
        //codesGs.Add(codeAbm6);
        codesGs.Add(codeAbM7);
        //codesGs.Add(codeAbmM7);
        codesGs.Add(codeAb7);
        codesGs.Add(codeAbm7);
        //codesGs.Add(codeAbaug7);
        codesGs.Add(codeAbm7_5);
        //codesGs.Add(codeAb9);
        //codesGs.Add(codeAbm9);
        codesGs.Add(codeAbdim);
        codesGs.Add(codeAbdim7);
        //codesGs.Add(codeAbsus4);
        //codesGs.Add(codeAb7sus4);
        //codesGs.Add(codeAbadd9);

        codesA.Add(codeA);
        codesA.Add(codeAm);
        codesA.Add(codeAaug);
        //codesA.Add(codeA6);
        //codesA.Add(codeAm6);
        codesA.Add(codeAM7);
        //codesA.Add(codeAmM7);
        codesA.Add(codeA7);
        codesA.Add(codeAm7);
        //codesA.Add(codeAaug7);
        codesA.Add(codeAm7_5);
        //codesA.Add(codeA9);
        //codesA.Add(codeAm9);
        codesA.Add(codeAdim);
        codesA.Add(codeAdim7);
        //codesA.Add(codeAsus4);
        //codesA.Add(codeA7sus4);
        //codesA.Add(codeAadd9);

        codesAs.Add(codeBb);
        codesAs.Add(codeBbm);
        codesAs.Add(codeBbaug);
        //codesAs.Add(codeBb6);
        //codesAs.Add(codeBbm6);
        codesAs.Add(codeBbM7);
        //codesAs.Add(codeBbmM7);
        codesAs.Add(codeBb7);
        codesAs.Add(codeBbm7);
        //codesAs.Add(codeBbaug7);
        codesAs.Add(codeBbm7_5);
        //codesAs.Add(codeBb9);
        //codesAs.Add(codeBbm9);
        codesAs.Add(codeBbdim);
        codesAs.Add(codeBbdim7);
        //codesAs.Add(codeBbsus4);
        //codesAs.Add(codeBb7sus4);
        //codesAs.Add(codeBbadd9);

        codesB.Add(codeB);
        codesB.Add(codeBm);
        codesB.Add(codeBaug);
        //codesB.Add(codeB6);
        //codesB.Add(codeBm6);
        codesB.Add(codeBM7);
        //codesB.Add(codeBmM7);
        codesB.Add(codeB7);
        codesB.Add(codeBm7);
        //codesB.Add(codeBaug7);
        codesB.Add(codeBm7_5);
        //codesB.Add(codeB9);
        //codesB.Add(codeBm9);
        codesB.Add(codeBdim);
        codesB.Add(codeBdim7);
        //codesB.Add(codeBsus4);
        //codesB.Add(codeB7sus4);
        //codesB.Add(codeBadd9);
    }

    // スコアをscoreRecorderから取得、変換
    void GetScore()
    {
        for(int i = 0; i < scoreRecorder.melodyScore.Count; i++)
        {
            if(NoteNameIdentification.C(scoreRecorder.melodyScore[i]))score.Add("C");
            else if(NoteNameIdentification.Cs(scoreRecorder.melodyScore[i]))score.Add("C#");
            else if(NoteNameIdentification.D(scoreRecorder.melodyScore[i]))score.Add("D");
            else if(NoteNameIdentification.Ds(scoreRecorder.melodyScore[i]))score.Add("D#");
            else if(NoteNameIdentification.E(scoreRecorder.melodyScore[i]))score.Add("E");
            else if(NoteNameIdentification.F(scoreRecorder.melodyScore[i]))score.Add("F");
            else if(NoteNameIdentification.Fs(scoreRecorder.melodyScore[i]))score.Add("F#");
            else if(NoteNameIdentification.G(scoreRecorder.melodyScore[i]))score.Add("G");
            else if(NoteNameIdentification.Gs(scoreRecorder.melodyScore[i]))score.Add("G#");
            else if(NoteNameIdentification.A(scoreRecorder.melodyScore[i]))score.Add("A");
            else if(NoteNameIdentification.As(scoreRecorder.melodyScore[i]))score.Add("A#");
            else if(NoteNameIdentification.B(scoreRecorder.melodyScore[i]))score.Add("B");
            else score.Add("");
        } 
    }

    void ResetScore()
    {
        score = new List<string>();
    }

    void GetCode()
    {
        // 小節数分実行
        for(int i = 0; i < numberOfBars; i++)
        {
            // 一小節分のスコアを格納するList
            List<string> scoreOfBar = new List<string>();

            // 一小節分のスコアを格納
            for(int j = 0; j < scoreRecorder.beat*4; j++)
            {
                scoreOfBar.Add(score[scoreRecorder.beat*4 * i + j]);
            }

            List<List<string>> codesOfBar = CheckCodeArea(scoreOfBar);

            backScore.Add(CheckCodeConformance(scoreOfBar,codesOfBar));
        }
    }

    List<string> CheckCodeConformance(List<string> scoreOfBar, List<List<string>> codes)
    {
        float maxConformance = 0;
        List<List<string>> maxConformancecode = new List<List<string>>();

        // コードの数だけ実行
        for(int cds = 0; cds < codes.Count; cds++)
        {
            int count = 0;
            float confoumance = 0;
            
            // 一小節分実行
            for(int sb = 0; sb < scoreOfBar.Count; sb++)
            {
                // コードが保持する音数分実行
                for(int cd = 0; cd < codes[cds].Count; cd++)
                {
                    if(codes[cds][cd] == scoreOfBar[sb])count++;
                    //if(Regex.IsMatch(scoreOfBar[sb], Regex.Escape(codes[cds][cd])))count++; 
                }
            }
            
            if(codes[cds].Count != 0 && scoreOfBar.Count != 0)
            {
                // コードの１音あたりの合致率を計算
                confoumance = (float)(count / codes[cds].Count) / scoreOfBar.Count;

                if(confoumance > maxConformance)
                {
                    maxConformance = confoumance;
                    maxConformancecode.Clear();
                    maxConformancecode.Add(codes[cds]);
                }
                else if(confoumance == maxConformance)
                {
                    maxConformancecode.Add(codes[cds]);
                }
            }
        }
        
        if(maxConformancecode.Count < 0)return maxConformancecode[0];
        
        return maxConformancecode[UnityEngine.Random.Range(0, maxConformancecode.Count)];
    }
    
    List<List<string>> CheckCodeArea(List<string> scoreOfBar)
    {
        int maxCount = 0;
        List<string> noteName = new List<string>();
        string frequentNote = "";

        for(int n = 0; n < notes.Count; n++)
        {
            int count = 0;

            for(int sb = 0; sb < scoreOfBar.Count; sb++)
            {
                if(notes[n] == scoreOfBar[sb])count++;
                //if(Regex.IsMatch(scoreOfBar[sb], Regex.Escape(notes[n])))count++;
            }

            if(count > maxCount)
            {
                maxCount = count;
                noteName.Clear();
                noteName.Add(notes[n]);
            }
            else if(count == maxCount)
            {
                noteName.Add(notes[n]);
            }
        }
        
        frequentNote = noteName[UnityEngine.Random.Range(0, noteName.Count)];

        switch(frequentNote)
        {
            case "C" :
                return codesC;
                break;
            case "C#" :
                return codesCs;
                break;
            case "D" :
                return codesD;
                break;
            case "D#" :
                return codesDs;
                break;
            case "E" :
                return codesE;
                break;
            case "F" :
                return codesF;
                break;
            case "F#" :
                return codesFs;
                break;
            case "G" :
                return codesG;
                break;
            case "G#" :
                return codesGs;
                break;
            case "A" :
                return codesA;
                break;
            case "A#" :
                return codesAs;
                break;
            case "B" :
                return codesB;
                break;
            default:
                return codesC;
                break;
        }
    }
    
    void ResetCode()
    {
        backScore.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        InputCodeInStart();
        InputCodesInStart();
        numberOfBars = scoreRecorder.numberOfBars;
        ResetScore();
        ResetCode();
    }

    // Update is called once per frame
    void Update()
    {
        if(!scoreRecorder.mic)
        {
            if(scoreDataUpdate)
            {
                GetScore();
                GetCode();
                scoreDataUpdate = false;
            }
        }
        else
        {
            if(!scoreDataUpdate)
            {
                ResetScore();
                ResetCode();
                scoreDataUpdate = true;
            }
        }

    }
}
