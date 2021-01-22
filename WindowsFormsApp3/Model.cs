using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Model
    {
        public class Category
        {
            public string Name = "AA";
            public List<string> categoryData = new List<string>() { "Memory", "Processor", "GPU Engine", "GPU Adapter Memory", "GPU Process Memory", "IPv4", "IPv6", "LogicalDisk", "Network Adapter", "Network Interface", "Paging File", "PhysicalDisk", "Power Meter", "Processor Information", "Storage Spaces Virtual Disk", "System", "Thread", "USB" };

            public List<string> getCategoryData()
            {
                return categoryData; 
            }

            public void setCategoryData(List<string> newList)
            {
                categoryData = newList; 
            }
    }

        public class Instance
        {
            public string Name { get; set; }
            public string categoryName { get; set; }
            public List<string> instanceData { get; set; }
        }

        public class Counter
        {
            public string Name { get; set; }
            public string instanceName { get; set; }
            public List<string> counterData { get; set; }
        }
    }
}

