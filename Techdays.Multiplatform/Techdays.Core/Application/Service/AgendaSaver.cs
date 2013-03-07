using System.Collections.Generic;
using Cirrious.MvvmCross.Core;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.Json;

namespace Techdays.Core.Application.Service
{
    public class AgendaSaver
        : IMvxServiceConsumer<IMvxSimpleFileStoreService>
        , IMvxServiceConsumer<IMvxJsonConverter>
    {
        private List<string> _toSave;
        private const string FileName = "agenda.json";

        public void RequestAsyncSave(List<string> toSave)
        {
            lock (this)
            {
                var wasNull = _toSave == null;
                _toSave = toSave;
                if (wasNull)
                    MvxAsyncDispatcher.BeginAsync(DoSave);
            }
        }

        private void DoSave()
        {
            try
            {
                List<string> toSave;
                lock (this)
                {
                    toSave = _toSave;
                    _toSave = null;
                }

                if (toSave == null)
                    return; // nothing to do

                var jsonConvert = this.GetService<IMvxJsonConverter>();
                var json = jsonConvert.SerializeObject(toSave);
                var fileService = this.GetService<IMvxSimpleFileStoreService>();
                
                //needed for WinRT: if the file allready exists, the WriteFile call will throw an exception
                //fixed it by first deleting the file and then rewriting the whole bit.
                if (fileService.Exists(FileName))
                    fileService.DeleteFile(FileName);

                fileService.WriteFile(FileName, json);
            }
            catch
            {
            }
        }

        public List<string> LoadAgenda()
        {
            var files = this.GetService<IMvxSimpleFileStoreService>();
            string json;
            if ((!files.Exists(FileName)) || !files.TryReadTextFile(FileName, out json))
            {
                return null;
            }

            var jsonConvert = this.GetService<IMvxJsonConverter>();
            var parsedKeys = jsonConvert.DeserializeObject<List<string>>(json);
            return parsedKeys;
        }
    }
}
