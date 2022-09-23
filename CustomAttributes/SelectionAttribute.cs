using UnityEngine;

namespace CustomAttributes
{
    /// <summary>
    /// <code>[Selection("ListOrArrayName", displayElement)]</code>
    /// <list type="Examples">
    ///     <listheader>
    /// <para>Example Usage:</para> 
    ///    </listheader>
    ///     <item>
    /// <para>Display int field as list or array label, add selected array element number bool value is true by default : </para> 
    /// <code>[Selection("ListOrArrayName")] public int mySelection;</code>
    ///     </item>
    ///     <item>
    /// <para>Display int field full example as list or array label without element number : </para> 
    /// <code>[SerializeField] private List&lt;string&gt; testList = new List()&lt;string&gt;;</code>
    /// <code>public string[] TestList { get { return testList; } }</code>
    /// <code>[Selection("TestList", false)] public int mySelection;</code>
    ///     </item>
    ///     <item>
    /// <para>Display int field full example  as list or array label with element number and debug selection to console : </para> 
    /// <code>[SerializeField] private string[] testArray = new string[3];</code>
    /// <code>public string[] TestArray { get { return testArray; } }</code>
    /// <code>[Selection("TestArray", debug = true)] public int mySelection;</code>
    ///     </item>
    /// </list>
    /// </summary>
    public class SelectionAttribute : PropertyAttribute
    {
        public string ListName { get; }
        public bool addElement = true;
        public bool debug = false;

        public SelectionAttribute(string listName)
        {
            ListName = listName;
        }
        public SelectionAttribute(string listName, bool displayElement)
        {
            ListName = listName;
            addElement = displayElement;
        }
    }
}