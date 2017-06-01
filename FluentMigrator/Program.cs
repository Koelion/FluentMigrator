using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;

namespace FluentMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=test;Integrated Security=True";
            Announcer announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
            announcer.ShowSql = true;

            Assembly assembly = Assembly.GetExecutingAssembly();
            IRunnerContext migrationContext = new RunnerContext(announcer);

            var options = new ProcessorOptions
            {
                PreviewOnly = false,
                Timeout = 60
            };
            var factory = new SqlServer2014ProcessorFactory();
            using (IMigrationProcessor processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);

            }
        }
    
    }
}
