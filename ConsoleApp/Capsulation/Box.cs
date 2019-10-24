/*
封装：隐藏对象行为细节，只向外界提供可操纵的接口。
技术：
（1）属性化；
（2）访问控制；
（3）构造函数；
（4）方法/函数；
（5）接口化
 */

 namespace Capsulation
 {
     /// <summary>
     /// 封装技术：
     /// （1）属性化
     /// （2）访问控制
     /// （3）构造函数
     /// （4）方法
     /// </summary>
     public class Box
     {
         public Box(double width, double height, double length)
         {
             this.Width = width;
             this.Height = height;
             this.Length = length;
         }

         public Box() : this(5, 5, 5)
         {
         }

         public double Width
         {
             get;
             private set;
         }

         public double Height
         {
             get;
             private set;
         }

         public double Length
         {
             get;
             private set;
         }

         public double GetSurfaceArea()
         {
             return 2*(
                this.Width * this.Height +
                this.Width * this.Length +
                this.Height * this.Length);
         }

         public double GetVolume()
         {
             return this.Width * this.Height * this.Length;
         }
     }

     public class BoxTest
     {
         public static void Test()
         {
            Box b = new Box(5, 3, 6);
            System.Console.WriteLine("The box surface area is {0}, volume is {1}", 
                b.GetSurfaceArea(), b.GetVolume());
            b = new Box();
            System.Console.WriteLine("The box surface area is {0}, volume is {1}", 
                b.GetSurfaceArea(), b.GetVolume());
         }
     }
 }