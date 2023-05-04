// Import System and System.Collections.Generic
using System;
using System.Collections.Generic;
using System.IO; // added to use StreamWriter


// Define the class Program
class Program
{
  // Define the main method
  static void Main(string[] args)
  {
    // Define the constants
    double m = 100; // mass in kg
    double d = 0.8; // diameter in m
    double c = 0.09; // drag coefficient
    double v0 = 8000; // initial velocity in m/s
    double rho = 1.2; // density of air in kg/m3
    double g = 9.8; // acceleration due to gravity in m/s2

    // Define the initial values of t_n, y_n and f(t_n,y_n)
    List<double> t = new List<double>(); // time in s
    List<double> y = new List<double>(); // vertical velocity in m/s
    List<double> f = new List<double>(); // acceleration in m/s2

    t.Add(0); // add the initial value of t_n to the list t
    y.Add(v0); // add the initial value of y_n to the list y
    f.Add(-m*g - 0.5*c*rho*Math.PI*Math.Pow(d/2,2)*Math.Pow(y[0],2)); // add the initial value of f(t_n,y_n) to the list f

    // Define the step size
    double h = 0.05; // step size in s

    // Use Euler's method to calculate the values of t_n, y_n and f(t_n,y_n) for each step until y_n becomes negative
    while (y[y.Count - 1] > 0)
    {
      // Calculate the next values of t_n, y_n and f(t_n,y_n) using Euler's method
      double t_next = t[t.Count - 1] + h;
      double y_next = y[y.Count - 1] + h*f[f.Count - 1]/m;
      double f_next = -m*g - 0.5*c*rho*Math.PI*Math.Pow(d/2,2)*Math.Pow(y_next,2);

      // Add the next values to the lists
      t.Add(t_next);
      y.Add(y_next);
      f.Add(f_next);
    }
    
    // Print the values of y_n versus t_n for each step
    Console.WriteLine("Time (s)\tVertical Velocity (m/s)");
    for (int i = 0; i < t.Count; i++)
    {
      Console.WriteLine("{0}\t{1}", t[i], y[i]);
    }

    // Create a StreamWriter object to write to a file
    using (StreamWriter sw = new StreamWriter("output.txt"))
    {
      
      // Write the header line
      sw.Write("time (s),");
      sw.WriteLine("V,");

      // Write each pair of t and y values to a new line
      for (int i = 0; i < t.Count; i++)
      {

        sw.WriteLine("{0},{1},",t[i] ,y[i]);
      
      }
      


    }
  }
}