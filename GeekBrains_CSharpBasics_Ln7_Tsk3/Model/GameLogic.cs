using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GeekBrains_CSharpBasics_Ln7_Tsk3.Model
{
    public enum GameStatus
    {
        Win,
        Lose,
        InProcess
    }
    class GameLogic
    {
        public Action turnIsDone;
        int[,] gameField;
        Random random = new Random();
        int cellSize = 55;
        Button[,] buttonGameField;
        List<Button> enemies = new List<Button>();
        Button player;
        public GameStatus Status { get; private set; } = GameStatus.InProcess;

        public GameLogic(Panel panelField, int numberOfEnemy)
        {
            int rows = panelField.Size.Height / cellSize;
            int columns = panelField.Size.Width / cellSize;
            int unsteppable = (rows - 2) / 2;
            gameField = new int[rows, columns];
            gameField[rows - 1, 0] = -2; //playerPosition
            gameField[0, columns - 1] = 2; //water_lilyPosition
            GenerateUsteppableCells(unsteppable);
            int numberOfEnemyAtSelectedRow = numberOfEnemy / 2;
            GenerateEnemy(numberOfEnemyAtSelectedRow, 2);
            GenerateEnemy(numberOfEnemy - numberOfEnemyAtSelectedRow, 0);
            GenerateGameField(panelField);
        }
        void GenerateUsteppableCells(int numberOfUnsteppableInRow)
        {
            for (int i = 1; i < gameField.GetLength(0) - 1; i++)
            {
                int setUnsteppable = 0;
                while (setUnsteppable < numberOfUnsteppableInRow)
                {
                    int index = random.Next(1, gameField.GetLength(1) - 1);
                    if (gameField[i, index] == 0)
                    {
                        gameField[i, index] = 1;
                        setUnsteppable++;
                    }
                }
            }
        }
        void GenerateEnemy(int numberOfEnemy, int row)
        {
            int enemy = 0;
            while (enemy < numberOfEnemy)
            {
                int index = random.Next(0, gameField.GetLength(1) - 1);
                if (gameField[row, index] == 0)
                {
                    gameField[row, index] = -1;
                    enemy++;
                }
            }
        }
        public void GenerateGameField(Panel gameFieldPanel)
        {
            int rows = gameField.GetLength(0);
            int columns = gameField.GetLength(1);
            buttonGameField = new Button[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(cellSize, cellSize);
                    //btn.Margin = new Padding(0, 0, 0, 0);
                    btn.Location = new Point(j * cellSize, i * cellSize);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Silver;
                    btn.BackColor = Color.Transparent;
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    gameFieldPanel.Controls.Add(btn);
                    AddVisualisation(btn, gameField[i, j]);
                    buttonGameField[i, j] = btn;
                    btn.Click += MoveFrog;
                }
            }
        }
        void AddVisualisation(Button button, int mark)
        {
            switch (mark)
            {
                case -2:
                    int frogLeaf = random.Next(1, 3);
                    button.BackgroundImage = 
                        Image.FromFile($"..//..//Resourses//leaf{frogLeaf}.png");
                    button.Image = Image.FromFile(@"../../Resourses/frog.png");
                    button.Tag = "player";
                    player = button;
                    break;
                case -1:
                    int snakeLeaf = random.Next(1, 3);
                    int snake = 1;// random.Next(1, 6);
                    button.BackgroundImage = 
                        Image.FromFile($"..//..//Resourses//leaf{snakeLeaf}.png");
                    button.Image = Image.FromFile($"..//..//Resourses//snake{snake}.png");
                    button.Tag = "enemy";
                    enemies.Add(button);
                    break;
                case 0:
                    int leaf = random.Next(1, 3);
                    button.BackgroundImage = 
                        Image.FromFile($"..//..//Resourses//leaf{leaf}.png");
                    button.Tag = "leaf";
                    break;
                case 1:
                    //nt obstacle = random.Next(1, 4);
                    button.Enabled = false;
                    //button.BackgroundImage = 
                    //    Image.FromFile($"..//..//Resourses//obstacle{obstacle}.png");
                    break;
                case 2:
                    int lily = random.Next(1, 3);
                    button.BackgroundImage = 
                        Image.FromFile($"..//..//Resourses//water_lily{lily}.png");
                    button.Tag = "lily";
                    break;
            }
        }
        void Move(Button btnFrom, Button btnTo)
        {
            //Thread.Sleep(100);
            Button temp = new Button();
            //temp.Image = btnFrom.Image;
            temp.Tag = btnFrom.Tag;
            //btnFrom.Image = btnTo.Image;
            btnFrom.Tag = btnTo.Tag;
            //btnTo.Image = temp.Image;
            btnTo.Tag = temp.Tag;
            btnTo.Image = btnFrom.Image;
            btnFrom.Image = null;
            if ((string)btnTo.Tag == "enemy" && (string)btnFrom.Tag == "player")
                Status = GameStatus.Lose;
        }
        void MoveFrog(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            if ((Math.Abs(clicked.Location.X - player.Location.X) == cellSize &&
                Math.Abs(clicked.Location.Y - player.Location.Y) == 0) ||
                (Math.Abs(clicked.Location.X - player.Location.X) == 0 &&
                Math.Abs(clicked.Location.Y - player.Location.Y) == cellSize))
            {
                switch ((string)clicked.Tag)
                {
                    case "leaf":
                        Move(player, clicked);
                        player = clicked;
                        EnemiesMove();
                        break;
                    case "enemy":
                        Move(clicked, player);
                        Status = GameStatus.Lose;
                        break;
                    case "lily":
                        Move(player, clicked);
                        Status = GameStatus.Win;
                        break;
                    default:
                        break;
                }
                turnIsDone?.Invoke();
            }
        }
        void EnemiesMove()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Point direction = GetDirection(enemies[i], player);
                AttemptToMove(direction, i);
            }
        }
        void AttemptToMove(Point direction, int enemyListIndex)
        {
            Button enemy = enemies[enemyListIndex];
            Point enemyIndex = new Point() {
                X = enemy.Location.Y/cellSize,
                Y = enemy.Location.X/cellSize 
            };
            if (direction.X != 0 &&
                (string)buttonGameField[enemyIndex.X, enemyIndex.Y + direction.X].Tag != null &&
                (string)buttonGameField[enemyIndex.X, enemyIndex.Y + direction.X].Tag != "enemy")
            {
               Move(enemy, buttonGameField[enemyIndex.X, enemyIndex.Y + direction.X]);
               enemies[enemyListIndex] = buttonGameField[enemyIndex.X, enemyIndex.Y + direction.X];
            }
            else if (direction.Y != 0 &&
                (string)buttonGameField[enemyIndex.X + direction.Y, enemyIndex.Y].Tag != null &&
                (string)buttonGameField[enemyIndex.X + direction.Y, enemyIndex.Y].Tag != "enemy")
            {
                Move(enemy, buttonGameField[enemyIndex.X + direction.Y, enemyIndex.Y]);
                enemies[enemyListIndex] = buttonGameField[enemyIndex.X + direction.Y, enemyIndex.Y];
            }
        }
        Point GetDirection(Button enemy, Button player) =>
            new Point()
            {
                X = player.Location.X.CompareTo(enemy.Location.X),
                Y = player.Location.Y.CompareTo(enemy.Location.Y)
            };
    }
}
