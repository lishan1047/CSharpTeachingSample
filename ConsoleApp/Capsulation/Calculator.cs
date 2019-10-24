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
     public class Calculator
     {
         public void Run()
         {
             while(true){
                 this.ShowMenu();
                 this.ChooseMenu();
                 if(_chosenKey.Equals("0")) break;
                 this.InputOperands();
                 System.Console.WriteLine("计算结果：{0}", this.GetResult());
             }
         }

         private void ShowMenu()
         {
            System.Console.WriteLine(@"
                1. 加法
                2. 减法
                3. 乘法
                4. 除法
                0. 退出
            ");
            System.Console.Write("请选择菜单：");
         }

         private string _chosenKey;

         private void ChooseMenu()
         {
             _chosenKey = System.Console.ReadLine();
         }

         private double FirstOperand
         {
             get;
             set;
         }

         private double SecondOperand
         {
             get;
             set;
         }

         private void InputOperands()
         {
             System.Console.Write("输入第一个数：");
             this.FirstOperand = System.Convert.ToDouble(System.Console.ReadLine());
             System.Console.Write("输入第二个数：");
             this.SecondOperand = System.Convert.ToDouble(System.Console.ReadLine());
         }

         private double GetResult()
         {
             if(_chosenKey.Equals("1")){
                 return this.Add(this.FirstOperand, this.SecondOperand);
             } else if(_chosenKey.Equals("2")){
                 return this.Substract(this.FirstOperand, this.SecondOperand);
             } else if(_chosenKey.Equals("3")){
                 return this.Multiple(this.FirstOperand, this.SecondOperand);
             } else if(_chosenKey.Equals("4")){
                 return this.Divide(this.FirstOperand, this.SecondOperand);
             } else {
                 return this.Add(this.FirstOperand, this.SecondOperand);
             }
         }

         public double Add(double first, double second)
         {
             return first + second;
         }
         public double Substract(double first, double second)
         {
             return first - second;
         }
         public double Multiple(double first, double second)
         {
             return first * second;
         }
         public double Divide(double first, double second)
         {
             return first / second;
         }
     }

     public class CalculatorTest
     {
         public static void Test()
         {
             Calculator c = new Calculator();
             c.Run();
         }
     }
 }