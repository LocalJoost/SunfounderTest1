using System;
using System.Threading;
using WiringPi;

namespace SunfounderTest
{
  class Program
  {
    const int LedPinRed = 0;
    const int LedPinGreen = 1;
    const int LedPinBlue = 2;

    static void Main(string[] args)
    {
      if (Init.WiringPiSetup() != -1)
      {
        SoftPwm.Create(LedPinRed, 0, 100);
        SoftPwm.Create(LedPinGreen, 0, 100);
        SoftPwm.Create(LedPinBlue, 0, 100);
        Console.WriteLine("Init succeeded");

        for (var i = 1; i < 3; i++)
        {
          ShowColor(255, 0, 0, "Red");
          ShowColor(0, 255, 0, "Green");
          ShowColor(0, 0, 255, "Blue");
          ShowColor(255, 255, 0, "Yellow");
          ShowColor(255, 0, 255, "Pink");
          ShowColor(0, 255, 255, "Cyan");
          ShowColor(195, 0, 255, "Purple");
          ShowColor(255, 255, 255, "White");
        }

        SoftPwm.Stop(LedPinRed);
        SoftPwm.Stop(LedPinGreen);
        SoftPwm.Stop(LedPinBlue);
      }
      else
      {
        Console.WriteLine("Init failed");
      }
    }

    private static void ShowColor(int r, int g, int b, string label)
    {
      SetLedColor(r, g, b);
      Console.WriteLine(label);
      Thread.Sleep(1000);
    }

    private static void SetLedColor(int r, int g, int b)
    {
      SoftPwm.Write(LedPinRed, r);
      SoftPwm.Write(LedPinGreen, g);
      SoftPwm.Write(LedPinBlue, b);
    }
  }
}
