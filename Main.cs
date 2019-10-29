/*
The MIT License(MIT)
Copyright(c) mxgmn 2016.
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.
*/

using System;
using System.Xml.Linq;
using System.Diagnostics;
using CommandLine;
using System.IO;

static class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        string outputFolder = "";
        Parser.Default.ParseArguments<OverlappingModelOptions, SimpleTiledModelOptions, Examples>(args)
        .WithParsed((Action<OverlappingModelOptions>)(o =>
        {
            var model = new OverlappingModel(o.Sample, o.N, o.Width, o.Height, o.PeriodicInput, o.PeriodicOutput, o.Symmetry, o.Ground);
            outputFolder = o.Output;
            r = new Random(o.Seed);
            for (int i = 0; i < o.Views; i++)
            {
                var parameters = $"Seed={o.Seed} View={i} N={o.N} PeriodicInput={o.PeriodicInput} PeriodicOut={o.PeriodicOutput} Sym={o.Symmetry} Ground={o.Ground}";
                string outputFile = GetOutputFile(o.Sample, o.Suffix, o.Output, parameters);
                SaveModel(model, r.Next(), outputFile);
            }

        }))
        .WithParsed((Action<SimpleTiledModelOptions>)(o =>
        {
            var model = new SimpleTiledModel(o.Sample, o.Config, o.Subset, o.Width, o.Height, o.Periodic, o.Black);
            r = new Random(o.Seed);
            for (int i = 0; i < o.Views; i++)
            {
                var parameters = $"Seed={o.Seed} View={i} Sub={o.Subset} Periodic={o.Periodic} Black={o.Black}";
                string outputFile = GetOutputFile(o.Sample, o.Suffix, o.Output, parameters);
                var finished = SaveModel(model, r.Next(), outputFile);

                if (finished && o.TextOutput)
                {
                    var data = Path.ChangeExtension(outputFile, "txt");
                    File.WriteAllText(data, (model as SimpleTiledModel).TextOutput());
                }
            }

        }))
        .WithParsed((Action<Examples>)(o =>
       {
           Example.Examples();
       }))
        .WithNotParsed(errs => { });

    }

    private static string GetOutputFile(string sample, string suffix, string output, string parameters)
    {
        var filename = Path.GetFileNameWithoutExtension(sample);
        var extention = Path.GetExtension(sample);

        var outputFile = $"{filename} {parameters}{suffix}{extention}";
        outputFile = Path.Combine(output, outputFile);
        if (!output.Equals("") && !Directory.Exists(output))
            Directory.CreateDirectory(output);

        Console.WriteLine($"Writing to File: {outputFile}");
        return outputFile;
    }

    private static bool SaveModel(Model model, int seed, string path)
    {
        var limit = 0;
        var finished = model.Run(seed, limit);
        if (finished)
        {
            var graphic = model.Graphics();
            graphic.Save(path);
        }
        return finished;
    }
}
