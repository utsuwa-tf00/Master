using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodesCheck : MonoBehaviour
{
    public ScoreRecorder scoreRecorder;
    private bool scoreDataUpdate = false;
    private List<string> score = new List<string>();
    private int numberOfBars = 4;
    public List<float> conformanceCheck = new List<float>();
    public List<string> code1 = new List<string>();
    public List<string> code2 = new List<string>();
    public List<string> code3 = new List<string>();
    public List<string> code4 = new List<string>();
    
    private List<List<string>> codes = new List<List<string>>();

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


    
    // Listに音を読み込む
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
        codes.Add(codeC);
        codes.Add(codeCm);
        codes.Add(codeCaug);
        //codes.Add(codeC6);
        //codes.Add(codeCm6);
        codes.Add(codeCM7);
        //codes.Add(codeCmM7);
        codes.Add(codeC7);
        codes.Add(codeCm7);
        //codes.Add(codeCaug7);
        codes.Add(codeCm7_5);
        //codes.Add(codeC9);
        //codes.Add(codeCm9);
        codes.Add(codeCdim);
        codes.Add(codeCdim7);
        //codes.Add(codeCsus4);
        //codes.Add(codeC7sus4);
        //codes.Add(codeCadd9);

        codes.Add(codeDb);
        codes.Add(codeDbm);
        codes.Add(codeDbaug);
        //codes.Add(codeDb6);
        //codes.Add(codeDbm6);
        codes.Add(codeDbM7);
        //codes.Add(codeDbmM7);
        codes.Add(codeDb7);
        codes.Add(codeDbm7);
        //codes.Add(codeDbaug7);
        codes.Add(codeDbm7_5);
        //codes.Add(codeDb9);
        //codes.Add(codeDbm9);
        codes.Add(codeDbdim);
        codes.Add(codeDbdim7);
        //codes.Add(codeDbsus4);
        //codes.Add(codeDb7sus4);
        //codes.Add(codeDbadd9);

        codes.Add(codeD);
        codes.Add(codeDm);
        codes.Add(codeDaug);
        //codes.Add(codeD6);
        //codes.Add(codeDm6);
        codes.Add(codeDM7);
        //codes.Add(codeDmM7);
        codes.Add(codeD7);
        codes.Add(codeDm7);
        //codes.Add(codeDaug7);
        codes.Add(codeDm7_5);
        //codes.Add(codeD9);
        //codes.Add(codeDm9);
        codes.Add(codeDdim);
        codes.Add(codeDdim7);
        //codes.Add(codeDsus4);
        //codes.Add(codeD7sus4);
        //codes.Add(codeDadd9);

        codes.Add(codeEb);
        codes.Add(codeEbm);
        codes.Add(codeEbaug);
        //codes.Add(codeEb6);
        //codes.Add(codeEbm6);
        codes.Add(codeEbM7);
        //codes.Add(codeEbmM7);
        codes.Add(codeEb7);
        codes.Add(codeEbm7);
        //codes.Add(codeEbaug7);
        codes.Add(codeEbm7_5);
        //codes.Add(codeEb9);
        //codes.Add(codeEbm9);
        codes.Add(codeEbdim);
        codes.Add(codeEbdim7);
        //codes.Add(codeEbsus4);
        //codes.Add(codeEb7sus4);
        //codes.Add(codeEbadd9);

        codes.Add(codeE);
        codes.Add(codeEm);
        codes.Add(codeEaug);
        //codes.Add(codeE6);
        //codes.Add(codeEm6);
        codes.Add(codeEM7);
        //codes.Add(codeEmM7);
        codes.Add(codeE7);
        codes.Add(codeEm7);
        //codes.Add(codeEaug7);
        codes.Add(codeEm7_5);
        //codes.Add(codeE9);
        //codes.Add(codeEm9);
        codes.Add(codeEdim);
        codes.Add(codeEdim7);
        //codes.Add(codeEsus4);
        //codes.Add(codeE7sus4);
        //codes.Add(codeEadd9);

        codes.Add(codeF);
        codes.Add(codeFm);
        codes.Add(codeFaug);
        //codes.Add(codeF6);
        //codes.Add(codeFm6);
        codes.Add(codeFM7);
        //codes.Add(codeFmM7);
        codes.Add(codeF7);
        codes.Add(codeFm7);
        //codes.Add(codeFaug7);
        codes.Add(codeFm7_5);
        //codes.Add(codeF9);
        //codes.Add(codeFm9);
        codes.Add(codeFdim);
        codes.Add(codeFdim7);
        //codes.Add(codeFsus4);
        //codes.Add(codeF7sus4);
        //codes.Add(codeFadd9);

        codes.Add(codeFs);
        codes.Add(codeFsm);
        codes.Add(codeFsaug);
        //codes.Add(codeFs6);
        //codes.Add(codeFsm6);
        codes.Add(codeFsM7);
        //codes.Add(codeFsmM7);
        codes.Add(codeFs7);
        codes.Add(codeFsm7);
        //codes.Add(codeFsaug7);
        codes.Add(codeFsm7_5);
        //codes.Add(codeFs9);
        //codes.Add(codeFsm9);
        codes.Add(codeFsdim);
        codes.Add(codeFsdim7);
        //codes.Add(codeFssus4);
        //codes.Add(codeFs7sus4);
        //codes.Add(codeFsadd9);

        codes.Add(codeG);
        codes.Add(codeGm);
        codes.Add(codeGaug);
        //codes.Add(codeG6);
        //codes.Add(codeGm6);
        codes.Add(codeGM7);
        //codes.Add(codeGmM7);
        codes.Add(codeG7);
        codes.Add(codeGm7);
        //codes.Add(codeGaug7);
        codes.Add(codeGm7_5);
        //codes.Add(codeG9);
        //codes.Add(codeGm9);
        codes.Add(codeGdim);
        codes.Add(codeGdim7);
        //codes.Add(codeGsus4);
        //codes.Add(codeG7sus4);
        //codes.Add(codeGadd9);

        codes.Add(codeAb);
        codes.Add(codeAbm);
        codes.Add(codeAbaug);
        //codes.Add(codeAb6);
        //codes.Add(codeAbm6);
        codes.Add(codeAbM7);
        //codes.Add(codeAbmM7);
        codes.Add(codeAb7);
        codes.Add(codeAbm7);
        //codes.Add(codeAbaug7);
        codes.Add(codeAbm7_5);
        //codes.Add(codeAb9);
        //codes.Add(codeAbm9);
        codes.Add(codeAbdim);
        codes.Add(codeAbdim7);
        //codes.Add(codeAbsus4);
        //codes.Add(codeAb7sus4);
        //codes.Add(codeAbadd9);

        codes.Add(codeA);
        codes.Add(codeAm);
        codes.Add(codeAaug);
        //codes.Add(codeA6);
        //codes.Add(codeAm6);
        codes.Add(codeAM7);
        //codes.Add(codeAmM7);
        codes.Add(codeA7);
        codes.Add(codeAm7);
        //codes.Add(codeAaug7);
        codes.Add(codeAm7_5);
        //codes.Add(codeA9);
        //codes.Add(codeAm9);
        codes.Add(codeAdim);
        codes.Add(codeAdim7);
        //codes.Add(codeAsus4);
        //codes.Add(codeA7sus4);
        //codes.Add(codeAadd9);

        codes.Add(codeBb);
        codes.Add(codeBbm);
        codes.Add(codeBbaug);
        //codes.Add(codeBb6);
        //codes.Add(codeBbm6);
        codes.Add(codeBbM7);
        //codes.Add(codeBbmM7);
        codes.Add(codeBb7);
        codes.Add(codeBbm7);
        //codes.Add(codeBbaug7);
        codes.Add(codeBbm7_5);
        //codes.Add(codeBb9);
        //codes.Add(codeBbm9);
        codes.Add(codeBbdim);
        codes.Add(codeBbdim7);
        //codes.Add(codeBbsus4);
        //codes.Add(codeBb7sus4);
        //codes.Add(codeBbadd9);

        codes.Add(codeB);
        codes.Add(codeBm);
        codes.Add(codeBaug);
        //codes.Add(codeB6);
        //codes.Add(codeBm6);
        codes.Add(codeBM7);
        //codes.Add(codeBmM7);
        codes.Add(codeB7);
        codes.Add(codeBm7);
        //codes.Add(codeBaug7);
        codes.Add(codeBm7_5);
        //codes.Add(codeB9);
        //codes.Add(codeBm9);
        codes.Add(codeBdim);
        codes.Add(codeBdim7);
        //codes.Add(codeBsus4);
        //codes.Add(codeB7sus4);
        //codes.Add(codeBadd9);
    }

    void GetScore()
    {
       for(int i = 0; i < scoreRecorder.playTime.Length; i++)
        {
            if((int)scoreRecorder.playTime[i] == 0) break;

            for(int j = 0; j < (int)scoreRecorder.playTime[i]; j++)
            {
                score.Add(scoreRecorder.score[i]);
            }
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

            // 最大合致率を格納する変数
            float maxConformance = 0;

            // 最大合致率のコードを格納するList <--------------------stringからListに変更予定
            List<List<string>> maxConformanceCodes = new List<List<string>>();

            // 一小節分のスコアを格納
            for(int j = 0; j < 16; j++)
            {
                scoreOfBar.Add(score[16 * i + j]);
            }
            
            //すべてのコードをチェック
            foreach(List<string> code in codes)
            {
                conformanceCheck.Add(CheckCodeConformance(scoreOfBar,code));
                if(CheckCodeConformance(scoreOfBar,code) > maxConformance)
                {
                    
                    maxConformance = CheckCodeConformance(scoreOfBar,code);
                    maxConformanceCodes.Clear();
                    maxConformanceCodes.Add(code);
                }
                else if(CheckCodeConformance(scoreOfBar,code) == maxConformance)
                {
                    maxConformanceCodes.Add(code);
                }
            }

            if(i == 0) code1.AddRange(maxConformanceCodes[UnityEngine.Random.Range(0, maxConformanceCodes.Count)]);
            else if(i == 1) code2.AddRange(maxConformanceCodes[UnityEngine.Random.Range(0, maxConformanceCodes.Count)]);
            else if(i == 2) code3.AddRange(maxConformanceCodes[UnityEngine.Random.Range(0, maxConformanceCodes.Count)]);
            else if(i == 3) code4.AddRange(maxConformanceCodes[UnityEngine.Random.Range(0, maxConformanceCodes.Count)]);
        }
    }

    float CheckCodeConformance(List<string> scoreOfBar, List<string> code)
    {
        int count = 0;

        foreach (var note in scoreOfBar)
        {
            if (code.Contains(note)) count++;
        }

        return (float)count / scoreOfBar.Count;
    }
    
    void ResetCode()
    {
        conformanceCheck.Clear();
        code1.Clear();
        code2.Clear();
        code3.Clear();
        code4.Clear();
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
