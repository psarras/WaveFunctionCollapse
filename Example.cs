using System;
using System.Diagnostics;
using System.Xml.Linq;

class Example
{
    public static void Examples()
    {
        Stopwatch sw = Stopwatch.StartNew();

        Random random = new Random();
        XDocument xdoc = XDocument.Load("samples.xml");

        int counter = 1;
        foreach (XElement xelem in xdoc.Root.Elements("overlapping", "simpletiled"))
        {
            Model model;
            string name = xelem.Get<string>("name");
            Console.WriteLine($"< {name}");
            string path = $"samples/{name}.png";

            if (xelem.Name == "overlapping")
                model = new OverlappingModel(path, xelem.Get("N", 2), xelem.Get("width", 48), xelem.Get("height", 48),
                xelem.Get("periodicInput", true), xelem.Get("periodic", false), xelem.Get("symmetry", 8), xelem.Get("ground", 0));
            else if (xelem.Name == "simpletiled")
            {
                var config = $"samples/{name}/data.xml";
                model = new SimpleTiledModel(name, config, xelem.Get<string>("subset"),
                xelem.Get("width", 10), xelem.Get("height", 10), xelem.Get("periodic", false), xelem.Get("black", false));
            }
            else
                continue;

            for (int i = 0; i < xelem.Get("screenshots", 2); i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    Console.Write("> ");
                    int seed = random.Next();
                    bool finished = model.Run(seed, xelem.Get("limit", 0));
                    if (finished)
                    {
                        Console.WriteLine("DONE");

                        model.Graphics().Save($"{counter} {name} {i}.png");
                        if (model is SimpleTiledModel && xelem.Get("textOutput", false))
                            System.IO.File.WriteAllText($"{counter} {name} {i}.txt", (model as SimpleTiledModel).TextOutput());

                        break;
                    }
                    else Console.WriteLine("CONTRADICTION");
                }
            }

            counter++;
        }

        Console.WriteLine($"time = {sw.ElapsedMilliseconds}");
    }
}