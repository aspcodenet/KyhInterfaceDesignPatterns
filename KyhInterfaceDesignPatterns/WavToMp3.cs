using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyhInterfaceDesignPatterns
{
    public interface IConvertWavToMp3
    {
        void Convert(string namn);
    }

    public class HighQualityConverter : IConvertWavToMp3
    {
        public void Convert(string namn)
        {
            Console.WriteLine("Nu körs high");
        }
    }


    public class MediumQualityConverter : IConvertWavToMp3
    {
        public void Convert(string namn)
        {
            Console.WriteLine("Nu körs medium");
        }
    }

    public class LowQualityConverter : IConvertWavToMp3
    {
        public void Convert(string namn)
        {
            Console.WriteLine("Nu körs low");
        }
    }
    public class Converter
    {
        public bool Convert(string namn, IConvertWavToMp3 strategy)
        {
            //Kolla så filen finns
            strategy.Convert(namn);
            return true;
        }
    }
    public class WavToMp3
    {

        public void Run()
        {
            Console.Write("Ange filnamn:");
            string namn = Console.ReadLine();
            Console.WriteLine("1.Low ");
            Console.WriteLine("2.Medium");
            Console.WriteLine("3. High");
            var action = Console.ReadLine();
            var converter = new Converter();
            IConvertWavToMp3 strategy = null;
            if (action == "1")
                strategy = new LowQualityConverter();
            else if (action == "2")
                strategy = new MediumQualityConverter();
            if (action == "3")
                strategy = new HighQualityConverter();

            converter.Convert(namn, strategy);
            
        }
    }
}
