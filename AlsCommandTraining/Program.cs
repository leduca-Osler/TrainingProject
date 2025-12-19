// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using TrainingConsoleProject;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

Game MyGame;

MyGame = JSONSerializationHelpers.ReadFromJSONFile("data\\TrainingProject.bin");

Console.WriteLine(MyGame.display());
 