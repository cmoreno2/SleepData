// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    
    // random number generator
    Random rnd = new Random();
    // create file
    StreamWriter sw = new StreamWriter("data.txt");
    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy}, {string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
//Parse data file
string file = "data.txt";
StreamReader sr = new StreamReader(file);
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
            // convert string to array
            string[] arr = line.Split(',');
            string[] data = arr[1].Split('|');
            DateTime dt = DateTime.Parse(arr[0]);
                // display array data
                Console.WriteLine($"Week of {dt:MMM}, {dt:dd}, {dt:yyyy}");
                Console.WriteLine("Su Mo Tu We Th Fr Sa");
                Console.WriteLine("-- -- -- -- -- -- --");
                Console.WriteLine("{0,2} {1,2} {2,2} {3,2} {4,2} {5,2} {6,2}", data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
            Console.WriteLine("");
            }
            sr.Close();
}
