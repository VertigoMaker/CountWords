using System;
using System.IO;
using System.Collections.Generic;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу");
            string path = Console.ReadLine();

            LiterDictionary dictionary = countLiters(path);

            Console.WriteLine("Всего символов: " + dictionary._count);
            foreach(Liter iter_liter in dictionary._liters)
            {
                Console.WriteLine($"Символ {iter_liter._value} в процентах");
                double percents = (iter_liter._count / (double)dictionary._count) * 100;
                Console.WriteLine((int) percents);
            }

            Console.ReadKey();
        }

        static LiterDictionary countLiters(string path)
        {
            LiterDictionary dictionary = new LiterDictionary(new List<Liter>());
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    char current_liter = Char.ToLower(Convert.ToChar(reader.Read()));
                    if (!Char.IsWhiteSpace(current_liter))
                    {
                       dictionary._count++;
                        int j = -1;
                       for(int i=0;i<dictionary._liters.Count;i++)
                        {
                            if(dictionary._liters[i]._value == current_liter)
                            {
                                j = i;
                            }
                        }
                        // нашли такой символ в массиве
                        if (j != -1)
                        {
                            dictionary._liters[j] = new Liter(current_liter, dictionary._liters[j]._count + 1);
                        }
                        else
                        {
                            dictionary._liters.Add(new Liter(current_liter, 1));
                        }
                    }
                }
            }
            return dictionary;
        }
        
    }

    struct Liter
    {
        public char _value;
        public int _count;
        public Liter(char value, int count)
        {
            _value = value;
            _count = count; 
        }
    }
    struct LiterDictionary
    {
        public int _count;
        public List<Liter> _liters;
        public LiterDictionary(List<Liter> liters)
        {
            _liters = liters;
            _count  = 0;
        }
    }
}