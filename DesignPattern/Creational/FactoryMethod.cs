
using static PizzaFactory;

public interface IPizza
{
    decimal GetPrice();
}
public class HamAndMushroomPizza : IPizza
{
    private decimal price = 8.5M;
    public decimal GetPrice() { return price; }
}
public class DeluxePizza : IPizza
{
    private decimal price = 10.5M;
    public decimal GetPrice() { return price; }
}
public class SeafoodPizza : IPizza
{
    private decimal price = 11.5M;
public decimal GetPrice() { return price; }
}

public class PizzaFactory
{
public enum PizzaType
{
    HamMushroom, Deluxe, Seafood
}
public IPizza CreatePizza(PizzaType pizzaType)
    {
        IPizza pizza= null ;
        switch (pizzaType)
        {
            case PizzaType.HamMushroom:
                pizza = new HamAndMushroomPizza(); 
                break;
            case PizzaType.Deluxe:
                pizza = new DeluxePizza(); 
                break;
            case PizzaType.Seafood:
                pizza = new SeafoodPizza(); 
                break;
        }
            return pizza;
    }
}


