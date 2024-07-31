namespace MyQuizApp2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Questions[] questions = new Questions[]
            {
                new Questions("What is the capital of Germany?",
                    new string [] {"Paris", "Berlin", "London", "Madrid"},
                    1
                ),

                new Questions("What is 2+2?",
                    new string [] {"3", "4", "5", "6"},
                    1
                ),

                new Questions("What game character cannot swim?",
                    new string [] {"Mario", "Rayman", "Sonic", "Kirby"},
                    2
                )
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();
            Console.ReadLine();
        }
    }
}
