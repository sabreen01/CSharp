//
// // public struct Point
// // {
// //     public int x;
// //     public int y;
// //     
// //     public Point(int x, int y)
// //     {
// //         this.x = x;
// //         this.y = y;
// //     }
// //     
// // }
//
// // public class asset
// // {
// //     public string name;
// //     
// //     public static void Display(asset asset)
// //     {
// //         Console.WriteLine(asset.name);
// //     }
// // }
// //
// // public class stock : asset
// // {
// //     public double price;
// //     
// // }
// //
// // public class house : asset
// // {
// //     public decimal mortgage;
// // }
// public class BaseClass
// {
//     public virtual void Foo() { Console.WriteLine ("BaseClass.Foo"); }
// }
// public class Overrider : BaseClass
// {
//     public sealed override void Foo() { Console.WriteLine ("Overrider.Foo"); }
// }
// public class Hider : BaseClass
// {
//     public override void Foo() { Console.WriteLine ("Hider.Foo"); }
// }
//
//
// internal class Program
// {
//     public static void Main(string[] args)
//     {
//         /*Point p1=new Point();
//         p1.x=12;
//         Point p2=p1;
//         
//         Console.WriteLine(p1.x);
//         Console.WriteLine(p2.x);
//
//         p1.x = 10;
//         
//         Console.WriteLine(p1.x);
//         Console.WriteLine(p2.x);*/
//
//         // Point p = null;
//         // int x = null;
//         // int cardNumber = 12;
//         // string cardName = cardNumber switch
//         // {
//         //     13 => "King",
//         //     12 => "Queen",
//         //     11 => "Jack",
//         //     _ => "Pip card" // equivalent to 'default'
//         // };
//
//         // int foo(int x) => x * 2;
//         // int bar(int x) => x / 2;
//         // Console.WriteLine(foo(3));
//         
//         
//         // string sb = null;
//         // string s = sb?.ToString() ?? "nothig";
//         
//         
//         
//         // stock s = new stock();
//         // house h = new house();
//         // asset a = s; //upcasting
//         // Console.WriteLine(a==s);
//         // Console.WriteLine("-----------------------");
//         // // Console.WriteLine(a.price);
//         // stock s1 = (stock)a;//downcasting
//         // Console.WriteLine(s1==a);
//         // Console.WriteLine("-------------------------");
//         // Console.WriteLine(s1.price);
//         // double shares1 = ((stock)a).price; 
//         // double shares2 = (a as stock).price; 
//         // Console.WriteLine(shares1 == shares2);
//         // Console.WriteLine("-------------------------");
//         // Console.WriteLine(shares2);
//         Overrider over = new Overrider();
//         BaseClass b1 = over;
//         
//         over.Foo(); // Overrider.Foo
//         b1.Foo(); // Overrider.Foo
//         Hider h = new Hider();
//         BaseClass b2 = h;
//         h.Foo(); // Hider.Foo
//         b2.Foo(); // BaseClass.Foo
//
//     }
// }


public class CreditCardPayment : IPaymentStrategy
{
    public void Pay( decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} via Credit Card.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} via PayPal."); 
    }
}
public class BitcoinPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"PAid {amount:C} via BItCoin.");
    }
}

public class CheckoutCart
{
    public IPaymentStrategy? PaymentMethod { get; set; }

    public void ProcessOrder(decimal total)
    {
        if (PaymentMethod != null)
        {
            PaymentMethod.Pay(total);
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
}

//---------------------------------2-------------------

    public class BasicSword : IWeapon
    {
        public string Description => "Iron Sword";

        public int Damage => 10;
    }

    public abstract class WeaponDecorator : IWeapon
    {
        protected IWeapon _weapon; 
        protected WeaponDecorator(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public virtual string Description => _weapon.Description;
        public virtual int Damage => _weapon.Damage;
    }

    public class FireEnhancement : WeaponDecorator
    {
        public FireEnhancement(IWeapon weapon) : base(weapon)
        {
        }
        public override string Description => base.Description + " + Fire";
        public override int Damage => base.Damage+5;
    }


//--------------generic----------
//1

    public class Box<T>
    { 
        T _content;

        public void  Add(T item)
        {
            _content = item;
        }
        
        public T get()=>_content;
        
    }

//2
    public static class Utality
    {
        public static void swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

internal class Program
    {
        private static void Main(string[] args)
        {
            var cart = new CheckoutCart
            {
                PaymentMethod = new CreditCardPayment()
                
            };
            cart.ProcessOrder(100.00m);
            
            cart.PaymentMethod=new BitcoinPayment();
            cart.ProcessOrder(100.00m);
            
            //========================2===========
            IWeapon mySword = new BasicSword();
            Console.WriteLine($"{mySword.Description} ({mySword.Damage} dmg)");
            
            mySword = new  FireEnhancement(mySword);
            Console.WriteLine($"{mySword.Description} ({mySword.Damage} dmg)");
            //-----------------generic-----
            //1
            Box<string> box1 = new Box<string>();
            box1.Add("hello farah");
           Console.WriteLine(box1.get()); 
             Box<int> box2 = new Box<int>();
             box2.Add(1);
             Console.WriteLine(box2.get());
             
             Box<int> box3 = new Box<int>();
             box3.Add(2);
            
             //2
             Console.WriteLine($"box2={box2.get()}, box3={box3.get()}");
             Utality.swap<Box<int>>(ref box2, ref box3);
             Console.WriteLine($"box2={box2.get()}, box3={box3.get()}");
             
             //3
        }
    }
    

