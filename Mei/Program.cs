using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace TestWebApp {
    public class Program {
        private readonly ILog log;
        public Program() {
            ILoggerRepository repository = LogManager.CreateRepository("VideoPlayer");
            XmlConfigurator.ConfigureAndWatch(repository, new FileInfo("Config/Log.conf.xml"));
            log = LogManager.GetLogger("VideoPlayer", "Main");
        }

        public static void Main(string[] args) {
            Directory.CreateDirectory("D:\\VPVideos");
            new Program().Run().Wait();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
        public async Task Run() {
            try {
                Stopwatch sw = new Stopwatch();
                log.Info("Initializing discord connection...");
                sw.Start();
                sw.Stop();
                Timer t = new Timer(1000);
                t.Elapsed += T_Elapsed;
                //List<Type> expectedparams = new List<Type> { typeof(ICoreHandler), typeof(ulong), typeof(ulong), typeof(string) };
                /*foreach (string assembly in Directory.GetFiles("Modules", "*Module.dll")) {
                    log.Info($"Found possible Module container {Path.GetFileName(assembly)}");
                    List<Type> types = Assembly.LoadFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + assembly).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseModule))).ToList();
                    int c = 0;
                    foreach (Type t in types) {
                        MethodInfo[] possiblecommands = t.GetMethods(
                            BindingFlags.DeclaredOnly |
                            BindingFlags.InvokeMethod |
                            BindingFlags.Public |
                            BindingFlags.Instance
                        ).Where(pcmd => pcmd.GetCustomAttribute<CommandAttribute>() != null)
                        .ToArray();
                        string name = (t.Name.EndsWith("Module")) ? t.Name.Remove(t.Name.LastIndexOf("Module")) : t.Name;
                        foreach (MethodInfo cmd in possiblecommands) {
                            Commands.Add(name + "." + cmd.Name, new Tuple<BaseModule, MethodInfo>(Activator.CreateInstance(t) as BaseModule, cmd));
                            log.Debug($"Found Command {cmd.Name}");
                        }
                    }
                    log.Info($"Module container {Path.GetFileName(assembly)} contained {types.Count} modules with {c} commands.");
                }*/
                sw.Stop();
                log.Info($"Modules loaded in {sw.Elapsed.ToString(@"s\.f")}s.");
                log.Info("Startup complete.");
                log.Info("Loading web");
                //stopsignal.WaitOne();
                CreateHostBuilder(null).Build().Run();
                log.Info("Web complete.");
            } catch (Exception ex) {
                log.Fatal(ex);
            }
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e) { 
        
        }
    }
}