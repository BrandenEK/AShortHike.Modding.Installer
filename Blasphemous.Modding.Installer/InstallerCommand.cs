﻿
using Basalt.CommandParser;

namespace Blasphemous.Modding.Installer;

public class InstallerCommand : CommandData
{
    [StringArgument('g', "github")]
    public string GithubToken { get; set; } = string.Empty;

    [BooleanArgument('i', "ignore")]
    public bool IgnoreTime { get; set; } = false;

    [BooleanArgument('b', "blas")]
    public bool ShowBlasphemous { get; set; } = false;
}
