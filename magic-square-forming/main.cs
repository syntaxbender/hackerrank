using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    /*

    Author : Sir.Geny.00/SyntaxBender
    
    Hackerrank Forming a Magic Square Problem
    https://www.hackerrank.com/challenges/magic-square-forming/problem
    
    100% Success rate :)
    
    */

    /*
    * Complete the 'formingMagicSquare' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts 2D_INTEGER_ARRAY s as parameter.
    */
    public static List<List<int>> deepCopy(List<List<int>> s){
        List<List<int>> deepCopyArr = new List<List<int>>();
        foreach(List<int> element in s){
            List<int> temparr = new List<int>();
            foreach(int element2 in element){
                temparr.Add(element2);
            }
            deepCopyArr.Add(temparr);
        }
        return deepCopyArr;
    }
    public static List<int> deepCopy(List<int> s){
        List<int> deepCopyArr = new List<int>();
        foreach(int element in s){
            deepCopyArr.Add(element);
        }
        return deepCopyArr;
    }
    public static List<List<int>> xSym(List<List<int>> s){
        List<List<int>> xsim = deepCopy(s);
        xsim[0][0] = s[2][0];
        xsim[0][1] = s[2][1];
        xsim[0][2] = s[2][2];
        xsim[2][0] = s[0][0];
        xsim[2][1] = s[0][1];
        xsim[2][2] = s[0][2];
        return xsim;
    }
    public static List<List<int>> ySym(List<List<int>> s){
        List<List<int>> ysim = deepCopy(s);
        ysim[0][0] = s[0][2];
        ysim[1][0] = s[1][2];
        ysim[2][0] = s[2][2];
        ysim[0][2] = s[0][0];
        ysim[1][2] = s[1][0];
        ysim[2][2] = s[2][0];
        return ysim;
    }

    public static List<List<int>> rot90(List<List<int>> s){
        List<List<int>> rot = deepCopy(s);
        rot[0][0] = s[2][0];
        rot[1][0] = s[2][1];
        rot[2][0] = s[2][2];
        
        rot[2][1] = s[1][2];
        rot[2][2] = s[0][2];
        
        rot[0][2] = s[0][0];
        rot[1][2] = s[0][1];
        
        rot[0][1] = s[1][0];
        return rot;
    }
    public static int getDiff(List<List<int>> s1, List<List<int>> s2){
        int total = 0;
        for(int i=0; i<3; i++){
            for(int i2=0; i2<3; i2++){
                if(s1[i][i2] != s2[i][i2]) total += Math.Abs(s1[i][i2]-s2[i][i2]);
            }
        }
        return total;
    }

    public static int formingMagicSquare(List<List<int>> s){
        List<List<int>> magicSquare = new List<List<int>>{
            new List<int>{8,3,4},
            new List<int>{1,5,9},
            new List<int>{6,7,2}
        };
        List<int> diffList = new List<int>();
        List<List<int>> square;
        for(int i=0; i<4; i++){
            square = s;
            if(i==1){
                square = xSym(s);
            }else if(i==2){
                square = ySym(s);
            }else if(i==3){
                square = ySym(xSym(s));
            }   
            for(int i2=0; i2<4; i2++){
                int difference = getDiff(magicSquare,square);
                square = rot90(square);
                diffList.Add(difference);
            }
        }
        int minOfList = diffList.Min();
        return minOfList;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        List<List<int>> s = new List<List<int>>();
        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }
        int result = Result.formingMagicSquare(s);
        textWriter.WriteLine(result);
        textWriter.Flush();
        textWriter.Close();
    }
}