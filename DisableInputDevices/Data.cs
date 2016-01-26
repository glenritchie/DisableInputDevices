using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisableInputDevices
{
    public class Data
    {
        public List<ProgramImage> images { get; set; }
        public List<DeviceID> deviceIDs { get; set; }
    }

    public class ProgramImage 
    {
        public ProgramImage()
        {
        }
        public ProgramImage(String path)
        {
            this.path = path;
        }
        public String path { get; set; }
    }

    public class DeviceID
    {
        public DeviceID() { }
        public DeviceID(String id)
        {
            this.id = id;
        }
        public String id { get; set; }
    }
}
