using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMinecraftInventory
{
	public class Inventory
	{
		private const int _size = 36;
		public InventorySlot[] Slots = new InventorySlot[_size];
		public Inventory() 
		{
			for(int i = 0; i < _size; i++)
			{
				Slots[i] = new InventorySlot();
			}
		}
		public Inventory(InventorySlot[] slots)
		{
			if(slots.Length == _size)
			{
				Slots = slots;
			}
			else
			{
				throw new Exception
					($"Instantiation failed; Input array for the Inventory constructor must have exactly {_size} slots.");
			}
		}
		public string SummaryString()
		{
			// String array of formatted quantities. Name is abbreviated to make return string easier to read.
			string[] Qs = new string[_size];
			for(int i = 0; i < _size; i++)
			{
				Qs[i] = Slots[i].FormatQuantityForDisplay();
			}
			return
				"+--+--+--+--+--+--+--+--+--+\n" +
				$"|{Qs[0]}|{Qs[1]}|{Qs[2]}|{Qs[3]}|{Qs[4]}|{Qs[5]}|{Qs[6]}|{Qs[7]}|{Qs[8]}|\n" +
				"+--+--+--+--+--+--+--+--+--+\n" +
				$"|{Qs[9]}|{Qs[10]}|{Qs[11]}|{Qs[12]}|{Qs[13]}|{Qs[14]}|{Qs[15]}|{Qs[16]}|{Qs[17]}|\n" +
				"+--+--+--+--+--+--+--+--+--+\n" +
				$"|{Qs[18]}|{Qs[19]}|{Qs[20]}|{Qs[21]}|{Qs[22]}|{Qs[23]}|{Qs[24]}|{Qs[25]}|{Qs[26]}|\n" +
				"+--+--+--+--+--+--+--+--+--+\n\n" +
				"+--+--+--+--+--+--+--+--+--+\n" +
				$"|{Qs[27]}|{Qs[28]}|{Qs[29]}|{Qs[30]}|{Qs[31]}|{Qs[32]}|{Qs[33]}|{Qs[34]}|{Qs[35]}|\n" +
				"+--+--+--+--+--+--+--+--+--+\n"
			;
		}
		public string DetailedString()
		{
			string result = "";
			for(int i = 0; i < _size; i++)
			{
				result = result + "[" + Slots[i].ToString() + "]\n";
			}
			return result;
		}
	}
}
