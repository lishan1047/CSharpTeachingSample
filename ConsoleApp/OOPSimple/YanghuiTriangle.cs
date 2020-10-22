using System;
namespace ConsoleApp.OOPSimple
{
    public class YanghuiTriangle
    {
        public int[,] Data
        { set; get; }
        public int LevelCount
        { set; get; }
        public void BuildTiangle()
        {
            this.Data = new int[this.LevelCount, this.LevelCount];
            for(int i = 0; i < this.LevelCount; i++) {
                for(int j = 0; j < this.LevelCount; j++) {
                    if(j <= i) {
                        if(j == 0) {
                            this.Data[i, j] = 1;
                        } else {
                            if(i == 0) {
                                this.Data[i, j] = 1;
                            } else {
                                this.Data[i, j] = this.Data[i - 1, j - 1] + this.Data[i - 1, j];
                            }
                        }
                    } else {
                        this.Data[i, j] = 0;
                    }
                }
            }
        }
        public int[] GetData(int i)
        {
            int[] data = new int[i + 1];
            for(int j = 0; j <= i; j++) {
                data[j] = this.Data[i, j];
            }
            return data;
        }
        public void Output()
        {
            for(int i = 0; i < this.LevelCount; i++) {
                Console.Write(new string(' ', 5 * (this.LevelCount - i - 1)));
                for(int j = 0; j < this.LevelCount; j++) {
                    if(j <= i) {
                        Console.Write("{0,-5}{1,-5}", this.Data[i, j], "");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    public class YanghuiTriangleTest
    {
        public static void Test()
        {
            YanghuiTriangle t = new YanghuiTriangle();

            t.LevelCount = 10;

            t.BuildTiangle();

            t.Output();

            int[] iData = t.GetData(3);
            for(int i = 0; i < iData.Length; i++)
            {
                Console.Write("{0,-5}", iData[i]);
            }
        }
    }
}