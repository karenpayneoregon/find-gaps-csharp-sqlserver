using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerExampleConsoleApp.Models
{
    public partial class Contacts
    {

        /// <summary>
        /// Id
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Contact Type Id
        /// </summary>
        public int? ContactTypeIdentifier { get; set; }

        public override string ToString() => ContactId.ToString();

    }
}
