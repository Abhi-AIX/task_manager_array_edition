using System;
using System.Globalization;





string[] tasks = new string[5];
int taskCount = 0;
bool isRunning = true;


while (isRunning)
{
    Console.WriteLine("\n===== Task Manager Menu =====");
    Console.WriteLine("1. Add a Task");
    Console.WriteLine("2. View All Tasks");
    Console.WriteLine("3. Exit");
    Console.WriteLine("4. Search and Update a Task");
    Console.WriteLine("5. Sort Tasks Alphabetically");
    Console.WriteLine("6. Reverse Task Order");
    Console.WriteLine("7. Clear All Tasks");
    Console.WriteLine("8. Demo: Copy Complex Task Items");
    Console.WriteLine("9. Find First Matching Task");
    Console.WriteLine("10. Encrypt & Decrypt Task Title");
    Console.Write("Choose an option (1–14): ");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddTask();
            break;

        case "2":
            ViewTasks();
            break;

        case "3":
            isRunning = false;
            break;

        case "4":
            SearchAndUpdateTask();
            break;

        case "5":
            SortTasks();
            break;

        case "6":
            ReverseTaskOrder();
            break;

        case "7":
            ClearAllTasks();
            break;

        case "8":
            DemoCopyTaskItems();
            break;

        case "9":
            FindFirstMatchMethod();
            break;

        case "10":
            EncryptAndDecryptTask();
            break;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}

void AddTask()
{
    if (taskCount >= tasks.Length)
    {
        Console.WriteLine("Task list full! Cannot add more tasks.");
        return;
    }

    Console.Write("Enter task name: ");
    string taskName = Console.ReadLine();
    tasks[taskCount] = taskName;
    taskCount++;
    Console.WriteLine("Task added successfully!");
}

void ViewTasks()
{
    if (taskCount == 0)
    {
        Console.WriteLine("No tasks found.");
        return;
    }

    Console.WriteLine("\n--- Your Tasks ---");
    for (int i = 0; i < taskCount; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i]}");
    }
}

void SearchAndUpdateTask() {

    //purpose is to learn Array.indexOf(array, object) 
    //Array.indexOf method will return the index first occurrence of element. (In applications we always look for all data that is matching).
    //Think of data in application we often search with .Contains because we don't know exactly what we are searching for.
    //It wont match partial strings looks for exact string (Input).
    //By default it is case sensitive you know it will now work because obviously we need to handle case sensitivity.
    //For Custom classes we need to override .Equals and GetHashCode
    //For large data sets it is slow. It does a linear search


    //When to use -> small and fixed arrays, and looking for exact match.
    //For example you have a microwave and taking user input then we look for exact match because it does have only 4 options reset, pause, start, stop.

    if (taskCount == 0)
    {
        Console.WriteLine("No tasks available to update.");
        return;
    }



    Console.WriteLine("Please enter the task name:");
    string searchTitle = Console.ReadLine();


    if (!string.IsNullOrEmpty(searchTitle))
    {

        //Array.IndexOf will return the return index of first occurance 
        int returnIndex = Array.IndexOf(tasks, searchTitle);

        if (returnIndex >= 0)
        {
            Console.Write("Enter the new task name: ");
            string newTitle = Console.ReadLine();

            tasks[returnIndex] = newTitle;
            Console.WriteLine("Task updated successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }

    }
    else {
        Console.WriteLine("You entered an empty task name.");
    }


}

void SortTasks()
{
    if (taskCount == 0)
    {
        Console.WriteLine("No tasks to sort.");
        return;

    }

    string[] sortTasksArray = new string[taskCount];


    //Array.copy(a,b,c) this method will copy the data from one array to another array. 
    //When to use it and what are limitations:
    //It will copies by index only you can not apply any filtering on it lets says what if we want to generate a array of tasks containing "test" in it we cant not apply logic.
    //you must know the size in advance, if not it doesn't work.
    //Not type safe.


    //When you need a subset of an array use it.
    //if you don't want to work on original array just make a copy and work on it changes on copy will not effect the original array.
    //For complex objects it copies references not deep values so not suggested.

    //Always create a copy before sorting it is best practice because to make sure null values are not there.
    Array.Copy(tasks, sortTasksArray, taskCount);


    //Use Array.sort() for only simple and quick sort in ascending order.
    //This method will sort you original array, so make sure you made a copy of it.
    //This method will not ignore null values will show up at beginning of sorted array.
    //No descending order sorting or any filtering is not supported.
    //If we are working with complex objects it needs more work involved.
    Array.Sort(sortTasksArray);

    foreach (string sortTask in sortTasksArray) { 
    Console.WriteLine($"{sortTask}");

    }

}

void ReverseTaskOrder() {

    if (taskCount == 0)
    {
        Console.WriteLine("No tasks to sort.");
        return;

    }

    string[] reverseTasksArray = new string[taskCount];


    //Copy before reversing - best practice or else it will reverse original array

    Array.Copy(tasks, reverseTasksArray, taskCount);

    //As we have sorted it will be in ascending order
    Array.Sort(reverseTasksArray);

    //Use reverse for descending order
    //We can not reverse just a part of array it applies to entire array, so if required first create a subset with Array.copy() then reverse
    //No filtering or custom logic
    //Works with complex objects no problem.
    Array.Reverse(reverseTasksArray);

    foreach (string reverseTask in reverseTasksArray) {

        Console.Write(reverseTask + " ");
    }

}

void ClearAllTasks()
{
    if (taskCount == 0)
    {
        Console.WriteLine("No tasks to clear.");
        return;
    }

    //Use when you want wipe out everything remember.
    //It will not resize the array it will just reset all values.
    //If it is a complex object contains many fields you need to do it by your yourself.
    Array.Clear(tasks, 0, taskCount);

    //Complex objects

    TaskItem[] task = new TaskItem[taskCount];

    TaskItem temp = task[0];
    
    Array.Clear (tasks, 0, taskCount);

    taskCount = 0;

    // The fields stays in memory and still accessible until garbage collector removes them.
    Console.WriteLine(task);

    Console.WriteLine("All tasks have been cleared.");

}






void DemoCopyTaskItems()
{
    // Step 1: Create original array
    TaskItem[] original = new TaskItem[2];
    original[0] = new TaskItem { Title = "Fix bike", IsCompleted = false };
    original[1] = new TaskItem { Title = "Call mom", IsCompleted = false };

    //As a I am discussing about copying complex objects above lets see how it works

    //Showing even though we are copying the original array in new array the objects in new array still points to same memory location so any changes in shallow copy will affect original
    //To avoid the above problem use deep copy
    TaskItem[] shallowCopy = new TaskItem[2];
    Array.Copy(original, shallowCopy, original.Length);

    shallowCopy[0].Title = "effected by shallow copy";

    //deep copy


    TaskItem[] deepCopy = new TaskItem[2];

    for (int i = 0; i<original.Length; i++)
    {
        deepCopy[i] = new TaskItem
        {
            Title = original[i].Title,
            IsCompleted = original[i].IsCompleted
        };

    }

    deepCopy[0].Title = "effected by deep copy";



    Console.WriteLine("Original Array:");

    foreach (TaskItem item in original)
    {
        Console.Write($"{item.Title}");
    }

    Console.WriteLine("\n");

    Console.WriteLine("shallow Copy:");

    foreach (TaskItem taskItem in shallowCopy)
    {
        Console.Write($"{taskItem.Title}");
    }

    Console.WriteLine("\n");

    Console.WriteLine("Deep Copy:");

    foreach (TaskItem taskItem in deepCopy) {
        Console.Write($"{ taskItem.Title}");
    }



}


 string keyword = "";

bool matchFound(string tasks) { 

    return tasks!=null && tasks.Contains(keyword);
}


void FindFirstMatchMethod() {

    Console.WriteLine("Enter a keyword to search first match in array:");

    keyword = Console.ReadLine();

    //returns the value of the first occurrence
    //need helps method if there is no lambda
    //Returns only first occurrence value not all
    string result = Array.Find(tasks, matchFound);

    //In the same way we have Array.Exists returns boolean value either true or flase

    bool isFound = Array.Exists(tasks, matchFound);

    Console.WriteLine(result);
    Console.WriteLine(isFound);
}

void EncryptAndDecryptTask()
{
    if (taskCount == 0)
    {
        Console.WriteLine("No tasks to encrypt.");
        return;
    }

    Console.Write("Enter task number to encrypt (1 to " + taskCount + "): ");

    if (!int.TryParse(Console.ReadLine(), out int taskNum) || taskNum < 1 || taskNum > taskCount)
    {
        Console.WriteLine("Invalid task number.");
        return;
    }

    string original = tasks[taskNum-1];
    char[] chars = original.ToCharArray();

    Array.Reverse(chars);

    string encrypted = String.Join(",", chars);

    // Use when you want to work with each character individually
    // Example: reverse letters, scramble text, count specific characters
    Console.WriteLine("encrypted :"+ encrypted);

    // Why we are using split hey remember we can not just reverse the words in the string with reverse right.
    // split works with char or string not with others
    // You want to break a sentence or CSV into parts
    string[] splitChars = encrypted.Split(',');
    Array.Reverse(splitChars);

    string decrypted = String.Join("", splitChars);
    Console.WriteLine("decrypted:" + decrypted);


}


public class TaskItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}