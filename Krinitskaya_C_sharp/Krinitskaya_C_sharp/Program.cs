
#region Task_1

var someNumber = ReadValue<int>(Convert.ToInt32);

if (someNumber > 7)
{
    Console.WriteLine("Привет");
}
else
{
    Console.WriteLine("The number less or equal to 7");
}

#endregion

#region Task_2

Console.WriteLine("Enter the name:");
var someStr = Console.ReadLine();
var nameStr = "Вячеслав";

if (someStr == nameStr)
{
    Console.WriteLine($"Привет, {nameStr} !");
}
else
{
    Console.WriteLine("Нет такого имени");
}

#endregion

#region Task_3

int[] myArr = CreateArr();

Console.WriteLine("Elements place divisible to 3:");

for (int i = 0; i < myArr.Length; i++)
{
    if (myArr[i] % 3 == 0)
    {
        Console.WriteLine(myArr[i]);
    }
}

#endregion

#region Task_4

//[((())()(())]] - неправильная скобочная последовательность,
//чтобы сделать правильной надо заменить предпоследнюю квадратную скобку на круглую

//extra:
Console.WriteLine("Is the sequence correct? - " + IsBracketSequenceCorrect("[((())()(())]]"));

#endregion

Console.ReadLine();

static bool IsBracketSequenceCorrect(string seq)
{
    if (seq == null)
        throw new ArgumentNullException();
    if (seq.Length == 0)
        return true;

    var brackSeqStr = seq.ToCharArray();

    int countQ = 0;
    int countE = 0;
    int countF = 0;

    for (int i = 0; i <= brackSeqStr.Length - 1; i++)
    {
        switch (brackSeqStr[i])
        {
            case '{':
                countF++; break;
            case '}':
                countF--; break;
            case '(':
                countE++; break;
            case ')':
                countE--; break;
            case '[':
                countQ++; break;
            case ']':
                countQ--; break;
            default:
                return false;
        }

        if (countF < 0 || countE < 0 || countQ < 0)
        {
            return false;
        }
    }

    return true;
}

static int[] CreateArr()
{
    Console.WriteLine("Enter the lenght of array:");

    var arrLenght = ReadValue<int>(Convert.ToInt32);
    int[] arr = new int[arrLenght];

    for (int i = 0; i <= arrLenght - 1; i++)
    {
        Console.WriteLine("Let's full array");
        arr[i] = ReadValue<int>(Convert.ToInt32);
    }

    return arr;
}

static T ReadValue<T>(ConvertFromString<T> converter)
{
    T val = default;
    var typeName = typeof(T).ToString();
    bool isOK = false;

    while (!isOK)
    {
        Console.WriteLine($"Enter the {typeName} number");

        try
        {
            val = converter(Console.ReadLine());
            isOK = true;
        }
        catch (FormatException)
        {
            Console.WriteLine($"Incorrect {typeName} value was entered. Try again.");
        }
    }
    return val;
}

delegate T ConvertFromString<T>(string s);