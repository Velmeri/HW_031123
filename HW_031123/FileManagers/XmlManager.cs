using HW_031123.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW_031123.FileManagers
{
	public class XmlManager
	{
		public void SaveContact(Contact contact, string filePath)
		{
			if (!File.Exists(filePath)) {
				using (FileStream fs = File.Create(filePath)) {

				}
			}
			XmlSerializer serializer = new XmlSerializer(typeof(Contact));
			using (StreamWriter writer = new StreamWriter(filePath)) {
				serializer.Serialize(writer, contact);
			}
		}

		public Contact LoadContact(string filePath)
		{
			if (!File.Exists(filePath)) {
				using (FileStream fs = File.Create(filePath)) {
					
				}
				return null;
			}

			XmlSerializer serializer = new XmlSerializer(typeof(Contact));
			using (StreamReader reader = new StreamReader(filePath)) {
				return (Contact)serializer.Deserialize(reader);
			}
		}

	}
}
