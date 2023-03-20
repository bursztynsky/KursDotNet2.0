using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _10_Strumienie
{
    internal class Car
    {
        private string _brand;
        private string _model;
        private int _year;
        private int _lineNumber;

        public Car(string? lineOfValues, int lineNumber)
        {
            _lineNumber = lineNumber;

            if (string.IsNullOrWhiteSpace(lineOfValues))
                throw new Exception("The line " + lineNumber + "  is empty!");

            var variables = lineOfValues.Split(';');

            // jesli teorytcznie dane sa prawidlowo podane to bedziemy mieli 3 wartosci podzielone dwoma srednikami
            // wiec variables.Length powinno wynosic 3
            if (variables.Length != 3)
                throw new Exception("The line " + lineNumber + " has not 3 values");

            // tutaj zakladam ze ilosc danych jest ok, wiec czas na walidacje kazdego z nich
            // MARKA
            var brand = variables[0];

            // sprawdzamy czy nie jest pusty
            if (string.IsNullOrWhiteSpace(brand))
                throw new Exception("The line " + lineNumber + " brand is empty!");

            _brand = brand;

            // BRAND
            var model = variables[1];

            // sprawdzamy czy nie jest pusty
            if (string.IsNullOrWhiteSpace(model))
                throw new Exception("The line " + lineNumber + " model is empty!");

            _model = model;

            // YEAR
            var year = variables[2];

            // sprawdzamy czy nie jest pusty
            if (string.IsNullOrWhiteSpace(year))
                throw new Exception("The line " + lineNumber + " year is empty!");

            var parseResult = int.TryParse(year, out var parsedYear);

            if (parseResult == false)
                throw new Exception("The line " + lineNumber + " year is not a number!");

            _year = parsedYear;

        }

        public override string ToString()
        {
            return "In line " + _lineNumber + " there is a car: Brand=" + _brand + " Model=" + _model + " Year=" + _year;
        }
    }
}
