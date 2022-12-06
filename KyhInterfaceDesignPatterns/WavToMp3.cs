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

    public enum ConverterQuality
    {
        Low,
        Medium,
        High,
        SuperHigh
    }

    public class ConverterQualityFactory
    {
        public IConvertWavToMp3 Create(ConverterQuality action)
        {
            IConvertWavToMp3 strategy = null;
            if (action == ConverterQuality.Low)
                strategy = new LowQualityConverter();
            else if (action == ConverterQuality.Medium)
                strategy = new MediumQualityConverter();
            if (action == ConverterQuality.High)
                strategy = new HighQualityConverter();
            return strategy;
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

    public class GameRules
    {
        private GameRules()
        {
            
        }
        public static GameRules Instance { get; } = new GameRules();
        public bool CanMoveLeft(string player)
        {
            return false;
        } 
    }

    public class WavToMp3
    {

        public void Run()
        {
            
            var gamesRules = GameRules.Instance;
            ;
            var a = gamesRules.CanMoveLeft("dds");



            Console.Write("Ange filnamn:");
            string namn = Console.ReadLine();


            foreach (var enumvarde in Enum.GetNames<ConverterQuality>())
            {
                Console.WriteLine(enumvarde);
            }
            // Console.WriteLine("Low");
            //Console.WriteLine("Medium");
            //Console.WriteLine("High");
            var action = Console.ReadLine();
            var converter = new Converter();
            var factory = new ConverterQualityFactory();
            var quality = Enum.Parse<ConverterQuality>(action);
            var strategy = factory.Create(quality);

            converter.Convert(namn, strategy);
            
        }
    }
}
