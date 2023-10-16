using RateRIR;


Console.WriteLine("Witaj w programie do subiektywnej oceny ciężkości serii wyciskania na ławce poziomej metodą RIR");
Console.WriteLine("__________________________________________________________________");
Console.WriteLine();
Console.WriteLine("Jak masz na imię? ");
var name = Console.ReadLine();
Console.WriteLine($"Witaj {name}");

var ex = new ExerciseInFile();
ex.RatingAdded += EmpRateAdded;

void EmpRateAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano ocenę dla serii");
}

Console.WriteLine("wybierz jedną z podanych opcji: d - dodaj ocenę dla serii, s - pokaż statystyki, m - pokaz menu, q - wyjdź");
string select = Console.ReadLine();

bool isOpen = true;

while (isOpen)
{
    if (select != "d" && select != "s" && select != "m" && select != "q")
    {
        Console.WriteLine("Nie ma takiego wyboru!, przechodzisz do menu");
        select = "m";
    }
    else
    {
        switch (select)
        {
            case "m":
                Console.WriteLine("Wybierz jedną z podanych opcji: d - dodaj ocenę dla serii, s - pokaż statystyki, m - pokaz menu, q - wyjdź");
                select = Console.ReadLine();
                break;
            case "d":
                Console.WriteLine("Podaj ocenę dla serii metodą RIR(5 - 5 powtórzeń w zapasie, 0 - 0 powtórzeń w zapasie) lub wróć wciskająć q");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    select = "m";
                    break;
                }

                try
                {
                    ex.AddRating(input);
                    select = "m";
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception catched: {e.Message}");
                }
                break;

            case "s":
                var statistics = ex.GetStatistics();
                Console.WriteLine($"Średnia ciężkość serii wynosi: {statistics.Average}");
                Console.WriteLine($"Najmniejsza ilość powtórzeń w zapasie w serii: {statistics.Min}");
                Console.WriteLine($"Największa ilość powtórzeń w zapasie w serii: {statistics.Max}");
                select = "m";
                break;
            case "q":
                isOpen = false;
                Console.WriteLine("Dziękuję za skorzystanie z mojego programu!");
                Console.WriteLine("Oby twój następny trening był tym najlepszym!");
                break;
        }
    }
}






