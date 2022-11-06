var result = ProductCreator.GetInstance(ProductType.A) as A;
result.Run();

#region Abstract Product
interface IProduct
{
    void Run();
}
#endregion

#region Concrete Products
class A : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class B : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region Creator

enum ProductType
{
    A, B, C
}
class ProductCreator
{
    public static IProduct GetInstance(ProductType productType)
    {
        IProduct _product = null;
        switch (productType)
        {
            case ProductType.A:
                _product = new A();
                break;
            case ProductType.B:
                _product = new B();
                break;
            case ProductType.C:
                _product = new C();
                break;
            default:
                _product = new A();
                break;
        }
        return _product;
    }
}
#endregion
