using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EnviarMensajesWhatsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener el número de teléfono del destinatario
            Console.WriteLine("Introduce el número de teléfono del destinatario:");
            string numeroTelefono = Console.ReadLine();

            // Obtener el mensaje a enviar
            Console.WriteLine("Introduce el mensaje a enviar:");
            string mensaje = Console.ReadLine();

            // Iniciar WhatsApp Web
            WebDriver driver = new ChromeDriver();

            // Navegar a WhatsApp Web
            driver.NavigateTo("https://web.whatsapp.com/");

            // Esperar a que se cargue WhatsApp Web
            bool isLoggedIn = false;
            while (!isLoggedIn)
            {
                try
                {
                    isLoggedIn = driver.FindElementById("action-button").IsDisplayed;
                }
                catch (Exception)
                {
                    // Esperar 1 segundo
                    System.Threading.Thread.Sleep(1000);
                }
            }

            // Encontrar el cuadro de texto de mensajes
            WebElement cuadroTextoMensajes = driver.FindElementByXPath("//*[@id=\"main\"]/div[2]/div[1]/div[2]/div[1]/div/div/div[2]/div/div[1]/div/div/div/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div/div[1]/div[1]");

            // Enviar el mensaje
            cuadroTextoMensajes.SendKeys(numeroTelefono + "\n" + mensaje);

            // Cerrar WhatsApp Web
            driver.Close();
        }
    }
}
