﻿using System.Collections.Generic;
using Factories.Facebook.Classes.AbstractClasses;

namespace Factories.Facebook.Classes.MainClasses.About
{
    public class MainContactInfo : MainAbstractClass
    {
        private string documentText = "";

        public override List<AncillaryAbstractClass> GetData()
        {
            return new List<AncillaryAbstractClass>();
        }
        public override void SetHtmlTxt(string document)
        {
            this.documentText = document;
        }

        public override bool AmReady()
        {
            return true;
        }

        public override bool CanScrool() => false;
    }
}