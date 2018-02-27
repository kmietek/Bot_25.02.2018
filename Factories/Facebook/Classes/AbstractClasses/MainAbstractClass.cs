using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Factories.Facebook.Interfaces;

namespace Factories.Facebook.Classes.AbstractClasses
{
    public abstract class MainAbstractClass : IMain
    {
        //data base connection
        public abstract List<AncillaryAbstractClass> GetData();

        public abstract void SetHtmlTxt(string document);


        public abstract bool AmReady();

        public abstract bool CanScrool();

        private string documentText;


    }
}
