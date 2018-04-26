using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Bezoeker
    {
        
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string address { get; set; }
            public string email { get; set; }
            public bool ontbijt { get; set; }
            public bool factuur { get; set; }

            public string ToXML()
            {
            return "<uuid>456564456</uuid>" +
            "<type>bezoeker</type>" +
            $"<firstname>{ this.firstname }</firstname>" +
            $"<lastname>{ this.lastname }</lastname>" +
            $"<address>{ this.address }</address>" +
            $"<email>{ this.email }</email>" +
            "<isActive>true</isActive>" +
            "<isAllowed>true</isAllowed>" +
            "<roles></roles>" +
            "<version>1</version>" +
            $"<timestamp>{ DateTime.Now }</timestamp>";
            }
        


    }
}
