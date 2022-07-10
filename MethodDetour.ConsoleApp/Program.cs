using MethodDetour.MyAttempt;
using System;

namespace MethodDetour.ConsoleApp;

class Program
{
    public static void Main()
    {
        SomeNotAllovedClassForModify.DoSmth("Hello world"); // Origin: Hello world

        var source = typeof(SomeNotAllovedClassForModify)
            .GetMethod(nameof(SomeNotAllovedClassForModify.DoSmth)); // "DoSmth"
        var dest = typeof(OurOverridedMethod)
            .GetMethod(nameof(OurOverridedMethod.DoSmth)); // "DoSmth"

        MemoryReplacer.DetourMethod(source, dest);

        SomeNotAllovedClassForModify.DoSmth("Hello world"); // Overrided: Hello world
    }
}

sealed class SomeNotAllovedClassForModify
{
    public static void DoSmth(string arg)
    {
        Console.WriteLine("Original: " + arg);
    }
}

class OurOverridedMethod
{
    public static void DoSmth(string arg)
    {
        Console.WriteLine("Overrided: " + arg);
    }
}