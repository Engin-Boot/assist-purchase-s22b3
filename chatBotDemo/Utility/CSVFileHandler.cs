using chatBotDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace chatBotDemo.Utility
{
    public class CSVFileHandler : IFileHandler
    {
        public bool DeleteFromFile(string id,string filepath)
        {
            bool isDeleted = default(bool);
            try
            {
                if(File.Exists(filepath))
                {
                    var writer = new StreamWriter(filepath);
                    var patientMonitors = ReadFile(filepath);
                    foreach(var monitor in patientMonitors)
                    {
                        if(monitor.MonitorID!=id)
                        {
                            writer.WriteLine(monitor);
                        }
                        
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return isDeleted;
            
        }

        public IEnumerable<PatientMonitor> ReadFile(string filepath)
        {
            List<PatientMonitor> patientMonitors = new List<PatientMonitor>();
           try
            {
                if(File.Exists(filepath))
                {
                    using(var reader = new StreamReader(filepath))
                    {
                        var header = reader.ReadLine();
                        while(!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            PatientMonitor patientMonitor = new PatientMonitor();
                            patientMonitor.MonitorID = values[0];
                            patientMonitor.MonitorName = values[1];
                            patientMonitor.MonitorDescription = values[2];
                            patientMonitor.MonitorPhysicalSpecification = new PhysicalSpecificationDataModel(double.Parse(values[3]), new ProductSizeDataModel(double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6])));
                            patientMonitor.MonitorMeasurementsSpecification = new MeasurementSpecificationDataModel(values[9].Split(null).ToList());
                            patientMonitor.MonitorDisplaySpecification = new DisplaySpecificationDataModel(double.Parse(values[7]), values[8]);
                            patientMonitor.MonitorBatterySpecification = new BatterySpecificationDataModel(double.Parse(values[10]));
                           patientMonitors.Add(patientMonitor);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(patientMonitors.Count);
            return patientMonitors;
        }

        public bool WriteToFile(PatientMonitor data,string filepath)
        {
            bool isWritten = default(bool);
            try
            {
                string csvData = string.Join(',', new object[]{
                data.MonitorID,
                data.MonitorName,
                data.MonitorDescription,
                data.MonitorPhysicalSpecification.ProductWeight.ToString(),
                data.MonitorPhysicalSpecification.ProductSize.ProductLength.ToString(),
                data.MonitorPhysicalSpecification.ProductSize.ProductWidth.ToString(),
                data.MonitorPhysicalSpecification.ProductSize.ProductHeight,
                data.MonitorDisplaySpecification.DisplaySize,
                data.MonitorDisplaySpecification.DisplayResolution,
                string.Join(' ',data.MonitorMeasurementsSpecification.BasicVitalsMeasured),
                data.MonitorBatterySpecification.BatteryCapacity
            });
                if (File.Exists(filepath))
                {
                    File.AppendAllText(filepath, csvData+'\n');
                    isWritten = true;
                }    
            }
            catch(Exception e)
            {
                isWritten = false;
                Console.WriteLine(e.Message);
            }
            return isWritten;
        }
    }
}
