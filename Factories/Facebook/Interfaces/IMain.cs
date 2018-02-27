using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factories.Facebook.Classes.AbstractClasses;

namespace Factories.Facebook.Interfaces
{
    interface IMain
    {
        List<AncillaryAbstractClass> GetData();
        bool AmReady();
        bool CanScrool();
    }
}
