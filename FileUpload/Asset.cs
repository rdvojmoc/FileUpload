using System;
using System.Collections.Generic;
using System.Text;

namespace FileUpload
{
    public class Asset
    {
		public int Id { get; set; }

		public string Name { get; set; }

		public string OriginalName { get; set; }

		public string ContentType { get; set; }

		public int UserId { get; set; }

		public long Size { get; set; }

		public string Directory { get;  set; }

		public string Host { get; set; }
    }
}
