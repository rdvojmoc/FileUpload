using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload
{
    public class FormFileOptions
    {
		public long MaxSize { get; set; }

		public List<string> AllowedTypes { get; set; }
    }
}
