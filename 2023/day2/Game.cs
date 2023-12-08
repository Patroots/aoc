using System;
using System.Collections;

namespace Aoc;

public class Game {
    private int _id;
    private Dictionary<string, int>[] _draws;

    public Game(int id, int drawCount) {
        this._id = id;
        this._draws = new Dictionary<string, int>[drawCount];
    }

    public void addDraw(Dictionary<string, int> draw, int drawIndex) {
        this._draws[drawIndex] = draw;
    }

    public void display() {
        foreach(Dictionary<string, int> dic in this._draws) {
             if (dic.Count > 0) {
                foreach(KeyValuePair<string, int> entry in dic) {
                    Console.WriteLine($"  {entry.Key} : {entry.Value}");
                }
             }
             Console.WriteLine(" ");
        }
    }
}

