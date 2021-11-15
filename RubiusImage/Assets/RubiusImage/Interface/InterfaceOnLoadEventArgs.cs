using RubiusImage.Interface.Dropdown;

namespace RubiusImage.Interface
{
    public class InterfaceOnLoadEventArgs
    {
        public LoadTypes LoadTypes;

        public InterfaceOnLoadEventArgs(LoadTypes loadTypes)
        {
            LoadTypes = loadTypes;
        }
    }
}