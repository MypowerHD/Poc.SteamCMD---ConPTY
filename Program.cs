// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using SteamCMD.ConPTY;
using SteamCMD.ConPTY.Interop.Definitions;

var arguments = new List<string>()
{
    "@ShutdownOnFailedCommand 1",
    "@sSteamCmdForcePlatformType linux",
    "+force_install_dir D:\\new\\templates\\aaa\\836e773a-dd0f-426c-94ea-b939abe78540",
    "+login anonymous",
    "+app_update 740",
    "+quit"
};

var steamCMDConPTY = new SteamCMDConPTY
{
    Arguments = string.Join(' ', arguments),
    //WorkingDirectory = Path.Combine(Environment.CurrentDirectory, "steamcmd"),
    FilterControlSequences = true,
};

steamCMDConPTY.TitleReceived += (sender, data) => { };

steamCMDConPTY.OutputDataReceived += (sender, data) =>
{
    Console.WriteLine(data);
};

steamCMDConPTY.Exited += (sender, exitCode) =>
{
    
};

ProcessInfo processInfo = steamCMDConPTY.Start();

// Get SteamCMD PID by ProcessInfo
Console.WriteLine(processInfo.dwProcessId);
Console.WriteLine("Hello, World!");