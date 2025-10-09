using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinic.interfaces;

public interface INotificion
{
    public void SendNotificion(string patientName);
}
