//written by Coutaq
using System;

namespace LabOne
{
    public class GeographicalUnit
    {
        private string Country { get; set; }
        private string Capital { get; set; }
        private int Population { get; set; }
        public enum FormOfGov { US, F }
        private FormOfGov Form { get; set; }
        public GeographicalUnit(string country, string capital, int population, FormOfGov form)
        {
            this.Country = country;
            this.Capital = capital;
            this.Population = population;
            this.Form = form;
        }
        public String getName()
        {
            return Country;
        }
        public int getPopulation()
        {
            return Population;
        }
        public FormOfGov getForm()
        {
            return Form;
        }

        public GeographicalUnit()
        {
        }
        public string getInfoTable()
        {
            String output = String.Format("{0,-10} |{1,-0} |{2,-10} |{3,-2}|", Country, Capital, Population, Form);
            output += "\n--------------------------------------\n";
            return output;
        }
    }
}