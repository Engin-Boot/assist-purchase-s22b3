using AssistPurchase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssistPurchase.Utility
{
    public class CsvFileHandler : IFileHandler
    {
        public bool DeleteFromFile(string id,string filepath)
        {
            bool isDeleted = false;
            string line;
            int lineCounter= 0;
            List<string> patientMonitorData = new List<string>();
            try
            {
                
                using(var reader = new StreamReader(filepath))
                {
                    while ((line = reader.ReadLine() )!= null)
                    {
                        lineCounter++;
                        var values = line.Split(',');
                        if(string.Compare(id,values[0])!=0)
                        {
                            patientMonitorData.Add(line);
                           
                        }
                    }
                    isDeleted = CompareDataListsAfterDelete(lineCounter, patientMonitorData);
                    
                }
                using var writer = new StreamWriter(filepath);
                foreach (var writeline in patientMonitorData)
                {
                    writer.WriteLine(writeline);

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
                    using var reader = new StreamReader(filepath);
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        PatientMonitor patientMonitor = FormatStringToObject(values);
                        patientMonitors.Add(patientMonitor);
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
            bool isWritten = false;
            try
            {
                string csvData = FormatObjectDataToString(data);
                if (File.Exists(filepath) && csvData!=null)
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

        private string FormatObjectDataToString(PatientMonitor data)
        {
            string csvFormatData = null;
            try
            {
                if (data.MonitorId != null)
                {
                    data.ProductImage.ImageSaveAs(data.MonitorName);
                    csvFormatData = string.Join(',', new object[]{
                    data.MonitorId,
                    data.MonitorName,
                    data.MonitorDescription,
                    data.MonitorPhysicalSpecification.ProductWeight.ToString(),
                    data.MonitorPhysicalSpecification.ProductSize.ProductLength.ToString(),
                    data.MonitorPhysicalSpecification.ProductSize.ProductWidth.ToString(),
                    data.MonitorPhysicalSpecification.ProductSize.ProductHeight,
                    data.MonitorDisplaySpecification.DisplaySize,
                    data.MonitorDisplaySpecification.DisplayResolution,
                    string.Join(' ',data.MonitorMeasurementsSpecification.BasicVitalsMeasured),
                    data.MonitorBatterySpecification.BatteryCapacity,
                     data.ProductImage.ImageSource
                    });      
                }
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);     
            }

            return csvFormatData;
            
        }

        private PatientMonitor FormatStringToObject(string[] values)
        {
            PatientMonitor patientMonitor = new PatientMonitor();
            patientMonitor.MonitorId = values[0];
            patientMonitor.MonitorName = values[1];
            patientMonitor.MonitorDescription = values[2];
            patientMonitor.MonitorPhysicalSpecification = new PhysicalSpecificationDataModel(double.Parse(values[3]), new ProductSizeDataModel(double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6])));
            patientMonitor.MonitorMeasurementsSpecification = new MeasurementSpecificationDataModel(values[9].Split(null).ToList());
            patientMonitor.MonitorDisplaySpecification = new DisplaySpecificationDataModel(double.Parse(values[7]), values[8]);
            patientMonitor.MonitorBatterySpecification = new BatterySpecificationDataModel(double.Parse(values[10]));
            patientMonitor.ProductImage = new ProductImageDataModel(values[11]);
            return patientMonitor;
        }

        private bool CompareDataListsAfterDelete(int lineCounter, List<string> data)
        {
            bool check;
            if (lineCounter==data.Count)
            {
                check = false;
            }
            else
            {
                check = true;
            }
            return check;
        }
    }
}
