using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPKlijent
{
    public class ExtendedTreeNode:TreeNode
    {
        public bool WasNodeAlreadyExpanded { get; set; } = false;
        public DateTime lastTimeItWasUpdated { get; set; }



        public ExtendedTreeNode()
        {
        }


        public ExtendedTreeNode(string Text):base(Text)
        {
        }


        public ExtendedTreeNode(string Text, TreeNode[] children) : base(Text, children)
        {
        }


        public ExtendedTreeNode(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }


        public ExtendedTreeNode(string Text, int imageIndex, int selectedImageIndex) : base(Text, imageIndex, selectedImageIndex)
        {
        }


        public ExtendedTreeNode(string Text, int imageIndex, int selectedImageIndex, TreeNode[] children) : base(Text, imageIndex, selectedImageIndex, children)
        {
        }

    }
}
