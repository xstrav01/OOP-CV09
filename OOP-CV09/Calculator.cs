using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace OOP_CV09
{
    class Calculator
    {
        private Stav _stav;
        private Operation _operace;
        private String display;
        private String pamet;
        public string Display { get => display; set => display = value; }
        public string Pamet { get => pamet; set => pamet = value; }

        private String first = "";
        private String second = "";


        public void Tlacitko(String content) {
            string number = "";

            switch (content)
            {
                case "0":
                    number += 0;
                    break;
                case "1":
                    number += 1;
                    break;
                case "2":
                    number += 2;
                                        
                    break;
                case "3":
                    number += 3;
                    break;
                case "4":
                    number += 4;
                    break;
                case "5":
                    number += 5;
                    break;
                case "6":
                    number += 6;
                    break;
                case "7":
                    number += 7;
                    break;
                case "8":
                    number += 8;
                    break;
                case "9":
                    number += 9;
                    break;
                case "+":
                    _stav = Stav.Operace;
                    _operace = Operation.Plus;
                    break;
                case "-":
                    _stav = Stav.Operace;
                    _operace = Operation.Minus;
                    break;
                case "*":
                    _stav = Stav.Operace;
                    _operace = Operation.Multiplication;
                    break;
                case "/":
                    _stav = Stav.Operace;
                    _operace = Operation.Division;
                    break;
                case "=":
                    _stav = Stav.Vysledek;
                    
                    break;
                case "C":
                    _stav = Stav.PrvniCislo;
                    first = "";
                    second = "";
                    Display = "0";

                    break;
                case "CE":
                    if (_stav == Stav.PrvniCislo)
                    {
                        first = "";
                        Display = "";
                    }
                    else if (_stav == Stav.DruheCislo)
                    {
                        second = "";
                        display = "";
                    }
                    break;
                case "<-":
                    if (_stav == Stav.PrvniCislo)
                    {
                        first = first.Substring(0, first.Length - 1);
                        display = first;
                    }
                    if (_stav == Stav.DruheCislo)
                    {
                        second = second.Substring(0, second.Length - 1);
                        display = second;
                    }
                    break;
                default:
                    break;
            }

            display += number; 

            switch (_stav)
            {
                case Stav.PrvniCislo:
                    first += number;
                    break;
                case Stav.Operace:
                    _stav = Stav.DruheCislo;
                    display = "";
                    
                    break;
                case Stav.DruheCislo:
                    second += number;
                    break;
                case Stav.Vysledek:
                    _stav = Stav.DruheCislo;
                    Display = Compute();
                    first = Compute();
                    second = "";
                    break;
                default:
                    break;
            }


        }
        private enum Stav
        {
            PrvniCislo,
            Operace,
            DruheCislo,
            Vysledek
        };

        private enum Operation { 
        
            Plus,
            Minus,
            Division,
            Multiplication
        };

        public String Compute() {
            double f = Convert.ToDouble(first);
            double s = Convert.ToDouble(second);

            switch (_operace)
            {
                case Operation.Plus:
                    return (f + s).ToString();
                    break;
                case Operation.Minus:
                    return (f - s).ToString();
                    break;
                case Operation.Division:
                    return (f / s).ToString();
                    break;
                case Operation.Multiplication:
                    return (f * s).ToString();
                    break;
                default:
                    break;
            }

            return "NaN";
        }
    }
}
