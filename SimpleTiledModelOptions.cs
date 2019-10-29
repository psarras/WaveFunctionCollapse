/*
The MIT License(MIT)
Copyright(c) spsarras 2019.
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.
*/

using CommandLine;

[Verb("SimpleTiled", HelpText = "Run an SimpleTiled type model on the target input")]
public class SimpleTiledModelOptions : CommonOptions
{
    [Option('c', "Config", Required = true, HelpText = "Configuration for tile relation")]
    public string Config { get; set; }

    [Option('t', "subset", Required = false, Default = "", HelpText = "Image file to use for synthesis")]
    public string Subset { get; set; }

    [Option('p', "Periodic", Required = false, Default = false, HelpText = "periodic parameter")]
    public bool Periodic { get; set; }

    [Option('b', "Black", Required = false, Default = false, HelpText = "black parameter")]
    public bool Black { get; set; }

    [Option('d', "TextOutput", Required = false, Default = false, HelpText = "Save output to text")]
    public bool TextOutput { get; set; }
}
