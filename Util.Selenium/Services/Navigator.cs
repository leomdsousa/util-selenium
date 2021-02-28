using System;
using System.Collections.Generic;
using Util.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Util.Selenium.Services
{
    public class Navigator
    {
        public Navigator()
        { 
        }

    public static void Navigate(string url)
        {
            Driver._driver.Navigate().GoToUrl(url);
            Console.WriteLine("Carregado site com sucesso");
        }
        public static void Close()
        {
            Driver._driver.Close();
            Console.WriteLine("Fechado com sucesso");
        }
        public static void Escreve(string element, string text, ElementTag elementTag)
        {
            if (elementTag == ElementTag.Id)
                Driver._driver.FindElement(By.Id(element)).SendKeys(text);
            if (elementTag == ElementTag.Name)
                Driver._driver.FindElement(By.Name(element)).SendKeys(text);
            if (elementTag == ElementTag.Class)
                Driver._driver.FindElement(By.ClassName(element)).SendKeys(text);

            Console.WriteLine("Digitado com sucesso");
        }
        public static void Clica(string element, ElementTag elementTag)
        {
            if (elementTag == ElementTag.Id)
                Driver._driver.FindElement(By.Id(element)).Click();
            if (elementTag == ElementTag.Name)
                Driver._driver.FindElement(By.Name(element)).Click();
            if (elementTag == ElementTag.Class)
                Driver._driver.FindElement(By.ClassName(element)).Click();

            Console.WriteLine("Clicado com sucesso");
        }
        public static void SelecionaDropDown(string element, string textoSelecionado, ElementTag elementTag)
        {
            if (elementTag == ElementTag.Id)
                new SelectElement(Driver._driver.FindElement(By.Id(element))).SelectByText(textoSelecionado);
            if (elementTag == ElementTag.Name)
                new SelectElement(Driver._driver.FindElement(By.Name(element))).SelectByText(textoSelecionado);
            if (elementTag == ElementTag.Class)
                new SelectElement(Driver._driver.FindElement(By.ClassName(element))).SelectByText(textoSelecionado);

            Console.WriteLine("Selecionado com sucesso");
        }
        public static string GetValue(string element, string textoSelecionado, ElementTag elementTag)
        {
            if (elementTag == ElementTag.Id)
                return Driver._driver.FindElement(By.Id(element)).GetAttribute("value");
            if (elementTag == ElementTag.Name)
                return Driver._driver.FindElement(By.Name(element)).GetAttribute("value");
            if (elementTag == ElementTag.Class)
                return Driver._driver.FindElement(By.ClassName(element)).GetAttribute("value");

            return String.Empty;
        }
        public static string GetTextFromTag(string element, ElementTag elementTag)
        {
            if (elementTag == ElementTag.Id)
                return Driver._driver.FindElement(By.Id(element)).Text;
            if (elementTag == ElementTag.Name)
                return Driver._driver.FindElement(By.Name(element)).Text;
            if (elementTag == ElementTag.Class)
                return Driver._driver.FindElement(By.ClassName(element)).Text;

            return String.Empty;
        }
        public static string GetValueFromDropDown(string element, ElementTag elementTag)
        {
            if (elementTag == ElementTag.Id)
                return new SelectElement(Driver._driver.FindElement(By.Id(element))).SelectedOption.Text;
            if (elementTag == ElementTag.Name)
                return new SelectElement(Driver._driver.FindElement(By.Name(element))).SelectedOption.Text;
            if (elementTag == ElementTag.Class)
                return new SelectElement(Driver._driver.FindElement(By.ClassName(element))).SelectedOption.Text;

            return String.Empty;
        }
        public static List<string> GetAllValuesFromDropDown(string element, ElementTag elementTag)
        {
            List<string> valuesList = new List<string>();

            if (elementTag == ElementTag.Id)
            {
                foreach (var item in new SelectElement(Driver._driver.FindElement(By.Id(element))).Options)
                {
                    valuesList.Add(item.Text);
                }

                return valuesList;
            }

            if (elementTag == ElementTag.Name)
            {
                foreach (var item in new SelectElement(Driver._driver.FindElement(By.Name(element))).Options)
                {
                    valuesList.Add(item.Text);
                }

                return valuesList;
            }
            if (elementTag == ElementTag.Class)
            {
                foreach (var item in new SelectElement(Driver._driver.FindElement(By.ClassName(element))).Options)
                {
                    valuesList.Add(item.Text);
                }

                return valuesList;
            }

            return new List<string>();
        }
        public static IList<IWebElement> GetSelectedObjectFromDropDown(string element, ElementTag elementTag)
        {
            if (elementTag == ElementTag.Id)
                return new SelectElement(Driver._driver.FindElement(By.Id(element))).AllSelectedOptions;
            if (elementTag == ElementTag.Name)
                return new SelectElement(Driver._driver.FindElement(By.Name(element))).AllSelectedOptions;
            if (elementTag == ElementTag.Class)
                return new SelectElement(Driver._driver.FindElement(By.ClassName(element))).AllSelectedOptions;

            return null;
        }
        public static IList<IWebElement> GetAllObjectsFromDropDown(string element, ElementTag elementTag)
        {
            if (elementTag == ElementTag.Id)
                return new SelectElement(Driver._driver.FindElement(By.Id(element))).Options;
            if (elementTag == ElementTag.Name)
                return new SelectElement(Driver._driver.FindElement(By.Name(element))).Options;
            if (elementTag == ElementTag.Class)
                return new SelectElement(Driver._driver.FindElement(By.ClassName(element))).Options;

            return null;
        }
    }
}
