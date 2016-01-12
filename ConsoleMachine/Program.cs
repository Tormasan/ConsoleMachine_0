using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Accord.Controls;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math;
using Accord.Statistics.Kernels;
using Accord.IO;
using System.Data;
using Accord.Statistics;
using Accord.Statistics.Models.Regression.Linear;

namespace ConsoleMachine
{
    class Program
    {
        [MTAThread]
        static void Main(string[] args)
        {
            DataTable tableAttHp= new ExcelReader("HsAttHp.xlsx").GetWorksheet("Sheet1");
            double[][] tableAttHpMatrix = tableAttHp.ToArray<double>();

            DataTable tableCost = new ExcelReader("HsCost.xlsx").GetWorksheet("Sheet1");
            double[] tableCostMatrix = tableCost.Columns[0].ToArray<double>();

            //double[,] scores = Accord.Statistics.Tools.ZScores(tableAttHpMatrix);

            //double[,] centered = Accord.Statistics.Tools.Center(tableAttHpMatrix);

            //double[,] standard = Accord.Statistics.Tools.Standardize(tableAttHpMatrix);

            //foreach (double i  in scores ) { Console.WriteLine(i); }
            //Console.ReadKey();
            //foreach (double i in centered) { Console.WriteLine(i); }
            //Console.ReadKey();
            //foreach (double i in standard) { Console.WriteLine(i); }

            // Plot the data
            //ScatterplotBox.Show("Hs", tableAttHpMatrix, tableCostMatrix).Hold();

            var target = new MultipleLinearRegression(2, true);

            double error = target.Regress(tableAttHpMatrix, tableCostMatrix);

            double a = target.Coefficients[0]; // a = 0
            double b = target.Coefficients[1]; // b = 0
            double c = target.Coefficients[2]; // c = 1
            

            Console.WriteLine(a + " " + b + " " + c);
            Console.ReadKey();

            double[] inputs = { 2005, 2006, 2007, 2008, 2009,2010,2011 };
            double[] outputs = { 12,19,29,37,45,23,33 };

            // Create a new simple linear regression
            SimpleLinearRegression regression = new SimpleLinearRegression();

            // Compute the linear regression
            regression.Regress(inputs, outputs);

            // Compute the output for a given input. The
            double y = regression.Compute(85); // The answer will be 28.088

            // We can also extract the slope and the intercept term
            // for the line. Those will be -0.26 and 50.5, respectively.
            double s = regression.Slope;
            double cut = regression.Intercept;

            Console.WriteLine(s+"x+"+ cut);

            Console.ReadKey();
        }
    }
}
