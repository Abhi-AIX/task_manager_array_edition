# C# Task Manager – Learn Array and String Methods by Doing

This is a beginner-friendly console application written in C# designed to teach and demonstrate core array methods, string operations, and object handling through a hands-on Task Manager project.

---

## Features Implemented

- Add, view, update, and clear tasks
- Sort and reverse task list
- Search for tasks (exact and keyword-based)
- Copy tasks (shallow and deep copy demonstration)
- Encrypt and decrypt task titles using character-level transformation
- Practice all major Array and String methods in a real application

---

## Concepts Covered

### Array Methods

- `Array.IndexOf()` – Find index of exact match
- `Array.Copy()` – Duplicate contents of an array
- `Array.Sort()` – Sort elements in ascending order
- `Array.Reverse()` – Reverse the order of elements
- `Array.Clear()` – Reset array elements to default values
- `Array.Resize()` – Resize array (if needed manually)
- `Array.Find()` / `Array.Exists()` – Find values or check for matching conditions

### String and Array Methods

- `ToCharArray()` – Convert string to array of characters
- `Split()` – Convert string into array using a delimiter
- `Join()` – Combine array into a string with delimiter
- `new string(char[])` – Create a new string from characters

### Object Handling

- Demonstrated shallow copy vs deep copy
- Custom TaskItem class with properties
- Manual object duplication
- Memory and reference behavior notes

---

## How to Run

Make sure .NET SDK is installed on your system.

```bash
dotnet build
dotnet run
