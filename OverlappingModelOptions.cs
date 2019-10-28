/*
The MIT License(MIT)
Copyright(c) mxgmn 2016.
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.
*/

using CommandLine;

[Verb("Overlapping", HelpText = "Run an overlapping type model on the target input")]
public class OverlappingModelOptions
{
    [Option('s', "sample", Required = true, HelpText = "Image file to use for synthesis")]
    public string Sample { get; set; }

    [Option('N', "N_Parameter", Required = false, HelpText = "N parameter")]
    public int N { get; set; }

    [Option('w', "Width", Required = false, Default = 48, HelpText = "Width of the target output")]
    public int Width { get; set; }

    [Option('h', "Height", Required = false, Default = 48, HelpText = "Height of the target output")]
    public int Height { get; set; }

    [Option("PeriodicInput", Required = false, Default = true, HelpText = "Is input periodic")]
    public bool PeriodicInput { get; set; }

    [Option("PeriodicOutput", Required = false, Default = false, HelpText = "should output be periodic")]
    public bool PeriodicOutput { get; set; }

    [Option('y', "Symmetry", Required = false, Default = 8, HelpText = "symmetry parameter")]
    public int Symmetry { get; set; }

    [Option('g', "Ground", Required = false, Default = 0, HelpText = "ground parameter")]
    public int Ground { get; set; }

    [Option('o', "Output", Required = false, Default = "", HelpText = "Output Folder")]
    public string Output { get; set; }

    [Option('u', "Suffix", Required = false, Default = "", HelpText = "suffix to use in the end to differentiate between multiple samples")]
    public string Suffix { get; set; }
}


[Verb("Examples", HelpText = "Run all the example models")]
public class Examples
{

}