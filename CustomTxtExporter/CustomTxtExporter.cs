using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Kofax.Eclipse.Base;

namespace CustomTxtExporter
{
    public class CustomTxtExporter : IDocumentIndexGenerator, IBatchIndexGenerator
    {
        private readonly ExporterSettings _exportSettings = new ExporterSettings();

        public void SerializeSettings(Stream output)
        {
            using (BinaryWriter writer = new BinaryWriter(output))
            {
                writer.Write(_exportSettings.OverRideDefault.ToString());
                writer.Write(_exportSettings.UseImageFileName.ToString());
                writer.Write(_exportSettings.Destination);
            } 
        }

        public void DeserializeSettings(Stream input)
        {
            using (BinaryReader reader = new BinaryReader(input))
            {
                try
                {
                    _exportSettings.OverRideDefault = Convert.ToBoolean(reader.ReadString());
                    _exportSettings.UseImageFileName = Convert.ToBoolean(reader.ReadString());
                    _exportSettings.Destination = reader.ReadString();
                }
                catch
                {
                    _exportSettings.OverRideDefault = false;
                    _exportSettings.UseImageFileName = false;
                    _exportSettings.Destination = string.Empty;
                }
            }
        }

        public void Setup(IDictionary<string, string> releaseData)
        {
            CustomTxtExporterSetup setupDialog = new CustomTxtExporterSetup(_exportSettings);

            if(setupDialog.ShowDialog() != DialogResult.OK) return;
        }

        public Guid Id
        {
            get { return new Guid("{9D1054F6-26BC-4fee-BF03-134423416186}"); }
        }

        public string Name
        {
            get { return "Custom Text Exporter"; }
        }

        public string Description
        {
            get { return "Custom text exporter"; }
        }

        public string DefaultExtension
        {
            get { return "TXT"; }
        }

        public bool IsCustomizable
        {
            get { return true; }
        }

        bool IDocumentIndexGenerator.IsSupported(ReleaseMode mode)
        {
            return mode == ReleaseMode.MultiPage;
        }

        void IBatchIndexGenerator.SerializeSample(IDictionary<string, string> releaseData, Stream output){}

        public object StartIndex(IBatch batch, IDictionary<string, string> releaseData, string outputFileName)
        {
            return null;
        }

        public void AppendIndex(IDocument document, string outputFileName){}

        public void EndIndex(object handle, ReleaseResult result, string outputFileName){}

        ReleaseMode IBatchIndexGenerator.WorkingMode
        {
            get { return ReleaseMode.MultiPage; }
            set {}
        }

        bool IBatchIndexGenerator.IsSupported(ReleaseMode mode)
        {
            return mode == ReleaseMode.MultiPage;
        }

        void IDocumentIndexGenerator.SerializeSample(IDictionary<string, string> releaseData, Stream output){}

        public void CreateIndex(IDocument document, IDictionary<string, string> releaseData, string outputFileName)
        {
            if (_exportSettings.OverRideDefault)
                outputFileName = GetIndexFileName(releaseData[string.Format("DocumentOutputFileName[{0}]", document.Number)], outputFileName);

            using (FileStream fs = new FileStream(outputFileName, FileMode.Append, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.ASCII))
            {
                for (int i = 0; i < document.IndexDataCount; i++)
                    writer.WriteLine(string.Format("{0}={1}", document.GetIndexDataLabel(i), document.GetIndexDataValue(i)));

                writer.Flush();
                writer.Close();
            } 
        }

        ReleaseMode IDocumentIndexGenerator.WorkingMode
        {
            get { return ReleaseMode.MultiPage; }
            set {}
        }

        private string GetIndexFileName(string imageFileName, string outputFileName)
        {
            if (string.IsNullOrEmpty(imageFileName) || string.IsNullOrEmpty(outputFileName))
                throw new NoNullAllowedException("imageFileName is empty");

            if (!_exportSettings.UseImageFileName && string.IsNullOrEmpty(_exportSettings.Destination))
                throw new Exception("Invalid settings");

            if (_exportSettings.UseImageFileName && string.IsNullOrEmpty(_exportSettings.Destination))
                return Path.ChangeExtension(imageFileName, DefaultExtension);

            if (_exportSettings.UseImageFileName && !string.IsNullOrEmpty(_exportSettings.Destination))
            {
                CreateDestination();

                string filename = Path.GetFileName(Path.ChangeExtension(imageFileName, DefaultExtension));
                return Path.Combine(_exportSettings.Destination, filename); 
            }

            if (!_exportSettings.UseImageFileName && !string.IsNullOrEmpty(_exportSettings.Destination))
            {
                CreateDestination();

                string filename = Path.GetFileName(outputFileName);
                return Path.Combine(_exportSettings.Destination, filename);
            }

            return outputFileName;
        }

        private void CreateDestination()
        {
            if (!string.IsNullOrEmpty(_exportSettings.Destination))
                if (!Directory.Exists(_exportSettings.Destination))
                    Directory.CreateDirectory(_exportSettings.Destination);
        }
    }
}
