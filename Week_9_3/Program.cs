Console.WriteLine("");

new MyClass();
new MyClass();
new MyClass();
new MyClass();

class MyClass
{
    static MyClass()
    {
        Console.WriteLine("Static Constructor");
    }

    public MyClass()
    {
        Console.WriteLine("Instance Created!");
    }
}
