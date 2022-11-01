
//Example ex = Example.GetInstance();
var t1 = Task.Run(() =>
{
    Example.GetInstance();
});

var t2 = Task.Run(() =>
{
    Example.GetInstance();
});

//await Task.WhenAll(t1, t2);

var t3 = Task.Run(() =>
{
    Example.GetInstance();
});

var t4 = Task.Run(() =>
{
    Example.GetInstance();
});

await Task.WhenAll(t1, t2,t3, t4);

class Example
{
    static Example()
    {
        _example = new Example();
    }
    //static object _obj = new object();
    public static Example GetInstance()
    {
        //lock (_obj)
        //{
        //    if (_example == null)
        //        _example = new Example();
        //}
       
        return _example;
    }
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} is created.");
    }

    static Example _example;
}