using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using MacGuffin.Business;
using MacGuffin.Business.Providers;

namespace MacGuffin.App
{
    class Program
    {  
        private const string FilesPathSettingName      = "FilesPath";
        private const string CategoriesPathSettingName = "CategoriesPath";
        private const string ZipFileName               = "categories_bak.zip";

        static void Main(string[] args)
        {
            var container = ConfigureAutofac();

            using (var scope = container.BeginLifetimeScope())
            {
                var photoSorter = scope.Resolve<IPhotoSorter>();
                var fileProvider = scope.Resolve<IFileProvider>();
                var configurationProvider = scope.Resolve<IConfigurationProvider>();

                var filesPath = configurationProvider.GetAppSetting(FilesPathSettingName);
                var categoriesPath = configurationProvider.GetAppSetting(CategoriesPathSettingName);
                var zipFilePath = Path.Combine(categoriesPath, ZipFileName);

                Console.WriteLine("Back up categories? (y/n)");
                var enteredBackup = Console.ReadLine() ?? "";
                var doBackup = enteredBackup.ToLower() != "n";

                if (doBackup)
                {
                    try
                    {
                        Console.WriteLine("Backing up existing categories.");
                        zipFilePath = fileProvider.CreateZip(categoriesPath, ZipFileName);
                        Console.WriteLine("Backup successful!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error backing up.");
                        Console.Write(ex);
                        return;
                    }
                }

                try
                {
                    Console.WriteLine("Sorting photos.");
                    photoSorter.SortPhotos(filesPath, categoriesPath);
                    Console.WriteLine("Sorting successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sorting photos.");
                    Console.Write(ex);

                    if (doBackup)
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine("Reverting category folders to original state.");
                            fileProvider.RestoreFolderFromZip(categoriesPath, zipFilePath);
                            Console.WriteLine("Reversion successful.");
                        }
                        catch (Exception ex2)
                        {
                            Console.WriteLine("Error reverting. :(");
                            Console.Write(ex2);
                        }
                    }
                }
            }
        }

        private static IContainer ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConfigurationProvider>().As<IConfigurationProvider>();
            builder.RegisterType<FileProvider>().As<IFileProvider>();
            builder.RegisterType<PhotoProvider>().As<IPhotoProvider>();
            builder.RegisterType<PhotoSorter>().As<IPhotoSorter>();
            var container = builder.Build();

            return container;
        }
    }
}
