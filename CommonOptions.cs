/*
The MIT License(MIT)
Copyright(c) spsarras 2019.
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.
*/

using CommandLine;

public class CommonOptions
{
    [Option('i', "input", Required = true, HelpText = "Image file to use for synthesis")]
    public string Input { get; set; }

    [Option('w', "Width", Required = false, Default = 10, HelpText = "Width of the target output")]
    public int Width { get; set; }

    [Option('h', "Height", Required = false, Default = 10, HelpText = "Height of the target output")]
    public int Height { get; set; }

    [Option('v', "views", Required = false, Default = 1, HelpText = "Number of different views to get")]
    public int Views { get; set; }

    [Option('r', "RandomSeed", Required = false, Default = 1, HelpText = "Number of different views to get")]
    public int Seed { get; set; }

    [Option('u', "Suffix", Required = false, Default = "", HelpText = "suffix to use in the end to differentiate between multiple samples")]
    public string Suffix { get; set; }

    [Option('o', "Output", Required = false, Default = "", HelpText = "Output Folder")]
    public string Output { get; set; }
}