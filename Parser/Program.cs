﻿using System;
using System.Threading.Tasks;
using Parser.StaticSearcher;
using Parser.ITextElements;
using System.Configuration;

namespace Parser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IParser f = new Parser();
            IText text = await f.Parse(ConfigurationManager.AppSettings["Path"]);

            Searcher s = new Searcher(text);
            s.GetWordsAndShow();

            Console.Write("Save result? (yes - y, no - n):");

            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
                ResultSaver.Save(ConfigurationManager.AppSettings["PathToSave"], s.GetResult());
                Console.WriteLine("Result saved");
            }
        }
    }
}
