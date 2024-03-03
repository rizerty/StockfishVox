using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

public class StockfishVox : MonoBehaviour
{
    public string exeFileName = "stockfish-windows-x86-64-sse41-popcnt.exe"; // Specify the file name of the .exe file
    private Process stockfishProcess;
    private Thread outputReaderThread;

    public void EnterStageLeft()
    {
        // Get the path to the executable relative to the Assets folder
        string exeFilePath = Path.Combine(Application.dataPath, exeFileName);

        // Check if the executable file exists
        if (File.Exists(exeFilePath))
        {
            // Start the process with the executable file
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = exeFilePath;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;

            stockfishProcess = new Process();
            stockfishProcess.StartInfo = startInfo;
            stockfishProcess.Start();

            // Start a thread to continuously read from Stockfish's standard output
            outputReaderThread = new Thread(ReadStockfishOutput);
            outputReaderThread.Start();

            // Send "uci" command to Stockfish
            SendCommandToStockfish("uci");
        }
        else
        {
            UnityEngine.Debug.LogError("Stockfish executable file not found: " + exeFilePath);
        }
    }

    private void ReadStockfishOutput()
    {
        while (!stockfishProcess.StandardOutput.EndOfStream)
        {
            string outputLine = stockfishProcess.StandardOutput.ReadLine();
            UnityEngine.Debug.Log(outputLine); // Print Stockfish output to Unity console
        }
    }

    private void SendCommandToStockfish(string command)
    {
        if (stockfishProcess != null && !stockfishProcess.HasExited)
        {
            stockfishProcess.StandardInput.WriteLine(command);
            stockfishProcess.StandardInput.Flush();
        }
    }

    public void Start()
    {
        EnterStageLeft();
    }

    private void OnDestroy()
    {
        if (stockfishProcess != null && !stockfishProcess.HasExited)
        {
            stockfishProcess.StandardInput.WriteLine("quit");
            stockfishProcess.StandardInput.Flush();
            stockfishProcess.WaitForExit();
            stockfishProcess.Close();

            // Stop the output reader thread
            outputReaderThread.Join();
        }
    }
}
