using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел
/*
Используя Windows Forms, разработать игру «Угадай число». 
Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток.
Компьютер говорит, больше или меньше загаданное число введенного.  
a) Для ввода данных от человека используется элемент TextBox;
б) **Реализовать отдельную форму c TextBox для ввода числа.
*/
namespace GeekBrains_CSharpBasics_Ln7_Tsk2.Model
{
    public enum GameStatus
    {
        Win,
        Lose,
        InProcess
    }
    public class GameLogic
    {
        public Action updateUI;
        public int Goal { get; private set; }

        int upperBound, bottomBound;
        public int Attempts { get; private set; }
        public string Reaction { get; private set; }
        public GameStatus Status { get; private set; } = GameStatus.InProcess;
        public string UserHelpText =>
            string.Concat($"Number of remaining attempts: {Attempts}.",
                Environment.NewLine,
                "You know that the number, puzzled by the old pirate, is ",
                (upperBound - bottomBound) > 1 ? $"between {bottomBound} and {upperBound}." :
                (upperBound - bottomBound) == 1 ? $"{bottomBound} or {upperBound}." :
                $"{bottomBound}.");

        Random generator = new Random();

        string[] reactions = 
        {
            "Ye r absolutely wrong!",
            "I swear with my hat, ye took the wrong course!",
            "It looks the treasures will stay with me!",
            "No one pirate was wrong like ye!",
            "Blast ye! Wrong-wrong-wrong!",
            "It looks like ur fuse has completely got wet!",
            "By the Powers! Ye missed again!",
            "By Thunder! Ye didn't guess again!",
            "Damnation sieze my soul! Looks like ye slipped walking down the deck!",
            "Pack of henhearted numbskulls! This chest will stay with me!"
        };
        public GameLogic((int bottom, int upper) bound, int attempts)
        {
            upperBound = bound.upper;
            bottomBound = bound.bottom;
            Attempts = attempts;
            Goal = generator.Next(bound.bottom, bound.upper + 1);
            Reaction = string.Concat(
                $"Old pirate Joe concieved a number from {bound.bottom} to {bound.upper}.",
                Environment.NewLine,
                "He said he would tell you where his treasure chest is hidden if you guess his number.",
                Environment.NewLine,
                $"The only one condition - a limited number of attempts: {Attempts}"
                );
        }
        public void CheckAnswer(int userAnswer)
        {
            int compareResult = userAnswer.CompareTo(Goal);
            switch (compareResult)
            {
                case -1:
                    if (bottomBound < userAnswer)
                        bottomBound = userAnswer + 1;
                    Attempts--;
                    GenerateReaction(false, compareResult);
                    break;
                case 0:
                    GenerateReaction(true);
                    break;
                case 1:
                    if (upperBound > userAnswer)
                        upperBound = userAnswer - 1;
                    Attempts--;
                    GenerateReaction(false, compareResult);
                    break;
            }
            updateUI();
        }
        void ChangeGameStatus(bool isWin) =>
            Status = isWin ? GameStatus.Win : Attempts <= 0 ? GameStatus.Lose : GameStatus.InProcess;
        void GenerateReaction(bool numberGuessed, int compareResult = 0)
        {
            ChangeGameStatus(numberGuessed);
            if (numberGuessed)
            {
                Reaction = string.Concat(
                "Slip of an urchin!",
                Environment.NewLine,
                "Ye guessed the number concieved by me!",
                Environment.NewLine,
                "Hold the map, it will lead ye to my treasure chest!",
                Environment.NewLine,
                "May yer sails stay full and yer powder dry! - blessed you an old pirate."
                );
            }
            else if (Attempts > 0)
            {
                Reaction = string.Concat(
                    reactions[generator.Next(0, reactions.Length)],
                    Environment.NewLine,
                    "The number I have guessed is ",
                    compareResult < 0 ? "greater! - exclaimed Joe." : "less! - exclaimed Joe."
                    );
            }
            else 
            {
                Reaction = string.Concat(
                    "Ye guess numbers like a belly crawling wharf-rats!",
                    Environment.NewLine,
                    "Ye never get my treasure chest!",
                    Environment.NewLine,
                    $"It seems in land schools do not teach to the number {Goal}! - exclaimed Joe."
                    );
            }
        }
    }
}
