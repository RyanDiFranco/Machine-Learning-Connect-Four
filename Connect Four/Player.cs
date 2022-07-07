using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Connect_Four
{
    public class Player
    {
        public string playerString;
        public int playerNumber;
        public Player opponent;
        public bool isComputer;
        public int difficulty;
        public int maxChain;
        public bool hasWon; //bool for whether or not this player has won
        public string winMethod;
        public int points;
        public bool isTurn; //Used for determining if this player can actually go (useful for human vs ai?)
        public int lastXMove;
        public int lastYMove;
        public string pointsString;
        public List<int[]> winMoves = new List<int[]>(); //Stores any moves that should be taken first
        public List<int[]> blockMoves = new List<int[]>(); //Stores any moves that should be taken first
        public List<int[]> badMoves = new List<int[]>(); //List of moves that should not be taken (opens up preferred move for opponent)
        List<int[]> possibleMoves = new List<int[]>(); // List of moves that this player may want to take
        List<int[]> backupMoves;
        string query;
        DBConnect sendQuery = new DBConnect();

        public void CalculatePoints(int turn) //Calculates the players score when requested
        {
            points = (41 - turn) + 4 * maxChain - 4 * opponent.maxChain;
            if (!hasWon)
            {
                points = -points;
            }
            pointsString = "'" + points.ToString() + "'";
        }

        public void NextMove(int xPos)
        {
            possibleMoves = Program.FormMain.openMoves;
            backupMoves = Program.FormMain.openMoves;
            if (isTurn)
            {
                if (isComputer)
                {
                    int r = Program.FormMain.rnd.Next(100);
                    int randomChance = Program.FormMain.randomChance;
                    if (Program.FormMain.randomize)
                    {
                        if (r < randomChance)
                        {
                            RandomMove();
                        }
                        else
                        {
                            if (difficulty == 0) 
                            {
                                RandomMove();
                            }
                            else
                            {
                                CheckWinBlockMoves(difficulty); //Prioritizes winning moves > blocking moves > statistical best moves
                            }
                        }
                    }
                    else
                    {
                        if (difficulty == 0)
                        {
                            RandomMove();
                        }
                        else
                        {
                            CheckWinBlockMoves(difficulty);
                        }
                    }
                    Program.FormMain.ComputeMove(this, lastXMove, lastYMove);
                }
                else
                {
                    lastXMove = xPos;
                    for (int i = 0; i < possibleMoves.Count(); i++) //Identifying the y coordinate for a player move
                    {
                        if (possibleMoves[i][0] == lastXMove)
                        {
                            lastYMove = possibleMoves[i][1];
                        }
                    }

                    Program.FormMain.ComputeMove(this, lastXMove, lastYMove);
                }
            }
        }

        private void CheckWinBlockMoves(int difficulty)
        {
            List<int[]> moves = new List<int[]>();
            for (int i = 0; i < winMoves.Count(); i++)
            {
                for (int k = 0; k < possibleMoves.Count(); k++)
                {
                    if (possibleMoves[k][0] == winMoves[i][0] && possibleMoves[k][1] == winMoves[i][1])
                    {
                        moves.Add(winMoves[i]);
                    }
                }
            }
            if (moves.Any()) 
            {
                lastXMove = moves[0][0];
                lastYMove = moves[0][1];
            }
            else
            {
                for (int i = 0; i < blockMoves.Count(); i++) //Checking for block moves
                {
                    for (int k = 0; k < possibleMoves.Count(); k++)
                    {
                        if (possibleMoves[k][0] == blockMoves[i][0] && possibleMoves[k][1] == blockMoves[i][1])
                        {
                            moves.Add(blockMoves[i]);
                        }
                    }
                }
                if (moves.Any())
                {
                    lastXMove = moves[0][0];
                    lastYMove = moves[0][1];
                    blockMoves.Remove(moves[0]);
                    opponent.winMoves.Remove(moves[0]);
                }
                else if (difficulty == 2) //If no block or win moves available, do a win move.
                {
                    WinMove();
                }
                else //Still need to code in avoiding setup moves. 
                {
                    RandomMove();
                }
            }
        }

        public void RandomMove()
        {
            if (!possibleMoves.Any()) //If all possible moves are bad moves, resets possible moves to all open moves.
            {
                possibleMoves = backupMoves;
            }
            Random rnd = Program.FormMain.rnd;
            int r = rnd.Next(possibleMoves.Count());
            int[] move = possibleMoves[r];
            lastXMove = move[0];
            lastYMove = move[1];
        }

        private void WinMove()
        {
            string brain = Program.FormMain.brainDatabase;
            string currentState = Program.FormMain.gameState;
            int turn = Program.FormMain.turn;
            string currentTurn = "T" + turn.ToString();
            string nextTurn = "T" + (turn + 1).ToString();

            if (turn == 0)
            {
                query = "SELECT DISTINCT " + nextTurn + " FROM " + brain;
            }
            else
            {

                query = "SELECT DISTINCT " + nextTurn + " FROM " + brain + " WHERE " + currentTurn + " = '" + currentState + "'";
            }
            List<string> possibleGoodMoves = sendQuery.SelectQuery(query);

            if (possibleGoodMoves.Count > 0)
            {
                if (turn == 0)
                {
                    query = "SELECT " + nextTurn + " FROM (SELECT SUM(P" + playerString + "Points)/COUNT(" + nextTurn + ") as SumPoints, " + nextTurn + " FROM " +
                    brain + " GROUP BY " + nextTurn + ") foo GROUP BY " +
                    nextTurn + " ORDER BY MAX(SumPoints) DESC";
                }
                else
                {
                    query = "SELECT " + nextTurn + " FROM (SELECT SUM(P" + playerString + "Points)/COUNT(" + nextTurn + ") as SumPoints, " + nextTurn + " FROM " +
                    brain + " WHERE " + currentTurn + " = '" + currentState + "' GROUP BY " + nextTurn + ") foo GROUP BY " +
                    nextTurn + " ORDER BY MAX(SumPoints) DESC";
                }
                List<string> bestMoves = sendQuery.SelectQuery(query);
                string move = "";
                if (bestMoves.Count() > 0)
                {
                    move = bestMoves[0];
                }

                if (move != "")
                {
                    //Use the selected move and proceed
                    string gameState = Program.FormMain.gameState;
                    int xCoord = 0;
                    int yCoord = 0;
                    for (int i = 0; i < move.Length; i++)
                    {
                        if (move[i] != gameState[i])
                        {
                            if (i < 7)
                            {
                                xCoord = i;
                                yCoord = 0;
                            }
                            else if (i >= 7 && i < 14)
                            {
                                xCoord = i - 7;
                                yCoord = 1;
                            }
                            else if (i >= 14 && i < 21)
                            {
                                xCoord = i - 14;
                                yCoord = 2;
                            }
                            else if (i >= 21 && i < 28)
                            {
                                xCoord = i - 21;
                                yCoord = 3;
                            }
                            else if (i >= 28 && i < 35)
                            {
                                xCoord = i - 28;
                                yCoord = 4;
                            }
                            else if (i >= 35 && i < 42)
                            {
                                xCoord = i - 35;
                                yCoord = 5;
                            }
                        }
                    }
                    lastXMove = xCoord;
                    lastYMove = yCoord;
                }
            }
            else
            {
                RandomMove();
            }
        }
    }
}
