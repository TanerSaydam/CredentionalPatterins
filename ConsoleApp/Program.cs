//new Example();
//new Example();
//new Example();
//new Example();
//new Example();

Example ex1 = Example.GetInstance;
Example ex2 = Example.GetInstance;
Example ex3 = Example.GetInstance;
Example ex4 = Example.GetInstance;
Example ex5 = Example.GetInstance;
Example ex6 = Example.GetInstance;
class Example
{
    public static Example _example; 
    static Example()
    {
        _example = new Example();
    }
    public static Example GetInstance
    {
        #region 1. Yöntem
        //get
        //{
        //    if (_example == null)
        //        _example = new Example();
        //    return _example;
        //}
        #endregion

        #region 2. Yöntem
        get
        {
            return _example;
        }
        #endregion
    }
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi üretildi!");
    }


}