using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApp2024
{
    internal class Quiz
    {
        private Questions[] questions;
        private int score = 0;

        public Quiz(Questions[] questions)
        {
           this.questions = questions;
        }

        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            int questionNumber = 1;

            foreach(Questions question in questions)
            {
                Console.WriteLine("Question " + questionNumber++ + ":");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();

                if (question.isCorrectAnswer(userChoice))
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect! The correct answer was: " + question.Answers[question.CorrectAnswerIndex]);
                }
            }

            DisplayResult();
        }

        private void DisplayQuestion(Questions question)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================================================================");
            Console.WriteLine("                           Question                             ");
            Console.WriteLine("================================================================");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);

            for(int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("   ");
                Console.Write(i + 1);
                Console.ResetColor();
                Console.WriteLine(". " + question.Answers[i]);
            }
        }

        private int GetUserChoice()
        {
            Console.Write("Your answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4) 
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4: ");
                input = Console.ReadLine();
            }

            return choice - 1;
        }
        private void DisplayResult()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================================================================");
            Console.WriteLine("                            Results                             ");
            Console.WriteLine("================================================================");
            Console.ResetColor();

            Console.WriteLine("You have finished the quiz. Your score is: " + score + " out of " + questions.Length);

            double percentage = (double)score / questions.Length;
            if(percentage == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Amazing! You got a perfect score!");
            }
            else if(percentage >= .8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excellent! Try again for a better score!");
            }
            else if (percentage >= .5)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Good job. Try again for a better score!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Better luck next time. Try again for a better score!");
            }
            Console.ResetColor();
        }
    }
}
