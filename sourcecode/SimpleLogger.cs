//=======================================================================
// Titel : C#-Advanced, Aufgabe 1: Logger
// Datei : SimpleLogger.cs
// Autor : J.Jucker
//=======================================================================

using System;
using System.IO;

// Delegate für "LogWriter" erstellen
 delegate void LogWriter(string message);


public class Test
{
    // Klassenvariable vom Typ "LogWriter" erstellen (Name Log)
    private static LogWriter Log;

    // Methode "Print" für Ausgabe auf dem Bildschirm erstellen
    private static void Print(string s)
    {
        Console.WriteLine(s);
    }


    public static void Main(string[] arg)
    {
        // Logger Instanz erstellen
        FileLogger logger = new FileLogger("U:/log.txt");

        // Event für Ausgabe auf dem Bildschirm anmelden
        Log += Print;

        // Event für Ausgabe in File anmelden
        Log += logger.Print; 

        // Logeinträge erstellen
        Log("Log. Loglog.");
        Log("Fail");
        Log("Ups, no fail at all.");

        // Buffer der "Logger" Instanz schreiben und danach schliessen
        logger.Flush();
        logger.Close();

        Console.WriteLine("Press enter to exit");
        Console.ReadLine();
    }

    public class FileLogger
    {
        private StreamWriter w;

        public FileLogger(string path)
        {
            w = File.CreateText(path);
        }

        public void Print(string msg)
        {
            w.WriteLine(msg);
        }

        public void Flush()
        {
            w.Flush();
        }

        public void Close()
        {
            w.Close();
        }
    }
}