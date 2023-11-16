class Program
{
    static void Main(string[] args)
    {
        List<int> questionOrder = GenerateRandomQuestionOrder();
        foreach (int questionNumber in questionOrder)
        {            
            PrintQuestionnaire(questionNumber);            
        }

        UserData.GetInstance().PostResult();
    }

    static List<int> GenerateRandomQuestionOrder()
    {
        List<int> questionOrder = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
        Random random = new Random();
       
        for (int i = questionOrder.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = questionOrder[i];
            questionOrder[i] = questionOrder[j];
            questionOrder[j] = temp;
        }

        return questionOrder;
    }

    static void PrintQuestionnaire(int number)
    {
        string answer;

        do
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("You went to a party last night and when you arrived to school the next day, everybody is talking about something you didn’t do. What will you do?");
                    Console.WriteLine("A. Avoid everything and go with your friends");
                    Console.WriteLine("B. Go and talk with the person that started the rumors");
                    Console.WriteLine("C. Go and talk with the teacher");

                    break;
                case 1:
                    Console.WriteLine("What quality do you excel the most?");
                    Console.WriteLine("A. Empathy");
                    Console.WriteLine("B. Curiosity");
                    Console.WriteLine("C. Perseverance");

                    break;
                case 2:
                    Console.WriteLine("You are walking down the street when you see an old lady trying to cross, what will you do?");
                    Console.WriteLine("A. Go and help her");
                    Console.WriteLine("B. Go for a policeman and ask him to help");
                    Console.WriteLine("C. Keep walking ahead");

                    break;
                case 3:
                    Console.WriteLine("You had a very difficult day at school, you will maintain a ____ attitude");
                    Console.WriteLine("A. Depends on the situation");
                    Console.WriteLine("B. Positive");
                    Console.WriteLine("C. Negative");

                    break;
                case 4:
                    Console.WriteLine("You are at a party and a friend of yours comes over and offers you a drink, what do you do?");
                    Console.WriteLine("A. Say no thanks");
                    Console.WriteLine("B. Drink it until it is finished");
                    Console.WriteLine("C. Ignore him and get angry at him");

                    break;
                case 5:
                    Console.WriteLine("You just started in a new school, you will...");
                    Console.WriteLine("A. Go and talk with the person next to you");
                    Console.WriteLine("B. Wait until someone comes over you");
                    Console.WriteLine("C. Not talk to anyone");

                    break;
                case 6:
                    Console.WriteLine("In a typical Friday, you would like to..");
                    Console.WriteLine("A. Go out with your close friends to eat");
                    Console.WriteLine("B. Go to a social club and meet more people");
                    Console.WriteLine("C. Invite one of your friends to your house");

                    break;
                case 7:
                    Console.WriteLine("Your relationship with your parents is..");
                    Console.WriteLine("A. I like both equally");
                    Console.WriteLine("B. I like both equally");
                    Console.WriteLine("C. I like my Mom the most");

                    break;
            }

            Console.Write("Your Answer: ");
            answer = Console.ReadLine().ToUpper();
            UserData.GetInstance().GetAnswer(answer);

        } while (answer != "A" && answer != "B" && answer != "C");


    }
}




public class UserData
{
    private static UserData instance;

    public static UserData GetInstance()
    {
        if (instance == null)
        {
            instance = new UserData();
        }
        return instance;
    }

    private int totalA;
    private int totalB;
    private int totalC;
    private int totalAnswer;


    public int TotalA { get => totalA; set => totalA = value; }
    public int TotalB { get => totalB; set => totalB = value; }
    public int TotalC { get => totalC; set => totalC = value; }
    public int TotalAnswer { get => totalAnswer; set => totalAnswer = value; }

    public void GetAnswer(string answer)
    {
        switch(answer)
        {
            case "a":
            case "A":
                TotalA++;
                TotalAnswer++;
                break;
            case "b":
            case "B":
                TotalB++;
                TotalAnswer++;
                break;
            case "c":
            case "C":
                TotalC++;
                TotalAnswer++;
                break;
            default:
                Console.WriteLine("Please choose a, b, or c");
                break;
        }
    }

    public void PostResult()
    {                
        if (TotalA > TotalB && TotalA > TotalC)
        {
            Console.WriteLine("\n \nRESULT");
            Console.WriteLine("Top Answer is A: " + TotalA);
            Console.WriteLine("Empathy You are emphatic. You see yourself in someone else’s situation before doing decisions. You tend to listen to other’s voices.");            
        }
        else if (TotalB > TotalA && TotalB > TotalC)

        {
            Console.WriteLine("\n \nRESULT");
            Console.WriteLine("Top Answer is B: " + TotalB);
            Console.WriteLine("Self-Awareness You are conscious of your own character, feelings, motives, and desires. The process can be painful but it leads to greater self-awareness.");            
        }
        else if (TotalC > TotalA && TotalC > TotalB)
        {
            Console.WriteLine("\n \nRESULT");
            Console.WriteLine("Top Answer is C: " + TotalC);
            Console.WriteLine("Self-Management You manage yourself wel; You take responsibility for your own behavior and wel-being.");            
        }

        
    }
}

