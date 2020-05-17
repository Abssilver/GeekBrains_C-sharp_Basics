using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ремизов Павел 
/*
** Написать игру «Верю.Не верю».
В файле хранятся вопрос и ответ, правда это или нет.
Например: «Шариковую ручку изобрели в древнем Египте», «Да».
Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
Список вопросов ищите во вложении или воспользуйтесь интернетом.
*/
namespace GeekBrains_CSharpBasics_Ln5_Tsk5
{
    class QuestionData
    {
        string questionText;
        bool isTrue;
        public QuestionData(string question, string isTrue) : 
            this(question, isTrue.Equals("true", StringComparison.OrdinalIgnoreCase))
        { }
        public QuestionData(string question, bool isTrue)
        {
            question = question.Replace(". ", ".\n");
            this.questionText = question;
            this.isTrue = isTrue;
        }
        public bool CheckAnswer(string userAnswer)
        {
            switch (userAnswer?.ToLower())
            {
                case "true":
                case "t":
                case "yes":
                case "y":
                    return isTrue == true;
                case "false":
                case "f":
                case "no":
                case "n":
                    return isTrue == false;
                default:
                    Console.WriteLine("Invalid input! The program can not accept your answer");
                    return false;
            }
        }
        public override string ToString() =>
            $"{questionText} [True/False]";
    }
    class Program
    {
        static List<QuestionData> quiz = new List<QuestionData>();
        static string filepath = @"..\..\quizText.txt";
        static int scores=0;
        static int numberOfRounds = 5;
        static void Main(string[] args)
        {
            quiz.Clear();
            Console.WriteLine("Welcome To QUIZ Game!");
            Console.WriteLine("Try to determine which of the following statements are true and which are not.");
            LoadDataFromFile(filepath);
            PlayGame();
            Console.WriteLine($"Your final results: {scores} correct answer(s)");
            Console.ReadKey();
        }
        static void PlayGame()
        {
            if (quiz.Count > 0)
            {
                Random random = new Random();
                for (int i = 0; i < numberOfRounds; i++)
                {
                    Console.WriteLine($"Round {i+1} of {numberOfRounds}");
                    int quizQuestion = random.Next(0, quiz.Count);
                    PlayRound(quizQuestion);
                }
            }
        }
        static void PlayRound(int quizQuestion)
        {
            Console.WriteLine(quiz[quizQuestion]);
            if (quiz[quizQuestion].CheckAnswer(Console.ReadLine()))
            {
                Console.WriteLine("Correct! +1 Score!");
                AddScore();
            }
            else
                Console.WriteLine("Wrong!");
            quiz.RemoveAt(quizQuestion);
        }
        static void AddScore() => scores++;
        static void LoadDataFromFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                using (StreamReader strReader = new StreamReader(filepath))
                {

                    while (!strReader.EndOfStream)
                    {
                        string[] lineData = strReader.ReadLine().Split(':');
                        quiz.Add(new QuestionData(lineData[1], lineData[0]));
                    }
                }
            }
        }
    }
}
