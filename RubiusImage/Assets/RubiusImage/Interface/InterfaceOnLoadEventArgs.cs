namespace RubiusImage.Interface
{
    public class InterfaceOnLoadEventArgs
    {
        public readonly LoadTypes LoadTypes;

        public InterfaceOnLoadEventArgs(LoadTypes loadTypes)
        {
            LoadTypes = loadTypes;
        }
    }
}