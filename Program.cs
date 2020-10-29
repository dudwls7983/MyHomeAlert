using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace MyHomeAlert
{
    static class Program
    {
        // The subfolder, where the cefsharp files will be moved to
        private static string cefSubFolder = @"Lib\cefsharp";
        private static string hapSubFolder = @"Lib\HtmlAgilityPack";
        // If the assembly resolver loads cefsharp from another folder, set this to true
        private static bool resolved = false;

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Release 모드에서 Assembly Resolve를 사용하기 위한 이벤트 체인 추가
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            InitializeCefSharp();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void InitializeCefSharp()
        {
            var settings = new CefSettings();
            // 웹 브라우저의 기본 언어를 한국어로 설정
            settings.Locale = "kr";
            // 캐시 데이터 저장
            settings.CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"MyHomeAlert\Cache");
            // debug.log 사용 중지
            settings.LogSeverity = LogSeverity.Disable;

            // CefSharp가 서브폴더에 정상적으로 이동되면 BrowserSubProcessPath도 수정
            if (resolved)
                settings.BrowserSubprocessPath = Path.Combine(Application.StartupPath, cefSubFolder, "CefSharp.BrowserSubprocess.exe");

            // performDependencyCheck를 false로 해야 기존 어셈블리에 의존하지 않는다.
            Cef.Initialize(settings, performDependencyCheck: false);
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            // CefSharp 어셈블리를 서브 폴더에서 사용
            if (args.Name.StartsWith("CefSharp"))
            {
                resolved = true; // Set to true, so BrowserSubprocessPath will be set

                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string subfolderPath = Path.Combine(Application.StartupPath, cefSubFolder, assemblyName);
                return File.Exists(subfolderPath) ? Assembly.LoadFile(subfolderPath) : null;
            }
            // HtmlAgilityPack 어셈블리를 서브 폴더에서 사용
            if (args.Name.StartsWith("HtmlAgilityPack"))
            {
                resolved = true; // Set to true, so BrowserSubprocessPath will be set

                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string subfolderPath = Path.Combine(Application.StartupPath, hapSubFolder, assemblyName);
                return File.Exists(subfolderPath) ? Assembly.LoadFile(subfolderPath) : null;
            }

            return null;
        }
    }
}
