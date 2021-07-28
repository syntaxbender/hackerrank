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
    
    Hackerrank Climbing The Leaderboard Problem
    https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
    
    100% Success rate :)
    
    */

    /*
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        int scoreIndex = player.Count-1;
        int rankIndex = 0;
        int rankAlignment = 0;
        List<int> lastStatus = new List<int>();
        while(scoreIndex>-1){
            bool check = false;
            while(rankIndex<ranked.Count && scoreIndex>-1){
                if(player[scoreIndex]>=ranked[rankIndex]){
                    check = true;
                    lastStatus.Add(rankAlignment+1);
                    scoreIndex--;
                }else{
                    if(rankIndex-1<0 || ranked[rankIndex-1] != ranked[rankIndex]) rankAlignment++;
                    rankIndex++;
                }
            }
            if(check == false){
                lastStatus.Add(rankAlignment+1);
                scoreIndex--;
            }
        }
        lastStatus.Reverse();
        return lastStatus;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
