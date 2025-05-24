// See https://aka.ms/new-console-template for more information
using System;

public class Student
{
    public int IndexNumber { get; set; }
    public string Name { get; set; }
    public double GPA { get; set; }
    public int AdmissionYear { get; set; }
    public string NIC { get; set; }

    public Student(int indexNumber, string name, double gpa, int admissionYear, string nic)
    {
        IndexNumber = indexNumber;
        Name = name;
        GPA = gpa;
        AdmissionYear = admissionYear;
        NIC = nic;
    }

    public override string ToString()
    {
        return $"Index Number: {IndexNumber}, Name: {Name}, GPA: {GPA}, Admission Year: {AdmissionYear}, NIC: {NIC}";
    }
}

public class Node
{
    public Student Data { get; set; }
    public Node Next { get; set; }

    public Node(Student data)
    {
        Data = data;
        Next = null;
    }
}

public class StudentLinkedList
{
    private Node head;

    public StudentLinkedList()
    {
        head = null;
    }

    
    public void Insert(Student newStudent)
    {
        Node newNode = new Node(newStudent);

        if (head == null)
        {
            head = newNode;
            Console.WriteLine($"Student with Index Number {newStudent.IndexNumber} inserted.");
            return;
        }

        if (newStudent.IndexNumber < head.Data.IndexNumber)
        {
            newNode.Next = head;
            head = newNode;
            Console.WriteLine($"Student with Index Number {newStudent.IndexNumber} inserted.");
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Data.IndexNumber < newStudent.IndexNumber)
        {
            if (current.Data.IndexNumber == newStudent.IndexNumber)
            {
                Console.WriteLine($"Error: Student with Index Number {newStudent.IndexNumber} already exists.");
                return;
            }
            current = current.Next;
        }

        
        if (current.Data.IndexNumber == newStudent.IndexNumber)
        {
            Console.WriteLine($"Error: Student with Index Number {newStudent.IndexNumber} already exists.");
            return;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
        Console.WriteLine($"Student with Index Number {newStudent.IndexNumber} inserted.");
    }

    
    public Student Search(int indexNumber)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.IndexNumber == indexNumber)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null; 
    }

    
    public void Remove(int indexNumber)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty. Cannot remove.");
            return;
        }

        if (head.Data.IndexNumber == indexNumber)
        {
            head = head.Next;
            Console.WriteLine($"Student with Index Number {indexNumber} removed.");
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Data.IndexNumber != indexNumber)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
            Console.WriteLine($"Student with Index Number {indexNumber} removed.");
        }
        else
        {
            Console.WriteLine($"Student with Index Number {indexNumber} not found.");
        }
    }

    
    public void PrintAllStudents()
    {
        if (head == null)
        {
            Console.WriteLine("No students in the list.");
            return;
        }

        Console.WriteLine("--- All Students ---");
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
        Console.WriteLine("--------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        StudentLinkedList studentList = new StudentLinkedList();

        while (true)
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Insert Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Print All Students");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n--- Insert New Student ---");
                    Console.Write("Enter Index Number (e.g., 2025XXX): ");
                    if (!int.TryParse(Console.ReadLine(), out int indexNumber))
                    {
                        Console.WriteLine("Invalid Index Number format.");
                        break;
                    }
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter GPA: ");
                    if (!double.TryParse(Console.ReadLine(), out double gpa))
                    {
                        Console.WriteLine("Invalid GPA format.");
                        break;
                    }
                    Console.Write("Enter Admission Year: ");
                    if (!int.TryParse(Console.ReadLine(), out int admissionYear))
                    {
                        Console.WriteLine("Invalid Admission Year format.");
                        break;
                    }
                    Console.Write("Enter NIC: ");
                    string nic = Console.ReadLine();

                    Student newStudent = new Student(indexNumber, name, gpa, admissionYear, nic);
                    studentList.Insert(newStudent);
                    break;

                case "2":
                    Console.Write("\nEnter Index Number to search: ");
                    if (!int.TryParse(Console.ReadLine(), out int searchIndex))
                    {
                        Console.WriteLine("Invalid Index Number format.");
                        break;
                    }
                    Student foundStudent = studentList.Search(searchIndex);
                    if (foundStudent != null)
                    {
                        Console.WriteLine("\n--- Student Found ---");
                        Console.WriteLine(foundStudent);
                        Console.WriteLine("---------------------");
                    }
                    else
                    {
                        Console.WriteLine($"\nStudent with Index Number {searchIndex} not found.");
                    }
                    break;

                case "3":
                    Console.Write("\nEnter Index Number to remove: ");
                    if (!int.TryParse(Console.ReadLine(), out int removeIndex))
                    {
                        Console.WriteLine("Invalid Index Number format.");
                        break;
                    }
                    studentList.Remove(removeIndex);
                    break;

                case "4":
                    studentList.PrintAllStudents();
                    break;

                case "5":
                    Console.WriteLine("Exiting program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
