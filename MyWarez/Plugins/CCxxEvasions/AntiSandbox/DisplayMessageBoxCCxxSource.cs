﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Linq;

using MyWarez.Core;
using MyWarez.Base;


namespace MyWarez.Plugins.CCxxEvasions
{
    // Contract: Returns true if the user clicks "no"
    public interface IDisplayMessageBox : ICCxxSourceIParameterlessCFunction
    {
        public new string Name => "DisplayMessageBox";
    }

    // TODO: User specified message
    public sealed class DisplayMessageBoxCCxxSource : ShellcodeCCxxSource, IDisplayMessageBox, IShellcodeCCxxSourceIParameterlessCFunction, IShellcodeParameterlessCFunction
    {
        private static readonly string ResourceDirectory = Path.Join(Core.Constants.PluginsResourceDirectory, "CCxxEvasions", "AntiSandbox", nameof(DisplayMessageBoxCCxxSource));

        private static readonly string FunctionNamePlaceholder = "DisplayMessageBox";

        public DisplayMessageBoxCCxxSource()
            : base(CreateSource())
        {
            FindAndReplace(SourceFiles, FunctionNamePlaceholder, ((ICFunction)this).Name);

        }

        string ICFunction.ReturnType => "BOOL";
        string ICFunction.Name => ((IDisplayMessageBox)this).Name + GetHashCode();
        public IEnumerable<string> ParameterTypes => null;

        public static ICCxxSource CreateSource()
        {
            var sourceFiles = SourceDirectoryToSourceFiles(ResourceDirectory);
            return new CCxxSource(sourceFiles);
        }
    }
}
