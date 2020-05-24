using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Ремизов Павел
/*
а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
б) Добавить меню и команду «Играть». При нажатии появляется сообщение, 
какое число должен получить игрок. Игрок должен получить это число за минимальное количество ходов.
в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack.
Вся логика игры должна быть реализована в классе с удвоителем.
*/
namespace GeekBrains_CSharpBasics_Ln7_Tsk1.Model
{
    public enum GameStatus
    {
        InProcess,
        Win,
        Lose
    }
    [Serializable()]
    public class GameLogic
    {
        [field: NonSerialized()]
        public Action updateGameInfo;
        public int CurrentValue { get; set; } = 1;
        public int Goal { get; private set; }
        public int Steps => commandBuffer.Count;
        public int MaxSteps => NumberOfStepsToWin(Goal);
        public GameStatus Status { get; private set; } = GameStatus.InProcess;
        
        const string fileName = @"../../SavedGameLogic.bin";
        
        Stack<ICommand> commandBuffer = new Stack<ICommand>();

        public GameLogic(int min, int max)
        {
            if (min >= max)
                Goal = new Random().Next(10, 101);
            else if (min < 2)
                Goal = new Random().Next(2, max);
            else
            Goal = new Random().Next(min, max + 1);
            updateGameInfo = CheckForWin;
        }
        public GameLogic() : this(10, 100)
        {
        }
        public GameLogic(int goal)
        {
            goal = goal < 2 ? new Random().Next(10, 101) : goal;
            this.Goal = goal;
            updateGameInfo = CheckForWin;
        }
        int NumberOfStepsToWin(int valueToDivide) =>
            valueToDivide / 2 > 1 ?
            valueToDivide % 2 == 0 ?
            1 + NumberOfStepsToWin(valueToDivide / 2) : 1 + NumberOfStepsToWin(valueToDivide - 1) : 1;
        void AddCommandToBuffer(ICommand commandToAdd) => commandBuffer.Push(commandToAdd);
        ICommand RemoveCommandFromBuffer() => commandBuffer.Pop();

        public void AddOne()
        {
            ICommand addCommand = new AddCommand(this);
            addCommand.Execute();
            AddCommandToBuffer(addCommand);
            updateGameInfo?.Invoke();
        }
        public void Double()
        {
            ICommand doubleCommand = new MultiplyByTwo(this);
            doubleCommand.Execute();
            AddCommandToBuffer(doubleCommand);
            updateGameInfo?.Invoke();
        }
        public void Reset()
        {
            CurrentValue = 1;
            commandBuffer.Clear();
            updateGameInfo?.Invoke();
        }
        public void Undo()
        {
            if (commandBuffer.Count > 0)
            {
                RemoveCommandFromBuffer().Undo();
                updateGameInfo?.Invoke();
            }
        }
        public void CheckForWin() =>
            Status = 
            Steps == MaxSteps ? 
            CurrentValue == Goal ? GameStatus.Win : GameStatus.Lose : GameStatus.InProcess;

        public void SaveData()
        {
            using (Stream SaveFileStream = File.Create(fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, this);
            }
        }
        public static GameLogic LoadData()
        {
            if (File.Exists(fileName))
            {
                GameLogic savedGame;
                using (Stream openFileStream = File.OpenRead(fileName))
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    savedGame = (GameLogic)deserializer.Deserialize(openFileStream);
                    return savedGame;
                }
            }
            return null;
        }
    }
}
