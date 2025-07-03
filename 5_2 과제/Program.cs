string current = "1";

for (int count = 1; count <= 20; count++)
{
    Console.WriteLine($"{count}번째 수열: {current}");

    string next = "";
    int i = 0;

    while (i < current.Length)
    {
        char digit = current[i];
        int runLength = 1;

        while (i + 1 < current.Length && current[i + 1] == digit)
        {
            runLength++;
            i++;
        }

        next += digit + runLength.ToString();
        i++;
    }

    current = next;
}
