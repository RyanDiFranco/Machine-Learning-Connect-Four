using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Connect_Four
{
    public partial class Form1 : Form
    {
        public Player playerOne = new Player();
        public Player playerTwo = new Player();
        public Random rnd = new Random();

        static int[] emptyColumns = new int[] { 0, 0, 0, 0, 0, 0, 0 }; //Columns height is tracked in columns array. 
        static int[] colIndex = new int[] { 0, 1, 2, 3, 4, 5, 6 }; //An indexer for columns, allowing values to be written properly
        public List<int[]> openMoves = new List<int[]>();

        public List<int> openColumns = new List<int>();
        public List<int> openColIndex = new List<int>();
        public string[] turns = new string[42];
        public int turn = 0;
        string[] emptyRow = new string[] { "0", "0", "0", "0", "0", "0", "0" };
        public string[][] Rows = new string[6][];
        public string[] actionPrep = new string[6];
        public string gameState;
        public bool OutOfTurns;
        public bool simulationDone = false;
        public bool humanGame = true;
        public int simulationCount = 0;
        public int maxGames = 50;
        public bool randomize = false;
        DateTime start = DateTime.Now;
        int xLoc = 0;
        int yLoc = 0;
        public int randomChance = 10;

        string query;
        public DBConnect sendQuery = new DBConnect();
        string writeDatabase = "simdataclone";
        public string brainDatabase = "simdata";

        public Form1()
        {
            InitializeComponent();
            EstablishPlayers(playerOne, "1", 1, playerTwo, true);
            EstablishPlayers(playerTwo, "2", 2, playerOne, false);
            CreateButtons();
            ResetGame();
            listBoxBrain.Items.Add("simdata");
            listBoxBrain.Items.Add("simdatav2");
            listBoxWrite.Items.Add("simdata");
            listBoxWrite.Items.Add("simdatav2");
            listBoxWrite.Items.Add("simdataclone");
        }

        private void CreateButtons()
        {
            for (int i = 0; i < 42; i++)
            {
                int xCoord = 0;
                int yCoord = 0;
                Button button = new Button();
                button.Size = new Size(40, 40);
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
                xLoc = xCoord * 40;
                yLoc = 300 - yCoord * 40;
                button.Location = new Point(xLoc, yLoc);
                button.Name = xCoord.ToString() + yCoord.ToString();
                button.Text = button.Name;

                button.Enabled = false;
                button.BackColor = Color.LightGray;
                Controls.Add(button);
            }
        }

        private void ClearButtons()
        {
            for (int i = 0; i < 42; i++)
            {
                int xCoord = 0;
                int yCoord = 0;
                if (i < 7)
                {
                    xCoord = i;
                    yCoord = 5;
                }
                else if (i >= 7 && i < 14)
                {
                    xCoord = i - 7;
                    yCoord = 4;
                }
                else if (i >= 14 && i < 21)
                {
                    xCoord = i - 14;
                    yCoord = 3;
                }
                else if (i >= 21 && i < 28)
                {
                    xCoord = i - 21;
                    yCoord = 2;
                }
                else if (i >= 28 && i < 35)
                {
                    xCoord = i - 28;
                    yCoord = 1;
                }
                else if (i >= 35 && i < 42)
                {
                    xCoord = i - 35;
                    yCoord = 0;
                }
                Button button = (Button)FindDynamicControlByName(xCoord.ToString() + yCoord.ToString());
                button.BackColor = Color.LightGray;
            }
            for (int i = 0; i < 7; i++)
            {
                DisableDropper(i, true);
            }
        }

        private void EstablishPlayers(Player player, string playerString, int number, Player opponent, bool isTurn)
        {
            player.playerString = playerString;
            player.playerNumber = number;
            player.opponent = opponent;
            player.isComputer = false;
            player.difficulty = 1;
            player.maxChain = 0;
            player.hasWon = false;
            player.points = 0;
            player.isTurn = isTurn;
        }

        private void ResetGame()
        {
            turn = 0;
            OutOfTurns = false;
            openColumns = new List<int>(emptyColumns);
            openColIndex = new List<int>(colIndex);
            openMoves.Clear();
            for (int i = 0; i < turns.Count(); i++)
            {
                turns[i] = "";
            }
            for (int i = 0; i < 6; i++)
            {
                Rows[i] = new string[] { "0", "0", "0", "0", "0", "0", "0" };
            }
            for (int i = 0; i < 7; i++)
            {
                int[] move = new int[] { i, 0 };
                openMoves.Add(move);
            }
            playerOne.hasWon = false;
            playerOne.isTurn = true;
            playerTwo.hasWon = false;
            playerTwo.isTurn = false;
            playerOne.maxChain = 0;
            playerTwo.maxChain = 0;
            gameState = "000000000000000000000000000000000000000000";
            if (humanGame)
            {
                ClearButtons();
            }

            playerOne.winMoves.Clear();
            playerOne.blockMoves.Clear();
            playerOne.badMoves.Clear();
            playerTwo.winMoves.Clear();
            playerTwo.blockMoves.Clear();
            playerTwo.badMoves.Clear();
        }

        

        private void buttonSimulateGames(object sender, EventArgs e)
        {
            label1.Text = "";
            playerOne.NextMove(0);
            WriteReport();
            TimeSpan elapsed = DateTime.Now - start;
            label1.Text += "\r\n Elapsed Time: " + elapsed.ToString("mm' : 'ss");
        }


        public void ComputeMove(Player player, int xCoord, int yCoord)
        {
            
            Rows[yCoord][xCoord] = player.playerString;
            int[] oldMove = new int[] { xCoord, yCoord };
            for (int i = 0; i < openMoves.Count(); i++)
            {
                if(openMoves[i][0] == oldMove[0] && openMoves[i][1] == oldMove[1])
                {
                    openMoves.RemoveAt(i);
                }
            }
            
            if (yCoord != 5)
            {
                int[] move = new int[] { xCoord, yCoord + 1 };
                openMoves.Add(move);
            }
            
            if (humanGame)
            {
                UpdateGrid(player);
            }
            JoinGameState();
            CheckForWin(player);
            turn++;
            if(turn == 42)
            {
                OutOfTurns = true;
            }

            player.isTurn = false;
            player.opponent.isTurn = true;
            if(player.hasWon || OutOfTurns)
            {
                simulationCount++;
                WriteResults();
                if (simulationCount == maxGames)
                {
                    simulationDone = true;
                }
                if (player.hasWon)
                {
                    if (humanGame)
                    {
                        string name = player.playerString;
                        labelHuman.Text = "\r\n Player " + name + " has won!";
                        labelHuman.Text += "\r\n" + player.winMethod;
                    }
                }
                else
                {
                    //Tie game?
                }
                ResetGame();

                if (!simulationDone)
                {
                    if (!humanGame)
                    {
                        playerOne.NextMove(0);
                    }
                }
                else
                {
                    simulationCount = 0;
                    simulationDone = false;
                }
            }
            else
            {
                if (player.opponent.isComputer)
                {
                    player.opponent.NextMove(0);
                }
            }
        }

        private void UpdateGrid(Player player)
        {
            int xCoord = player.lastXMove;
            int yCoord = player.lastYMove;
            Button button = (Button)FindDynamicControlByName(xCoord.ToString() + yCoord.ToString());
            if (player.playerNumber == 1)
            {
                button.BackColor = Color.Red;
            }
            else
            {
                button.BackColor = Color.Blue;
            }
        }

        private void JoinGameState()
        {
            for (int i = 5; i > -1; i--)
            {
                string action = string.Join("", Rows[i]);
                actionPrep[i] = action;
            }
            gameState = string.Join("", actionPrep);
            if (humanGame)
            {
                textBoxGameState.Text = gameState;
            }
            turns[turn] = gameState;
        }

        private void CheckForWin(Player player)
        {
            int xCoord = player.lastXMove;
            int yCoord = player.lastYMove;
            int playerValue = player.playerNumber;
            HorizontalCheck(xCoord, yCoord, playerValue, player);
            VerticalCheck(xCoord, yCoord, playerValue, player);
            DiagonalLeftUpCheck(xCoord, yCoord, playerValue, player);
            DiagonalLeftDownCheck(xCoord, yCoord, playerValue, player);
        }

        private void HorizontalCheck(int xCoord, int yCoord, int playerValue, Player player)
        {
            int count = 0; //Have to establish the bounds for checking. If too close to border, have to do fewer checks
            int max = 4;
            if (xCoord < 3)
            {
                count = 3 - xCoord;
            }
            if (xCoord > 3)
            {
                max = 7 - xCoord;
            }
            for (int i = count; i < max; i++) //Iterates to see if there is 4 identical pieces that match the player value
            {
                int[] spots = new int[4];

                spots[0] = Convert.ToInt32(Rows[yCoord][xCoord - 3 + i]);
                spots[1] = Convert.ToInt32(Rows[yCoord][xCoord - 2 + i]);
                spots[2] = Convert.ToInt32(Rows[yCoord][xCoord - 1 + i]);
                spots[3] = Convert.ToInt32(Rows[yCoord][xCoord + i]);
                int streak = 0;

                foreach(int spot in spots)
                {
                    if(spot == playerValue)
                    {
                        streak++;
                    }
                }

                if (streak > player.maxChain)
                {
                    player.maxChain = streak;
                }

                if (streak == 4)
                {
                    player.hasWon = true;
                    player.winMethod = "Horizontal";
                }
                if (streak == 3)
                {
                    int xCoordPreferred;
                    int yCoordPreferred = yCoord;
                    for (int k = 0; k < 4; k++)
                    {
                        xCoordPreferred = xCoord + i - k;
                        if(Convert.ToInt32(Rows[yCoord][xCoordPreferred]) == 0) //If player has a streak of 3 with an open spot, marks that spot as preferred
                        {
                            int[] preferredMove = new int[] { xCoordPreferred, yCoordPreferred };
                            player.winMoves.Add(preferredMove);
                            player.opponent.blockMoves.Add(preferredMove);
                            if (yCoordPreferred > 0) //Lets the ai know the spot beneath the winning spot is not preferred
                            {
                                int[] badMove = new int[] { xCoordPreferred, yCoordPreferred - 1 };
                                player.badMoves.Add(badMove);
                                player.opponent.badMoves.Add(badMove);
                            }

                        }
                    }
                }
            }
        }

        private void VerticalCheck(int xCoord, int yCoord, int playerValue, Player player)
        {
            if (yCoord > 1)
            {
                int[] spots;
                if (yCoord > 2)
                {
                    spots = new int[4];
                    spots[3] = Convert.ToInt32(Rows[yCoord - 3][xCoord]);
                    spots[2] = Convert.ToInt32(Rows[yCoord - 2][xCoord]);
                    spots[1] = Convert.ToInt32(Rows[yCoord - 1][xCoord]);
                    spots[0] = Convert.ToInt32(Rows[yCoord][xCoord]);
                }
                else
                {
                    spots = new int[3];
                    spots[2] = Convert.ToInt32(Rows[yCoord - 2][xCoord]);
                    spots[1] = Convert.ToInt32(Rows[yCoord - 1][xCoord]);
                    spots[0] = Convert.ToInt32(Rows[yCoord][xCoord]);
                }

                int streak = 0;

                foreach (int spot in spots)
                {
                    if (spot == playerValue)
                    {
                        streak++;
                    }
                }

                if (streak > player.maxChain)
                {
                    player.maxChain = streak;
                }

                if (streak == 4)
                {
                    player.hasWon = true;
                    player.winMethod = "Vertical";
                }
                if (spots[0] == spots[1] && spots[1] == spots[2]) //Minor issue, can't check if 3 are stacked on top of each other from y = 0
                {
                    int xCoordPreferred = xCoord;
                    int yCoordPreferred = yCoord + 1;
                    if (yCoordPreferred < 6)
                    {
                        int[] move = new int[] { xCoordPreferred, yCoordPreferred };
                        player.winMoves.Add(move);
                        player.opponent.blockMoves.Add(move);
                    }
                }
            }
        }

        private void DiagonalLeftUpCheck(int xCoord, int yCoord, int playerValue, Player player)
        {
            for (int i = 0; i < 4; i++) //Iterates to see if there is 4 identical pieces that match the player value
            {
                int minY = yCoord - 3 +i;
                int maxY = yCoord + i;
                int minX = xCoord - 3 + i;
                int maxX = xCoord + i;
                if (minY > -1 && maxY < 6 && minX > -1 && maxX < 7)
                {
                    int[] spots = new int[4];
                    spots[0] = Convert.ToInt32(Rows[yCoord - 3 + i][xCoord - 3 + i]);
                    spots[1] = Convert.ToInt32(Rows[yCoord - 2 + i][xCoord - 2 + i]);
                    spots[2] = Convert.ToInt32(Rows[yCoord - 1 + i][xCoord - 1 + i]);
                    spots[3] = Convert.ToInt32(Rows[yCoord + i][xCoord + i]);
                    int streak = 0;

                    foreach (int spot in spots)
                    {
                        if (spot == playerValue)
                        {
                            streak++;
                        }
                    }

                    if (streak > player.maxChain)
                    {
                        player.maxChain = streak;
                    }

                    if (streak == 4)
                    {
                        player.hasWon = true;
                        player.winMethod = "Diagonal LeftUp";
                    }
                    if (streak == 3)
                    {
                        int xCoordPreferred;
                        int yCoordPreferred;
                        for (int k = 0; k < 4; k++)
                        {
                            xCoordPreferred = xCoord + i - k;
                            yCoordPreferred = yCoord + i - k;
                            if (Convert.ToInt32(Rows[yCoordPreferred][xCoordPreferred]) == 0) //If player has a streak of 3 with an open spot, marks that spot as preferred
                            {
                                int[] preferredMove = new int[] { xCoordPreferred, yCoordPreferred };
                                player.winMoves.Add(preferredMove);
                                player.opponent.blockMoves.Add(preferredMove);
                                if (yCoordPreferred > 0) //Lets the ai know the spot beneath the winning spot is not preferred
                                {
                                    int[] badMove = new int[] { xCoordPreferred, yCoordPreferred - 1 };
                                    player.badMoves.Add(badMove);
                                    player.opponent.badMoves.Add(badMove);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DiagonalLeftDownCheck(int xCoord, int yCoord, int playerValue, Player player)
        {
            for (int i = 0; i < 4; i++) //Iterates to see if there is 4 identical pieces that match the player value
            {
                int minY = yCoord - i;
                int maxY = yCoord + 3 - i;
                int minX = xCoord - 3 +i;
                int maxX = xCoord + i;
                if (minY > -1 && maxY < 6 && minX > -1 && maxX < 7)
                {
                    int[] spots = new int[4];
                    spots[0] = Convert.ToInt32(Rows[yCoord + 3 - i][xCoord - 3 + i]);
                    spots[1] = Convert.ToInt32(Rows[yCoord + 2 - i][xCoord - 2 + i]);
                    spots[2] = Convert.ToInt32(Rows[yCoord + 1 - i][xCoord - 1 + i]);
                    spots[3] = Convert.ToInt32(Rows[yCoord - i][xCoord + i]);
                    int streak = 0;

                    foreach (int spot in spots)
                    {
                        if (spot == playerValue)
                        {
                            streak++;
                        }
                    }

                    if (streak > player.maxChain)
                    {
                        player.maxChain = streak;
                    }

                    if (streak == 4)
                    {
                        player.hasWon = true;
                        player.winMethod = "Diagonal LeftDown";
                    }
                    if (streak == 3)
                    {
                        int xCoordPreferred;
                        int yCoordPreferred;
                        for (int k = 0; k < 4; k++)
                        {
                            xCoordPreferred = xCoord + i - k;
                            yCoordPreferred = yCoord - i + k;
                            if (Convert.ToInt32(Rows[yCoordPreferred][xCoordPreferred]) == 0) //If player has a streak of 3 with an open spot, marks that spot as preferred
                            {
                                int[] preferredMove = new int[] { xCoordPreferred, yCoordPreferred };
                                player.winMoves.Add(preferredMove);
                                player.opponent.blockMoves.Add(preferredMove);
                                if (yCoordPreferred > 0) //Lets the ai know the spot beneath the winning spot is not preferred
                                {
                                    int[] badMove = new int[] { xCoordPreferred, yCoordPreferred - 1 };
                                    player.badMoves.Add(badMove);
                                    player.opponent.badMoves.Add(badMove);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void WriteResults()
        {
            string firstPart = "";
            string secondPart = "";
            query = "INSERT INTO " + writeDatabase + " (SimNum,";
            for (int i = 0; i < turns.Count(); i++)
            {
                firstPart += "T" + (i + 1).ToString() + ",";
                string addition;
                addition = "'" + turns[i] + "',";
                if (turns[i] == "")
                {
                    addition = "NULL,";
                }
                secondPart += addition;
            }
            string winner = "0,";
            if (playerOne.hasWon)
            {
                winner = "1,";
            }
            else if (playerTwo.hasWon)
            {
                winner = "2,";
            }
            playerOne.CalculatePoints(turn);
            playerTwo.CalculatePoints(turn);
            query += firstPart;
            query += "Winner, P1Points, P2Points) VALUES (NULL,";
            query += secondPart;
            query += winner + playerOne.pointsString + "," + playerTwo.pointsString + ")";
            sendQuery.RunQuery(query);
        }

        private void WriteReport()
        {
            query = "SELECT COUNT(*) as count_" + writeDatabase + " FROM " + writeDatabase + " WHERE Winner = 1";
            List<string> PlayerOne = sendQuery.SelectQuery(query);

            query = "SELECT COUNT(*) as count_" + writeDatabase + " FROM " + writeDatabase + " WHERE Winner = 2";
            List<string> PlayerTwo = sendQuery.SelectQuery(query);

            query = "SELECT COUNT(*) as count_" + writeDatabase + " FROM " + writeDatabase;
            List<string> TotalGames = sendQuery.SelectQuery(query);

            int PlayerOneWin = Convert.ToInt32(PlayerOne[0]);
            int TotalGamePlayed = Convert.ToInt32(TotalGames[0]);
            int PlayerTwoWin = Convert.ToInt32(PlayerTwo[0]);
            int Ties = TotalGamePlayed - PlayerOneWin - PlayerTwoWin;
            labelStats.Text = "";
            labelStats.Text = "Total Games: " + TotalGamePlayed;
            labelStats.Text += "\r\n Player 1 Wins: " + PlayerOneWin;
            labelStats.Text += "\r\n Player 2 Wins: " + PlayerTwoWin;
            labelStats.Text += "\r\n Ties: " + Ties;
        }

        private void buttonPlayerOne_Click(object sender, EventArgs e)
        {
            ToggleHumanComputer(playerOne, sender, trackBarPlayerOne);
        }

        private void buttonPlayerTwo_Click(object sender, EventArgs e)
        {
            ToggleHumanComputer(playerTwo, sender, trackBarPlayerTwo);
        }

        private void ToggleHumanComputer(Player player, object sender, TrackBar trackbar) //Switches player from computer/human, as well as button text
        {
            bool isComputer = player.isComputer;
            Button button = (Button)sender;
            if (isComputer)
            {
                player.isComputer = false;
                button.Text = "Human";
                trackbar.Enabled = false;
            }
            else
            {
                player.isComputer = true;
                button.Text = "Computer";
                trackbar.Enabled = true;
            }
            if(player.isComputer && player.opponent.isComputer)
            {
                humanGame = false;
            }
            else
            {
                humanGame = true;
            }
        }

        private void trackBarPlayerOne_ValueChanged(object sender, EventArgs e)
        {
            ChangeDifficulty(playerOne, trackBarPlayerOne.Value);
        }

        private void trackBarPlayerTwo_ValueChanged(object sender, EventArgs e)
        {
            ChangeDifficulty(playerTwo, trackBarPlayerTwo.Value);
        }

        private void ChangeDifficulty(Player player, int difficulty) //Updates the difficulty of the player
        {
            player.difficulty = difficulty;
        }

        private void numericUpDownSimGames_ValueChanged(object sender, EventArgs e)
        {
            maxGames = Convert.ToInt32(numericUpDownSimGames.Value);
        }

        private void listBoxBrain_SelectedValueChanged(object sender, EventArgs e)
        {
            brainDatabase = listBoxBrain.SelectedItem.ToString();
        }

        private void listBoxWrite_SelectedValueChanged(object sender, EventArgs e)
        {
            writeDatabase = listBoxWrite.SelectedItem.ToString();
        }

        private void buttonClearTestDB_Click(object sender, EventArgs e)
        {
            query = "DELETE FROM " + writeDatabase + " WHERE SimNum > 0";
            sendQuery.RunQuery(query);
        }

        private void buttonTimer_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
        }

        private void checkBoxRandomize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRandomize.Checked)
            {
                randomize = true;
            }
            else
            {
                randomize = false;
            }
        }

        public Control FindDynamicControlByName(string controlName) //Function to find controls by name. Used many time.
        {
            return Controls.Find(controlName, true).FirstOrDefault();
        }

        public void DisableDropper(int xCoord, bool state)
        {
            Button button = (Button)FindDynamicControlByName("buttonX" + xCoord.ToString());
            button.Enabled = state;
        }

        private void PlayerTurn(int space)
        {
            if (playerOne.isTurn && !playerOne.isComputer)
            {
                playerOne.NextMove(space);
            }
            else if (playerTwo.isTurn && !playerTwo.isComputer)
            {
                playerTwo.NextMove(space);
            }
        }

        private void buttonX0_Click(object sender, EventArgs e)
        {
            PlayerTurn(0);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            PlayerTurn(1);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            PlayerTurn(2);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            PlayerTurn(3);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            PlayerTurn(4);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            PlayerTurn(5);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            PlayerTurn(6);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            randomChance = Convert.ToInt32(numericUpDownRandChance.Value);
        }
    }
}
